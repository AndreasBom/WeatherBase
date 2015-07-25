using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetTempLatestHourUnitTest
    {
        private IWeatherObservation _weatherObservation;
        private IEnumerable<ObservationModel> _tempObj;
            
        [TestInitialize]
        public void Init()
        {
            _weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            _tempObj = _weatherObservation.GetTempLatestHour(65954);
        }

        [TestMethod]
        public void GetTempLatestHour_TDD()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var temp = weatherObservation.GetTempLatestHour(85456);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void GetTempLatestHour_Counting_ReturnValue()
        {
            var count = _tempObj.Count();

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void GetTempLatestHour_Assert_Value()
        {
            var value = (from t in _tempObj select t.Value).First();

            Assert.AreEqual(value, 9.0);
        }
    }
}
