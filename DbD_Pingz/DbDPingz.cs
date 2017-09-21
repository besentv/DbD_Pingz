using System;
using System.Windows.Forms;

namespace DbD_Pingz
{
    class DbDPingz
    {
        static PingInfo ui;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ui = new PingInfo();
            Application.Run(ui);
        }
    }
}

