using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetWindLatestDayUnitTest
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
        public void GetWindLatestDay_TDD()
        {
            var windObj = weather.GetWindLatestDay(3212321);

            Assert.IsNotNull(windObj);
        }


        [TestMethod]
        public void GetWindLatestDay_Counting_returnValues()
        {
            var windObj = weather.GetWindLatestDay(4);

            var count = windObj.Count();

            Assert.AreEqual(count, 24);

        }
    }
}
