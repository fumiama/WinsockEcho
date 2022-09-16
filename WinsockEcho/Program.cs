using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinsockEcho
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 2)
            {
                MessageBox.Show("Invalid Parameters.", "ERROR");
                return;
            }
            string dllpath = "WSEcho.dll";
            if (args.Length == 2) dllpath = args[1];
            if (!File.Exists(dllpath))
            {
                MessageBox.Show(dllpath + " not exists, using pure C#.", "NOTICE");
                dllpath = "";
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(dllpath));
        }
    }
}
