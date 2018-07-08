using System;

namespace DbD_Pingz
{
    public class PacketStats
    {

        private long dismissed;
        private long total;
        private float packetloss;

        public long Dismissed
        {
            get { return dismissed; }
            set
            {
                dismissed = value;
                setPacketLoss();
            }
        }
        public long Total
        {
            get { return total; }
            set
            {
                total = value;
                setPacketLoss();
            }
        }
        public float PacketLoss { private set; get; }

        public PacketStats()
        {
            Dismissed = 0;
            Total = 0;
            PacketLoss = 1;
        }

        private void setPacketLoss()
        {
            if(total > 0)
            {
                PacketLoss = (float) ((float)dismissed / (float)total);
            }
        }

    }
}
