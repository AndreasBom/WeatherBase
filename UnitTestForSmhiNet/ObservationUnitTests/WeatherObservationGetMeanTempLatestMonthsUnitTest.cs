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
    public class WeatherObservationGetMeanTempLatestMonthsUnitTest
    {
        private IWeatherObservation _weatherObservation;
        private IEnumerable<ObservationModel> _temp;

        [TestInitialize]
        public void Init()
        {
            _weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());
            _temp = _weatherObservation.GetMeanTempLatestMonths(56789);
        }
            
        [TestMethod]
        public void GetMeanTempLatestMonths_TDD()
        {
            var weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());
            var temp = weatherObservation.GetMeanTempLatestMonths(15655);

            Assert.IsNotNull(temp);

        }


        [TestMethod]
        public void GetMeanTempLatestMonths_Counting_ReturnValues()
        {
            var count = _temp.Count();

            Assert.AreEqual(count, 130);
        }


        [TestMethod]
        public void GetMeanTempLatestMonths_Assert_ReturnValues()
        {
            var temp = (from t in _temp select t.Value).First();

            Assert.AreEqual(temp, 0,7);
        }


    }
}
