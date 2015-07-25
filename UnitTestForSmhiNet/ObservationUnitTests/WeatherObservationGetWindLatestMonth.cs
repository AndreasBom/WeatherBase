using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationGetWindLatestMonths
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
        public void GetWindLatestMonths_TDD()
        {
            var windObj = weather.GetWindLatestMonths(4);
            
            Assert.IsNotNull(windObj);
        }


        [TestMethod]
        public void GetWindLatestDay_Count_returnValue()
        {
            var windObj = weather.GetWindLatestMonths(4);

            var count = windObj.Count();

            Assert.AreEqual(count, 30);
        }





    }
}
