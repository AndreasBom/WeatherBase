using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetTempLatestDayUnitTest
    {
        private IWeatherObservation _weatherObservation;


        [TestInitialize]
        public void Init()
        {
            _weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

        }

        [TestMethod]
        public void GetTempLatestDay_TDD()
        {
            var tempObj = _weatherObservation.GetTempLatestDay(75255);

            Assert.IsNotNull(tempObj);
        }


        [TestMethod]
        public void GetTempLatestDay_Counting_ReturnValues()
        {
            var tempObj = _weatherObservation.GetTempLatestDay(75255);

            var count = tempObj.Count();

            Assert.AreEqual(count, 24);
        }


        [TestMethod]
        public void GetTempLatestDay_Counting_Assert_Value()
        {
            var tempObj = _weatherObservation.GetTempLatestDay(75255);

            var temp = (from t in tempObj select t.Value).First();

            Assert.AreEqual(temp, 10.0);
        }



    }
}
