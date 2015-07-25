using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmhiNet.Interfaces;

namespace UnitTestForSmhiNet.FakesRepositories
{
    class FakeCachedData : ICachedData
    {
        private Dictionary<string, object> _cache = new Dictionary<string, object>();


        public object GetCache(string keyName)
        {
            
            return _cache[keyName];
            
            
        }

        public bool HasValue(string keyName)
        {
            return _cache.ContainsKey(keyName);
        }


        public void SetCache(string keyName, object objectToCache, int cacheItemPolicy)
        {
            _cache.Add(keyName, objectToCache);
        }

        public void RemoveCache(string keyName)
        {
            throw new NotImplementedException();
        }
    }
}
