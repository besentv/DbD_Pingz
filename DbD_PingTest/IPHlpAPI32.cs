using System;
using System.Net;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;



namespace DbD_Pingz
{
    #region UDP

    [StructLayout(LayoutKind.Sequential)]
	public struct MIB_UDPSTATS
	{
		public int dwInDatagrams ;
		public int dwNoPorts ;
		public int dwInErrors ;
		public int dwOutDatagrams ;
		public int dwNumAddrs;
	}

	public struct MIB_UDPTABLE 
	{
		public int dwNumEntries;  
		public MIB_UDPROW[] table;

	}

	public struct MIB_UDPROW 
	{
		public IPEndPoint Local;
	}

	public struct MIB_EXUDPTABLE
	{
		public int dwNumEntries;  
		public MIB_EXUDPROW[] table;

	}

	public struct MIB_EXUDPROW
	{
		public IPEndPoint Local;  
		public int dwProcessId;
		public string ProcessName;
	}

    public struct MIB_UDPROW_OWNER_PID
    {
        public IPEndPoint localEndpoint;
        public int dwOwningPid;
    }

    public struct MIB_UDPTABLE_OWNER_PID
    {
        public int dwNumEntries;
        public MIB_UDPROW_OWNER_PID[] table;
    }

    public enum UDP_TABLE_CLASS
    {
        UDP_TABLE_BASIC,
        UDP_TABLE_OWNER_PID,
        UDP_TABLE_OWNER_MODULE
    }
    #endregion

    #region TCP
    [StructLayout(LayoutKind.Sequential)]
	public struct MIB_TCPSTATS
	{
		public int dwRtoAlgorithm ;
		public int dwRtoMin ;
		public int dwRtoMax ;
		public int dwMaxConn ;
		public int dwActiveOpens ;
		public int dwPassiveOpens ;
		public int dwAttemptFails ;
		public int dwEstabResets ;
		public int dwCurrEstab ;
		public int dwInSegs ;
		public int dwOutSegs ;
		public int dwRetransSegs ;
		public int dwInErrs ;
		public int dwOutRsts ;
		public int dwNumConns ;
	}


	public struct MIB_TCPTABLE 
	{
		public int dwNumEntries;  
		public MIB_TCPROW[] table;

	}

	public struct MIB_TCPROW 
	{
		public string StrgState; 
		public int iState;
		public IPEndPoint Local;  
		public IPEndPoint Remote;
	}

	public struct MIB_EXTCPTABLE
	{
		public int dwNumEntries;  
		public MIB_EXTCPROW[] table;

	}

	public struct MIB_EXTCPROW
	{
		public string StrgState;
		public int iState;
		public IPEndPoint Local;  
		public IPEndPoint Remote;
		public int dwProcessId;
		public string ProcessName;
	}


    #endregion


    public class IpHlpApi32
	{
		public const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
		public const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
		public const int FORMAT_MESSAGE_FROM_SYSTEM  = 0x00001000;
		public int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | 
			FORMAT_MESSAGE_FROM_SYSTEM | 
			FORMAT_MESSAGE_IGNORE_INSERTS;

        public const int NO_ERROR = 0;
        private const int MIB_TCP_STATE_CLOSED = 1;
        private const int MIB_TCP_STATE_LISTEN = 2;
        private const int MIB_TCP_STATE_SYN_SENT = 3;
        private const int MIB_TCP_STATE_SYN_RCVD = 4;
        private const int MIB_TCP_STATE_ESTAB = 5;
        private const int MIB_TCP_STATE_FIN_WAIT1 = 6;
        private const int MIB_TCP_STATE_FIN_WAIT2 = 7;
        private const int MIB_TCP_STATE_CLOSE_WAIT = 8;
        private const int MIB_TCP_STATE_CLOSING = 9;
        private const int MIB_TCP_STATE_LAST_ACK = 10;
        private const int MIB_TCP_STATE_TIME_WAIT = 11;
        private const int MIB_TCP_STATE_DELETE_TCB = 12;

        public const int AF_INET = 2;
        public const int AF_INET6 = 23;

        [DllImport("iphlpapi.dll", SetLastError = true)]
        public extern static int GetExtendedUdpTable(byte[] pUdpTable, out int pdwSize, bool bOrder, int ulAf, UDP_TABLE_CLASS TableClass, int Reserved);

        [DllImport("iphlpapi.dll",SetLastError=true)]
		public extern static int GetUdpStatistics (ref MIB_UDPSTATS pStats );

		[DllImport("iphlpapi.dll",SetLastError=true)]
		public static extern int GetUdpTable(byte[] UcpTable, out int pdwSize, bool bOrder);

		[DllImport("iphlpapi.dll",SetLastError=true)]
		public extern static int GetTcpStatistics (ref MIB_TCPSTATS pStats );

		[DllImport("iphlpapi.dll",SetLastError=true)]
		public static extern int GetTcpTable(byte[] pTcpTable, out int pdwSize, bool bOrder);

		[DllImport("iphlpapi.dll",SetLastError=true)]
		public extern static int AllocateAndGetTcpExTableFromStack(ref IntPtr pTable, bool bOrder, IntPtr heap ,int zero,int flags );

		[DllImport("iphlpapi.dll",SetLastError=true)]
		public extern static int AllocateAndGetUdpExTableFromStack(ref IntPtr pTable, bool bOrder, IntPtr heap,int zero,int flags );

		[DllImport( "kernel32.dll " ,SetLastError=true)]
		public static extern IntPtr GetProcessHeap(); 

		[DllImport( "kernel32.dll" ,SetLastError=true)]
		private static extern int FormatMessage( int flags, IntPtr source, int messageId,
			int languageId, StringBuilder buffer, int size, IntPtr arguments ); 


		public static string GetAPIErrorMessageDescription(int ApiErrNumber ) 
		{
			System.Text.StringBuilder sError = new System.Text.StringBuilder(512); 
			int lErrorMessageLength; 
			lErrorMessageLength = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM,(IntPtr)0, ApiErrNumber, 0, sError, sError.Capacity, (IntPtr)0) ;
			
			if(lErrorMessageLength > 0)
			{ 
				string strgError = sError.ToString();
				strgError=strgError.Substring(0,strgError.Length-2);
				return strgError+" ("+ApiErrNumber.ToString()+")";
			}
			return "none";

		}	 
	}
}

