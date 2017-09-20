using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DbD_Pingz
{
    class PingList<TKey,TValue> : ConcurrentDictionary<TKey,TValue>
    {

    }
}
