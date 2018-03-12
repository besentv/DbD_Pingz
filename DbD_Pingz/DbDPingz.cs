using System;
using System.Windows.Forms;

namespace DbD_Pingz
{
    class DbDPingz
    {
        public const string version = "1.2";
        public const string buildtype = "BETA";
        public const string saveXMLFileName = "DbD_PingTestSave.xml";

        [STAThread]
        static void Main(string[] args)
        {
            //if (args.Length == 0)
            //{
            //    TextWriter consoleWriter = Console.Out;
            //    FileStream logOstream = new FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //    logOstream.SetLength(0);
            //    StreamWriter logfileWriter = new StreamWriter(logOstream);
            //    logfileWriter.AutoFlush = true;
            //    Console.SetOut(logfileWriter);
            //    Console.SetError(logfileWriter);
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new PingInfo(args));
            //    Console.SetOut(consoleWriter);
            //    Console.SetError(consoleWriter);
            //    logOstream.Close();
            //    logfileWriter.Close();
            //}
            //else     
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new PingInfo(args));
            }
        }
    }
}