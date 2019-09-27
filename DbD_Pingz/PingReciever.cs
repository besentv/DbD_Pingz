using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.IpV6;
using PcapDotNet.Packets.Ip;
using PcapDotNet.Packets.Transport;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DbD_Pingz
{
    public delegate void CalculatedPingEventHandler(object sender, Ping ping);
    public delegate void DismissedPacketHandler(object sender, DismissedPacketEventStats dismissedPacketEventStats);

    public struct StunInfo //This struct is used to keep track of STUN packet data.
    {
        public DateTime sendTime { get; }
        public DataSegment transactionID { get; }

        public StunInfo(DateTime sendTime, DataSegment transactionID)
        {
            this.sendTime = sendTime;
            this.transactionID = transactionID;
        }
    }

    public struct DismissedPacketEventStats
    {
        public IpV4Address address;

        public DismissedPacketEventStats(IpV4Address ipV4Address)
        {
            address = ipV4Address;
        }
    }

    public class PingReciever : IDisposable
    {
        public event CalculatedPingEventHandler CalculatedPingEvent;
        public event DismissedPacketHandler DismissedPacketEvent;
        public bool IsRunning { get; private set; } = false;

        private bool disposed = false;

        public LivePacketDevice SniffingDevice { get; private set; } = null;
        private IpV4Address thisMachinesIpV4Address;
        private PacketCommunicator reciever;
        private Dictionary<IpV4Address, StunInfo> waitingForResponse;


        public PingReciever()
        {
            waitingForResponse = new Dictionary<IpV4Address, StunInfo>();
        }

        private bool TryParseOwnIpV4Address(ReadOnlyCollection<DeviceAddress> addresses, out IpV4Address parsedAddress)
        {
            string internet = "Internet ";
            string ownIpString;
            foreach (DeviceAddress address in SniffingDevice.Addresses)
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
            if (reciever == null)
            {
                if (deviceToSniff == null)
                {
                    Console.WriteLine("NULL2");
                    return;
                }
                this.SniffingDevice = deviceToSniff;
                if (!TryParseOwnIpV4Address(deviceToSniff.Addresses, out thisMachinesIpV4Address))
                {
                    return;
                }
                reciever = deviceToSniff.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000);
                Console.WriteLine("Sniffing device \"" + deviceToSniff.Description + "\" for DbD connections.");
                reciever.SetFilter("ip and udp");
                reciever.ReceivePackets(0, Recieve);
                IsRunning = true;
            }
        }

        public void TryStopPingReciever()
        {
            if (reciever != null)
            {
                reciever.Break();
                reciever.Dispose();
                Console.WriteLine("Stopping Ping Reciever");
                reciever = null;
                IsRunning = false;
            }
        }

        private void Recieve(Packet packet)
        {
            if (packet == null)
            {
                Console.WriteLine("NULL");
                return;
            }

            IpV4Datagram ipV4Packet = packet.Ethernet.IpV4;
            UdpDatagram udp = ipV4Packet.Udp;

            //Payload length changed after dedicated servers update from 68 to 76.
            if ((udp.Payload.Length == 68 || udp.Payload.Length == 76) && ipV4Packet.Destination == thisMachinesIpV4Address && udp.Payload[0] == 0x01)//STUN Reply from OTHER Ip! First payload byte for a STUN response is 1. 
            {
                DataSegment transactionID = udp.Payload.Subsegment(4, 19);

                if (waitingForResponse.ContainsKey(ipV4Packet.Source))
                {
                    waitingForResponse.TryGetValue(ipV4Packet.Source, out StunInfo stunInfo);
                    if (stunInfo.transactionID.Equals(transactionID))
                    {
                        waitingForResponse.Remove(ipV4Packet.Source);
                        CalculatedPingEvent(this, new Ping(ipV4Packet.Source, stunInfo.sendTime, packet.Timestamp));
                    }
                }
            }
            else
            {           //Payload length changed after dedicated servers update from 56 to 64.
                if ((udp.Payload.Length == 56 || udp.Payload.Length == 64) && ipV4Packet.Source == thisMachinesIpV4Address && udp.Payload[0] == 0x00) //STUN Request from OWN Ip! 
                {
                    DataSegment transactionID = udp.Payload.Subsegment(4, 19);
                    StunInfo stunInfo = new StunInfo(packet.Timestamp, transactionID);

                    if (!waitingForResponse.ContainsKey(ipV4Packet.Destination))
                    {
                        waitingForResponse.Add(ipV4Packet.Destination, stunInfo);
                    }
                    else if (waitingForResponse.ContainsKey(ipV4Packet.Destination))
                    {
                        waitingForResponse.Remove(ipV4Packet.Destination);
                        waitingForResponse.Add(ipV4Packet.Destination, stunInfo);
                        DismissedPacketEvent(this, new DismissedPacketEventStats(ipV4Packet.Destination));
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Disposing PingReciever object");
            if (disposed)
                return;
            if (disposing)
            {
                //Managed objects here
            }
            if (reciever != null)
                reciever.Dispose();

            disposed = true;
        }

        ~PingReciever()
        {
            Dispose(false);
        }
    }
}
