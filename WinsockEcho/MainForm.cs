using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace WinsockEcho
{
    public partial class MainForm : Form
    {
        private readonly CBinding cb;
        public MainForm(string dllpath)
        {
            cb = new CBinding(dllpath);
            InitializeComponent();
        }

        private void ButtonLocalBind_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonLocalBind.Text == "bind")
                {
                    string ip = textBoxLocalIP.Text;
                    ushort port = ushort.Parse(textBoxLocalPort.Text);
                    int s = cb.Bind(ip, ref port);
                    textBoxLocalPort.Text = port.ToString();
                    textBoxLocalSocket.Text = s.ToString();
                    buttonLocalBind.Text = "close";
                } else
                {
                    cb.StopReceive();
                    buttonLocalReceive.Text = "receive";
                    cb.Close();
                    textBoxLocalSocket.Text = "";
                    buttonLocalBind.Text = "bind";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private string actionmsg;
        private Action msgaction;
        private readonly Mutex mu = new Mutex();
        private void LogListen(string msg)
        {
            mu.WaitOne();
            actionmsg = msg;
            Invoke(msgaction);
            mu.ReleaseMutex();
        }

        private void ButtonLocalReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonLocalReceive.Text == "receive")
                {
                    textBoxLocalListen.Text = "";
                    msgaction = () =>
                    {
                        textBoxLocalListen.Text += actionmsg + "\n";
                    };
                    cb.Receive(LogListen);
                    buttonLocalReceive.Text = "stop";
                } else
                {
                    cb.StopReceive();
                    buttonLocalReceive.Text = "receive";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private void ButtonRemotePing_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = textBoxRemoteIP.Text;
                ushort port = ushort.Parse(textBoxRemotePort.Text);
                if (port == 0)
                {
                    MessageBox.Show("Invalid Remote Port.", "ERROR");
                    return;
                }
                ButtonRemotePing.Enabled = false;
                List<int> x = new List<int>();
                List<int> y = new List<int>();
                long sum = 0;
                int i = 0;
                Action action = () =>
                {
                        textBoxRemoteDelay.Text = (sum / (i + 1)).ToString();
                        chartRemoteDelay.Series[0].Points.DataBindXY(x, y); //添加数据
                };
                Action finish = () =>
                {
                    ButtonRemotePing.Enabled = true;
                };
                new Thread(() => {
                    try
                    {
                        for (; i < 30 && !IsDisposed; i++)
                        {
                            x.Add(i + 1);
                            long start = GetUnixStampMilli(DateTime.Now);
                            cb.Ping(ip, port);
                            long stop = GetUnixStampMilli(DateTime.Now);
                            long delta = stop - start;
                            y.Add((int)(delta));
                            sum += delta;
                            Invoke(action);
                            Thread.Sleep(1000);
                        }
                        if (IsDisposed) Invoke(finish);
                    } catch (Exception ex) {
                        if (ex.GetType().Name == "InvalidOperationException") return;
                        MessageBox.Show(ex.Message, ex.GetType().Name);
                        Invoke(finish);
                    }
                }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
                ButtonRemotePing.Enabled = true;
            }
        }

        // 作者：西井丶
        // 链接：https://www.zhihu.com/question/484665098/answer/2116000824
        // Modified by fumiama
        private static long GetUnixStampMilli(DateTime value)
             => (int)((value.ToUniversalTime().Ticks - 621355968000000000) / 10000);
    }
}
