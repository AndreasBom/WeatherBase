using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Forcast;
using SmhiNet.Interfaces;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ForcastUnitTests
{
    [TestClass]
    public class GetForcastUnitTest
    {
        [TestMethod]
        public void GetForcast_TDD()
        {
            var injection = new FakeWeatherForcastRepository();
            IWeatherForcast forcast= new WeatherForcast(injection);
            

            Assert.IsNotNull(forcast);
        }

        [TestMethod]
        public void GetForcast_Counting_ReturnValue()
        {
            var injection = new FakeWeatherForcastRepository();
            IWeatherForcast forcast = new WeatherForcast(injection);
            
            var count = forcast.GetForcast(34.44, 234.34).Count();

            Assert.AreEqual(count, 70);
        }


        [TestMethod]
        public void GetForcast_Assert_ReturningValue()
        {
            var weather = new WeatherForcast(new FakeWeatherForcastRepository());
            var forcast = weather.GetForcast(88.44, 85.55).AsQueryable();

            Assert.AreEqual(forcast.Select(s => s.ApprovedTime).First().ToString(), "2015-05-01 05:10:39");
            Assert.AreEqual(forcast.Select(s=>s.MSL).First(), 1008.0);
            Assert.AreEqual(forcast.Select(m=>m.SPP).First(), -9);
            Assert.AreEqual(forcast.Select(m=>m.PMEDIAN).First(), 0);
        }
    }
}
