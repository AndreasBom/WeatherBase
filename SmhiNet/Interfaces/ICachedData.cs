using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmhiNet.Interfaces
{
    /// <summary>
    /// Interface for saving and retriving from cache memory
    /// </summary>
    public  interface ICachedData
    {
        Object GetCache(string keyName);
        void SetCache(string keyName, Object objectToCache, int cacheItemPolicy);
        bool HasValue(string keyName);
        void RemoveCache(string keyName);
        
    }
}
