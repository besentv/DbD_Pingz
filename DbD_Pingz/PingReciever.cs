using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.IpV4;

namespace DbD_Pingz
{
    public delegate void CalculatedPingEventHandler(object sender, Ping ping);

    public class Ping
    {
        public IpV4Address Ip { get; }
        public TimeSpan TimeElapsed { get; }
        public DateTime SentPacketTime { get; }
        public DateTime RecievedPacketTime { get; }

        public Ping(IpV4Address ip, DateTime sentPacketTime, DateTime recievedPacketTime)
        {
            this.Ip = ip;
            this.TimeElapsed = recievedPacketTime - sentPacketTime;
            this.SentPacketTime = sentPacketTime;
            this.RecievedPacketTime = recievedPacketTime;
        }
    }

    public class PingReciever
    {
        public event CalculatedPingEventHandler CalculatedPingEvent;

        private IpV4Address thisMachinesIpV4Address;
        private LivePacketDevice deviceToSniff;
        private Dictionary<IpV4Address, DateTime> waitingForResponse;


        public PingReciever()
        {
            waitingForResponse = new Dictionary<IpV4Address, DateTime>();
        }

        private bool TryParseOwnIpV4Address(ReadOnlyCollection<DeviceAddress> addresses, out IpV4Address parsedAddress)
        {
            string internet = "Internet ";
            string ownIpString;
            foreach (DeviceAddress address in deviceToSniff.Addresses)
            {
                Console.WriteLine("Local IP:" + address.Address);
                if (address.Address.Family == SocketAddressFamily.Internet)
                {
                    if (address.Address != null)
                    {
                        ownIpString = address.Address.ToString();
                        ownIpString = ownIpString.Replace(internet, "");
                        Console.WriteLine("Trying to parse IP string: '" + ownIpString + "'");
                        if (IpV4Address.TryParse(ownIpString, out IpV4Address temporaryIpObject) == true)
                        {
                            parsedAddress = temporaryIpObject;
                            return true;
                        }
                    }
                }
            }
            Console.WriteLine("ERROR - Couldn't parse ownIpString!");
            parsedAddress = new IpV4Address();
            return false;
        }

        public void StartPingReciever(LivePacketDevice deviceToSniff)
        {
            if (deviceToSniff == null)
            {
                Console.WriteLine("NULL2");
                return;
            }
            this.deviceToSniff = deviceToSniff;
            if (!TryParseOwnIpV4Address(deviceToSniff.Addresses, out thisMachinesIpV4Address))
            {
                return;
            }
            using (PacketCommunicator communicator = deviceToSniff.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {
                Console.WriteLine("Sniffing device \"" + deviceToSniff.Description + "\" for DbD connections.");
                communicator.SetFilter("ip and udp");
                communicator.ReceivePackets(0, Recieve);
            }
        }

        private void Recieve(Packet packet)
        {
            if (packet == null)
            {
                Console.WriteLine("NULL");
                return;
            }
            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;

            if (waitingForResponse.ContainsKey(ip.Source))
            {
                if (udp.Payload.Length == 68 && ip.Destination == thisMachinesIpV4Address && udp.Payload[0] == 0x01)//STUN Reply from OTHER Ip! First payload byte for a STUN response is 1. 
                {
                    waitingForResponse.TryGetValue(ip.Source, out DateTime requestTime);
                    waitingForResponse.Remove(ip.Source);
                    CalculatedPingEvent(this, new Ping(ip.Source, requestTime, packet.Timestamp));
                }
            }
            else
            {
                if (udp.Payload.Length == 56 && ip.Source == thisMachinesIpV4Address && udp.Payload[0] == 0x00) //STUN Request from OWN Ip! 
                {
                    if (!waitingForResponse.ContainsKey(ip.Destination))
                    {
                        waitingForResponse.Add(ip.Destination, packet.Timestamp);
                    }
                }
            }
        }
    }
}
