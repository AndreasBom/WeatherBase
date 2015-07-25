using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmhiNet.Lib.Observation;
using UnitTestForSmhiNet.FakesRepositories;

namespace UnitTestForSmhiNet.ObservationUnitTests
{
    [TestClass]
    public class WeatherObservationParametersUnitTest
    {
        
        /// <summary>
        /// Testing the FakeWeatherObservationRepository that is going to be injected, is working
        /// </summary>
        [TestMethod]
        public void FakeWeatherObservationRepository_Method_GetParameterList()
        {
            //Arrange
            var weatherObj = new FakeWeatherObservationRepository();
            var parameters = weatherObj.GetParameters();
            var expectedKey = 17;

            //Act
            var parameterKey = (from key in parameters select key.Key).First();

            //Assert
            Assert.AreEqual(expectedKey, parameterKey);
        }


        /// <summary>
        /// WeatherObservation with fake injection
        /// 
        /// Test first key-value in json-file
        /// </summary>
        [TestMethod]
        public void WeatherObservation_Injected_Fake_MethodIs_GetParameterList_Assert_Live_and_Cache()
        {
            //Arrange
            var injectionWeather = new FakeCacheReturnsParameterModel();
            var injectionCache = new FakeCachedData();
            var weatherObj = new WeatherObservation(injectionWeather);
            

            
            ////Act
            var parametersNotCached = weatherObj.GetParameters().Select(model => model.Title).FirstOrDefault();
            
            var parametersFromCache = weatherObj.GetParameters().Select(model => model.Title).FirstOrDefault();



            //Assert
            Assert.AreNotEqual(parametersNotCached, parametersFromCache);

        }


        /// <summary>
        /// Counts all values in the result of GetParameterList
        /// </summary>
        [TestMethod]
        public void Injected_Fake_MethodIs_GetParameterList_ListOfValues_Count()
        {
            //Arrange
            var injectionWeather = new FakeWeatherObservationRepository();
            var weatherObj = new WeatherObservation(injectionWeather);
            
            var listOfValues = weatherObj.GetParameters();

            //Act
            var countValues = listOfValues.Count();



            //Assert
            Assert.AreEqual(20, countValues);

        }


        /// <summary>
        /// Method GetParameterList returns an IEnumerble(ParameterModel)
        /// Iterate throw all [key]-values and asserts each value. 
        /// </summary>
        [TestMethod]
        public void Injected_Fake_MethodIs_GetParameterList_ListOfValues_testAllKeyValues()
        {
            //Arrange
            var injectionWeather = new FakeWeatherObservationRepository();
            var weatherObj = new WeatherObservation(injectionWeather);

            var parameters = weatherObj.GetParameters().OrderBy(s=>s.Key);
            int count = 1;

            //Act &
            //Assert
            foreach (var parameter in parameters)
            {
                var temp = parameter.Key;
                Assert.AreEqual(temp, count++);
            }       
        }


        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public void GetParameterList_ParameterExpectedException_FakeHttpRequestException()
        {
            //Arrange
            var injection = new FakesRepositories.FakeData.FakeHttpRequestException();

            var weatherObj = new WeatherObservation(injection);
          

            //Assert
            weatherObj.GetParameters();

        }

    }
}
