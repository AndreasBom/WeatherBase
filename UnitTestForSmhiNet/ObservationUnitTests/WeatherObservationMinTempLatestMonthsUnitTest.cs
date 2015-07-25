using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationMinTempLatestMonthsUnitTest
    {
        [TestMethod]
        public void GetMinTempLatestMonths_TDD()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMinTempLatestMonths(56565);

            Assert.IsNotNull(data);
        }


        [TestMethod]
        public void GetMinTempLatestMonths_Counting_ReturnValues()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMinTempLatestMonths(56565).Count();

            Assert.AreEqual(data,130);
        }


        [TestMethod]
        public void GetMinTempLatestMonths_Assert_ReturnValue()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var data = weatherObservation.GetMinTempLatestMonths(56565).Select(p=>p.Value).First();

            Assert.AreEqual(data, -4,5);
        }

    }
}
