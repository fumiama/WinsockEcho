using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinsockEcho
{
    public partial class MainForm : Form
    {
        private CBinding cb = new CBinding("");
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLocalBind_Click(object sender, EventArgs e)
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
                    cb.Close();
                    textBoxLocalSocket.Text = "";
                    buttonLocalBind.Text = "bind";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
    }
}
