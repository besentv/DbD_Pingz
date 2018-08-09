using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DbD_Pingz
{
    class Pingz
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static bool ConsoleAllocated = false;

        public const string version = "1.3";
        public static string buildtype = "";
        public const string saveXMLFileName = "DbD_PingTestSave.xml";
        public const string countryStatsDBName = "DbD_PingzCountryStats.sqlitedb";

        public static bool isDebug = false;

        public static void ShowConsole()
        {
            if (!ConsoleAllocated)
            {
                AllocConsole();
                Console.ForegroundColor = ConsoleColor.Magenta;
                ConsoleAllocated = true;
                Console.WriteLine("DbD_Pingz started with console. DEBUG?: " + isDebug);
            }
        }

        [Conditional("DEBUG")]
        public static void isDebugging()
        {
            isDebug = true;
        }

        [STAThread]
        static void Main(string[] args)
        {

            isDebugging();

            if (args.Length > 0)
            {
                if (args[0].Contains("console"))
                {
                    ShowConsole();                                                                  //Use console if desired by argument "-console"
                }
            }

            if (isDebug)
            {
                ShowConsole(); //Use console if build has DEBUG constant
                buildtype = "BETA";
            }

            else if (!isDebug)
            {
                buildtype = "RELEASE";
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PingInfo(args));

        }
    }
}