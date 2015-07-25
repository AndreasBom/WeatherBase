using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Interfaces;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class ObservationWithNullValues
    {
        [TestMethod]
        public void GetDate_Has_Null()
        {
            var weatherObservation = new FakeWeatherObservationRepository();

            var data = weatherObservation.GetNulls();

            Assert.IsNotNull(data);
            
        }


        [TestMethod]
        public void GetDate_Has_Null_Check_Model()
        {
            var weatherObservation = new FakeWeatherObservationRepository();

            var data = weatherObservation.GetNulls();


            Assert.IsNotNull(data);

        }
    }
}
