using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinsockChat
{
    class CBinding
    {
        private bool nobinding = false;
        private IntPtr hLib;
        private int fd = 0;
        private EndPoint localEP;
        private bool stopRecv = true;

        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(string path);

        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, string funcName);

        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);

        private delegate int Type_Init();
        private delegate void Type_Defer();
        private Type_Defer funcDefer;
        private delegate int Type_Bind(string ip, ref ushort port);
        private Type_Bind funcBind;
        private delegate int Type_Close();
        private Type_Close funcClose;
        private delegate int Type_Receive(IntPtr f);
        private Type_Receive funcReceive;
        private delegate int Type_StopReceive();
        private Type_StopReceive funcStopReceive;
        private delegate int Type_Ping(string ip, ushort port);
        private Type_Ping funcPing;

        public CBinding(string dllpath)
        {
            if(dllpath.Length == 0)
            {
                nobinding = true;
                return;
            }
            hLib = LoadLibrary(dllpath);
            if (hLib == IntPtr.Zero)
            {
                nobinding = true;
                return;
            }
            if (hLib != IntPtr.Zero)
            {
                Type_Init funcInit = (Type_Init)Invoke("Init", typeof(Type_Init));
                int r = funcInit();
                if (r < 0)
                {
                    FreeLibrary(hLib);
                    nobinding = true;
                    throw new SystemException("Call funcInit error.");
                }
                funcDefer = (Type_Defer)Invoke("Defer", typeof(Type_Defer));
                funcBind = (Type_Bind)Invoke("Bind", typeof(Type_Bind));
                funcClose = (Type_Close)Invoke("Close", typeof(Type_Close));
                funcReceive = (Type_Receive)Invoke("Receive", typeof(Type_Receive));
                funcStopReceive = (Type_StopReceive)Invoke("StopReceive", typeof(Type_StopReceive));
                funcPing = (Type_Ping)Invoke("Ping", typeof(Type_Ping));
            }
        }

        ~CBinding()
        {
            if (hLib != IntPtr.Zero)
            {
                funcDefer();
                FreeLibrary(hLib);
            }
            else if (nobinding && s != null) s.Close();
        }

        /// <summary>
        /// 将要执行的函数转换为委托
        /// </summary>
        private Delegate Invoke(string APIName, Type t)
        {
            IntPtr api = GetProcAddress(hLib, APIName);
            return Marshal.GetDelegateForFunctionPointer(api, t);
        }

        private Socket s;

        /// <summary>
        /// C signature: int Bind(const char* ip, unsigned short* port)
        /// return socket fd
        /// </summary>
        public int Bind(string ip, ref ushort port)
        {
            if (ip == "") throw new ArgumentNullException("ip");
            if (nobinding)
            {
                if (fd != 0) throw new Exception("Dulplicate Bind.");
                s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                localEP = new IPEndPoint(IPAddress.Parse(ip), port);
                s.Bind(localEP);
                port = (ushort)((IPEndPoint)s.LocalEndPoint).Port;
                fd = (int)s.Handle;
            } else
            {
                fd = funcBind(ip, ref port);
                if (fd <= 0) throw new Exception("funcBind error.");
            }
            return fd;
        }

        /// <summary>
        /// C signature: void Close(int fd)
        /// </summary>
        public void Close()
        {
            if (fd == 0) throw new Exception("Dulplicate Close.");
            if (nobinding) s.Close();
            else
            {
                int r = funcClose();
                if (r < 0) throw new Exception("funcClose error.");
            }
            fd = 0;
        }

        public delegate void Type_LogListen(string msg);

        /// <summary>
        /// C signature: void Receive(void (*f) (const char* msg))
        /// </summary>
        public void Receive(Type_LogListen f)
        {
            if (fd == 0) throw new Exception("No Binding.");
            if (!stopRecv) throw new Exception("Dulplicate Receive.");
            stopRecv = false;
            if (nobinding)
            {
                byte[] buf = new byte[65535];
                // 创建ip+port
                EndPoint remoteEP = new IPEndPoint(0, 0);
                s.BeginReceiveFrom(buf, 0, 65535, SocketFlags.None, ref remoteEP, ReceiveCallback(buf, f), remoteEP);
            }
            else
            {
                stopRecv = funcReceive(Marshal.GetFunctionPointerForDelegate(f)) < 0;
            }
        }

        private AsyncCallback ReceiveCallback(byte[] buf, Type_LogListen f)
        {
            return ar =>
            {
                try
                {
                    EndPoint remoteEP = (EndPoint)ar.AsyncState;
                    int n = s.EndReceiveFrom(ar, ref remoteEP);
                    if (n > 0)
                    {
                        s.SendTo(buf, 0, n, SocketFlags.None, remoteEP);
                        // 将数据流转成字符串
                        string msg = Encoding.Default.GetString(buf, 0, n);
                        f("[" + remoteEP.ToString() + "] " + msg);
                    }
                    if (!stopRecv) s.BeginReceiveFrom(buf, 0, 65535, SocketFlags.None, ref remoteEP, ReceiveCallback(buf, f), remoteEP);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                }
            };
        }

        /// <summary>
        /// C signature: void StopReceive()
        /// </summary>
        public void StopReceive()
        {
            if (fd == 0) throw new Exception("No Binding.");
            if (stopRecv) return;
            stopRecv = true;
            if (!nobinding)
            {
                int r = funcStopReceive();
                if (r < 0) throw new Exception("funcStopReceive error.");
            }
        }

        byte[] pingbuf = new byte[65535];
        /// <summary>
        /// C signature: int Ping(const char* ip, unsigned short port)
        /// </summary>
        public void Ping(string ip, ushort port)
        {
            if (nobinding)
            {
                EndPoint rep = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket tmp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                tmp.Bind(new IPEndPoint(0, 0));
                tmp.SendTo(Encoding.Default.GetBytes(DateTime.Now.ToString()), rep);
                tmp.ReceiveFrom(pingbuf, ref rep);
                tmp.Close();
            }
            else
            {
                int r = funcPing(ip, port);
                if (r < 0) throw new Exception("funcPing error.");
            }
        }
    }
}
