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
        static PingList ui;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ui = new PingList();
            Application.Run(ui);
        }
    }
}

