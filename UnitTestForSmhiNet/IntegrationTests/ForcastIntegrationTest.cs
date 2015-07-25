using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Forcast;

namespace UnitTestForSmhiNet.IntegrationTests
{
    [TestClass]
    public class ForcastIntegrationTest
    {
        [TestMethod]
        public void GetForcast_TDD()
        {
            var weather = new WeatherForcast();

            var forcast = weather.GetForcast(57.999628, 16.017767);

            Assert.IsNotNull(forcast);
        }
        
    }
}
