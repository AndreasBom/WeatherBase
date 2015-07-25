using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetMeanTempLatestDay
    {
        [TestMethod]
        public void GetMeanTempLatestDay_TDD()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetMeanTempLatestDay(17055);

            Assert.IsNotNull(tempObj);
        }

        [TestMethod]
        public void GetMeanTempLatestDay_Count_Values()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetMeanTempLatestDay(5555);

            var count = tempObj.Count();

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void GetMeanTempLatestDay_Assert_ReturnValue()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetMeanTempLatestDay(55555);

            var value = (from t in tempObj select t.Value).First();

            Assert.AreEqual(value, 8.0);
        }
        
    }
}
