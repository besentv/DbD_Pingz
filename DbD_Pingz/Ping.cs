using PcapDotNet.Packets.IpV4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbD_Pingz
{
    public class Ping
    {
        public IpV4Address Ip { get; }
        public TimeSpan TimeElapsed { get; }
        public DateTime SentPacketTime { get; }
        public DateTime RecievedPacketTime { get; }
        public bool IsCustomPing { get; }

        public Ping(IpV4Address ip, DateTime sentPacketTime, DateTime recievedPacketTime)
        {
            this.Ip = ip;
            this.TimeElapsed = recievedPacketTime - sentPacketTime;
            this.SentPacketTime = sentPacketTime;
            this.RecievedPacketTime = recievedPacketTime;
        }

        public Ping(Ping ping, TimeSpan customTimeElapsed)
        {
            this.Ip = ping.Ip;
            this.SentPacketTime = ping.SentPacketTime;
            this.RecievedPacketTime = ping.RecievedPacketTime;
            this.TimeElapsed = customTimeElapsed;
            this.IsCustomPing = true;
        }

        protected Ping()
        {

        }

    }
}
