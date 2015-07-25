using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetMinTempLatestDayUnitTest
    {
        [TestMethod]
        public void GetMinTempLatestDay_TDD()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMinTempLatestDay(65458);

            Assert.IsNotNull(data);
        }


        [TestMethod]
        public void GetMinTempLatestDay_Counting_ReturnValues()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMinTempLatestDay(65458).Count();

            Assert.AreEqual(data, 1);
        }


        [TestMethod]
        public void GetMinTempLatestDay_Assert_ReturnValues()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMinTempLatestDay(65458).Select(p => p.Value).First();

            Assert.AreEqual(data, 7,2);
        }
    }
}
