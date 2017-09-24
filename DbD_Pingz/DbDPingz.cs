using System;
using System.Windows.Forms;

namespace DbD_Pingz
{
    class DbDPingz
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);   
            Application.Run(new PingInfo(args));
        }
    }
}

