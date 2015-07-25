using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetMaxTempLatestDayUnitTest
    {
        [TestMethod]
        public void GetMaxTempLatestDay_TDD()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetMaxTempLatestDay(44454);

            Assert.IsNotNull(tempObj);
        }


        [TestMethod]
        public void GetMaxTempLatestDay_Counting_ReturnValues()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetMaxTempLatestDay(44454).Count();


            Assert.AreEqual(tempObj, 1);
        }



        [TestMethod]
        public void GetMaxTempLatestDay_Assert_ReturnValues()
        {
            IWeatherObservation weatherObservation = new WeatherObservation(new FakeWeatherObservationRepository());

            var tempObj = weatherObservation.GetMaxTempLatestDay(44454).Select(p=>p.Value).First();


            Assert.AreEqual(tempObj, 11,3);
        }

    }
}
