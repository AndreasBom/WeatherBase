using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmhiNet.Models;
using SmhiNet.Interfaces;
using SmhiNet.Repositories;

namespace SmhiNet.Services
{
    public class CachedData
    {
        private ICachedData _cache;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CachedData() :this(new CachedDataRepository())
        {
            
        }

        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="cachedData">Object to inject</param>
        public CachedData(ICachedData cachedData)
        {
            _cache = cachedData;
        }

        

        /// <summary>
        /// Returns an object from cache memory 
        /// </summary>
        /// <param name="keyName">keyname in cache</param>
        /// <returns>Object from cache memory</returns>
        public object GetCache(string keyName)
        {
            return _cache.GetCache(keyName);
        }


        /// <summary>
        /// Sets a value to cache memory
        /// </summary>
        /// <param name="keyName">Associated key name</param>
        /// <param name="objectToCache">Object to save in cache</param>
        /// <param name="cacheItemPolicy">Lifetime of cache in minutes</param>
        public void SetCache(string keyName, object objectToCache, int cacheItemPolicy)
        {
            _cache.SetCache(keyName, objectToCache, cacheItemPolicy);
        }


        /// <summary>
        /// Checks if cache has value
        /// </summary>
        /// <param name="keyName">cache keyname</param>
        /// <returns>bool</returns>
        public bool HasValue(string keyName)
        {
            return _cache.HasValue(keyName);
        }


    }
}
