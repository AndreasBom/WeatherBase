using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Services;
using UnitTestForSmhiNet.FakesRepositories;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace UnitTestForSmhiNet.MiscUnitTests
{
    [TestClass]
    public class CachedDataUnitTest
    {
        [TestMethod] 
        public void SetCachedData_TDD_CreateMethod_SetCache_GetCache()
        {
            //Arrange
            var cache = new CachedData(new FakeCachedData());
            string inCache = "ThisIsCache";
            string keyName = "key";

            //Act
            cache.SetCache(keyName, inCache, 50);
            var getCacheValue = cache.GetCache(keyName);
            
            //Assert
            Assert.AreEqual(inCache, getCacheValue);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))] //Switch to ArgumentNullException in real app
        public void GetCache_UnKnown_Value()
        {
            //Arrange
            var cache = new CachedData(new FakeCachedData());
            
            //Act
            cache.GetCache("Fail");

            //Assert
        }

    }
}
