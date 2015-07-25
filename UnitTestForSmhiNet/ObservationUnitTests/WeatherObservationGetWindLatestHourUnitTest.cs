using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetWindLatestHourUnitTest
    {
        int nidingen = 71180;
        int parameter = 4;
        private IWeatherObservation weather;

        [TestInitialize]
        public void init()
        {
            weather = new FakeWeatherObservationRepository();

        }

        [TestMethod]
        public void GetWindLatestHour_TDD()
        {
            
            var windObj = weather.GetWindLatestHour(4);

            var count = windObj.Count();

            Assert.AreEqual(count, 1);

        }

        [TestMethod]
        public void GetWindLatestHour_check_for_IsNotNull_in_Model()
        {
            var windObj = weather.GetWindLatestHour(4);

            foreach (var val in windObj)
            {
                Assert.IsNotNull(val);
            }   
        }


    }
}
