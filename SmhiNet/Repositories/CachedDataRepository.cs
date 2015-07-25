using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmhiNet.Interfaces;
using System.Runtime.Caching;


namespace SmhiNet.Repositories
{
    internal class CachedDataRepository : ICachedData
    {
        private static readonly MemoryCache _cache = MemoryCache.Default;
        
        /// <summary>
        /// Get object from cache memory
        /// </summary>
        /// <param name="keyName">cache key name</param>
        /// <returns>Returns an object from cache memory</returns>
        public object GetCache(string keyName)
        {
            try
            {
                return _cache.Get(keyName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        /// Save object to cache memory
        /// </summary>
        /// <param name="keyName">cache keyname</param>
        /// <param name="objectToCache">Object to save</param>
        /// <param name="cacheItemPolicy">Amount of minutes that the object is saved in cache</param>
        public void SetCache(string keyName, object objectToCache, int cacheItemPolicy)
        {
            try
            {
                var cacheObject = new CacheItem(keyName, objectToCache);
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(cacheItemPolicy))
                };

                _cache.Add(cacheObject.Key, cacheObject.Value, policy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        /// Checks if the cache keyname exists in memory
        /// </summary>
        /// <param name="keyName">cache cache keyname</param>
        /// <returns>Returns boolian</returns>
        public bool HasValue(string keyName)
        {
           return _cache.Contains(keyName);
        }


        /// <summary>
        /// Removes an object from cache memory
        /// </summary>
        /// <param name="keyName">cache keyname</param>
        public void RemoveCache(string keyName)
        {
            try
            {
                _cache.Remove(keyName);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

    }
}
