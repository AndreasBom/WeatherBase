using System.Collections.Generic;
using SmhiNet.Interfaces;
using SmhiNet.Models;
using SmhiNet.Repositories;

namespace SmhiNet.Lib.Forcast
{
    public class WeatherForcast : IWeatherForcast
    {

        private IWeatherForcast _weatherForcast;

        /// <summary>
        /// Default constructor
        /// </summary>
        public WeatherForcast() : this(new WeatherForcastRepository())
        {
            
        }

        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="weatherForcast"></param>
        public WeatherForcast(IWeatherForcast weatherForcast)
        {
            _weatherForcast = weatherForcast;
        }


        /// <summary>
        /// Fetch forcast
        /// </summary>
        /// <param name="latitude">double latitude</param>
        /// <param name="longitude">double longitude</param>
        /// <returns>IEnumerable ForcastModel</returns>
        public IEnumerable<ForcastModel> GetForcast(double latitude, double longitude)
        {
            var forcast = _weatherForcast.GetForcast(latitude, longitude);
            return forcast;
        }

        /// <summary>
        /// Fetch forcast
        /// </summary>
        /// <param name="latitude">string latitude</param>
        /// <param name="longitude">string longitude</param>
        /// <returns></returns>
        public IEnumerable<ForcastModel> GetForcast(string latitude, string longitude)
        {
            return _weatherForcast.GetForcast(latitude, longitude);
        }
    }

}
