using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace WinsockEcho
{
    class CBinding
    {
        private bool nobinding = false;
        private IntPtr hLib;
        private int fd = 0;

        private delegate int Type_Bind(string ip, ref ushort port);
        private Type_Bind funcBind;
        private delegate void Type_Close(int fd);
        private Type_Close funcClose;

        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(string path);

        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, string funcName);

        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);

        public CBinding(string dllpath)
        {
            if(dllpath.Length == 0)
            {
                nobinding = true;
                return;
            }
            hLib = LoadLibrary(dllpath);
            if (hLib == null)
            {
                nobinding = true;
                return;
            }
            if (hLib != null)
            {
                funcBind = (Type_Bind)Invoke("Bind", typeof(Type_Bind));
            }
        }

        ~CBinding()
        {
            if (hLib != null) FreeLibrary(hLib);
            else if (nobinding && s != null) s.Close();
        }

        //将要执行的函数转换为委托
        private Delegate Invoke(string APIName, Type t)
        {
            IntPtr api = GetProcAddress(hLib, APIName);
            return Marshal.GetDelegateForFunctionPointer(api, t);
        }

        private Socket s;

        //C signature: int Bind(const char* ip, unsigned short* port)
        //Bind return socket fd
        public int Bind(string ip, ref ushort port)
        {
            if (ip == "") throw new ArgumentNullException("ip");
            if (nobinding)
            {
                if (s != null) throw new Exception("Dulplicate Bind.");
                s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                s.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                port = (ushort)((IPEndPoint)s.LocalEndPoint).Port;
                fd = (int)s.Handle;
            } else
            {
                fd = funcBind(ip, ref port);
            }
            return fd;
        }

        //C signature: void Close(int fd)
        public void Close()
        {
            if (nobinding)
            {
                if (s == null) throw new Exception("Dulplicate Close.");
                s.Close();
                s = null;
            } else
            {
                if (fd == 0) throw new Exception("Dulplicate Close.");
                funcClose(fd);
            }
            fd = 0;
        }
    }
}
