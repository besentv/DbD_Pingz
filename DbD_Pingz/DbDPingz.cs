using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public enum DbDPingzMode
    {
        Killer,
        Surivivor
    }

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

