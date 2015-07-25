using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetTempLatestMonthsUnitTest
    {
        [TestMethod]
        public void GetTempLatestMonths_TDD()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetTempLatestMonths(45654);

            Assert.IsNotNull(tempObj);
        }

        [TestMethod]
        public void GetTempLatestMonth_Counting_ReturnValue()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetTempLatestMonths(544540);

            var count = tempObj.Count();

            Assert.AreEqual(count, 3036);
        }


        [TestMethod]
        public void GetTempLatestMonth_Counting_Assert_Value()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetTempLatestMonths(544540);

            var value = (from t in tempObj select t.Value).First();

            Assert.AreEqual(value, 11.0);
        }
    }
}
