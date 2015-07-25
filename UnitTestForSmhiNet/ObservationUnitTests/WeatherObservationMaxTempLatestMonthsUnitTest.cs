using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationMaxTempLatestMonthsUnitTest
    {
        [TestMethod]
        public void GetMaxTempLatestMonths_TDD()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMaxTempLatestMonths(77777);

            Assert.IsNotNull(data);
        }


        [TestMethod]
        public void GetMaxTempLatestMonths_Counting_ReturnValues()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMaxTempLatestMonths(77777).Count();

            Assert.AreEqual(data, 130);
        }


        [TestMethod]
        public void GetMaxTempLatestMonths_Assert_ReturnValues()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMaxTempLatestMonths(77777).Select(p=>p.Value).First();

            Assert.AreEqual(data, 2,6);
        }
    }
}
