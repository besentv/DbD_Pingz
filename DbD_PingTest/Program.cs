using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace DbD_Pingz
{
    class Program
    {
        static PingList ui;

        static MIB_UDPTABLE_OWNER_PID getUdpTable()
        {
            MIB_UDPTABLE_OWNER_PID udpTable;

            int bufSize = 2;
            byte[] buf = new byte[bufSize];
            int res = IpHlpApi32.GetExtendedUdpTable(buf, out bufSize, true, IpHlpApi32.AF_INET, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0);
            if (res != IpHlpApi32.NO_ERROR)
            {
                Console.WriteLine("Array bufsize to small! Needed size:" + bufSize);
                buf = new byte[bufSize];
                res = IpHlpApi32.GetExtendedUdpTable(buf, out bufSize, true, IpHlpApi32.AF_INET, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0);
            }
            udpTable = new MIB_UDPTABLE_OWNER_PID();
            int nOffset = 0;
            udpTable.dwNumEntries = BitConverter.ToInt32(buf, nOffset);
            nOffset += 4;
            udpTable.table = new MIB_UDPROW_OWNER_PID[udpTable.dwNumEntries];
            Console.WriteLine("Num of entries:" + udpTable.dwNumEntries);
            for (int i = 0; i < udpTable.dwNumEntries; i++)
            {
                IPEndPoint currEndpoint;
                string ip = buf[nOffset] + "." + buf[nOffset + 1] + "." + buf[nOffset + 2] + "." + buf[nOffset + 3];
                Console.Write("IP:" + ip);
                nOffset += 4;
                byte[] port = new byte[4];
                port[1] = buf[nOffset];
                nOffset += 1;
                port[0] = buf[nOffset];
                nOffset += 1;
                port[2] = buf[nOffset];
                nOffset += 1;
                port[3] = buf[nOffset];
                Console.Write("Port:" + BitConverter.ToInt32(port, 0) + " ");
                BitConverter.ToInt32(port, 0);
                currEndpoint = new IPEndPoint(IPAddress.Parse(ip), BitConverter.ToInt32(port, 0));
                udpTable.table[i].localEndpoint = currEndpoint;
                nOffset += 1;
                udpTable.table[i].dwOwningPid = Convert.ToInt32(buf[nOffset]);
                Console.Write("PID:" + BitConverter.ToInt32(buf, nOffset) + " ");
                nOffset += 4;
                Console.WriteLine("\n");
            }
            return udpTable;
        }

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

