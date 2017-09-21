using PcapDotNet.Packets.IpV4;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbD_Pingz
{
    class PingDistributor
    {
        private ConcurrentDictionary<IpV4Address, TimeSpan> pingList = new ConcurrentDictionary<IpV4Address, TimeSpan>();

    }
}
