using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmhiNet.Interfaces;
using SmhiNet.Lib.Forcast;
using SmhiNet.Models;
using SmhiNet.Repositories.Base;

namespace SmhiNet.Repositories
{
    class WeatherForcastRepository : HttpClientFetcher, IWeatherForcast
    {
        private ICachedData _cachedData;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public WeatherForcastRepository()
            : this(new CachedDataRepository())
        {

        }

        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="cachedData"></param>
        public WeatherForcastRepository(ICachedData cachedData)
        {
            _cachedData = cachedData;

        }

        /// <summary>
        /// Checks for valid geo points
        /// </summary>
        /// <param name="latitude">double latitude</param>
        /// <param name="longitude">double longitude</param>
        /// <returns>Bool</returns>
        public bool HasValidGeoPoints(double latitude, double longitude)
        {
            const float maxLat = 70.67f;
            const float minLat = 52.50f;
            const float maxLng = 27.30f;
            const float minLng = 2.25f;

            if (latitude > minLat && latitude < maxLat &&
                longitude > minLng && longitude < maxLng)
                return true;

            return false;
        }

        /// <summary>
        /// Returns a list with forcast data for specified latitude and longitude
        /// </summary>
        /// <param name="latitude">double latitude</param>
        /// <param name="longitude">double longitude</param>
        /// <returns></returns>
        public IEnumerable<ForcastModel> GetForcast(double latitude, double longitude)
        {

            if (_cachedData.HasValue("forcast" + latitude + longitude))
            {
                return _cachedData.GetCache("forcast" + latitude + longitude) as IEnumerable<ForcastModel>;
            }
            else
            {
                var obj = FetchForcast(latitude, longitude);
                _cachedData.SetCache("forcast" + latitude + longitude, obj, CacheHeadersMaxAge);

                return obj;
            }

        }

        /// <summary>
        /// Returns a list with forcast data for specified latitude and longitude
        /// </summary>
        /// <param name="latitude">string latitude</param>
        /// <param name="longitude">string longitude</param>
        /// <returns></returns>
        public IEnumerable<ForcastModel> GetForcast(string latitude, string longitude)
        {

            if (_cachedData.HasValue("forcast" + latitude + longitude))
            {
                return _cachedData.GetCache("forcast" + latitude + longitude) as IEnumerable<ForcastModel>;
            }
            else
            {
                var obj = FetchForcast(latitude, longitude);
                _cachedData.SetCache("forcast" + latitude + longitude, obj, CacheHeadersMaxAge);

                return obj;
            }

        }


        
        

        private IEnumerable<ForcastModel> FetchForcast(double latitude, double longitude)
        {

            if (HasValidGeoPoints(latitude, longitude))
            {
                string url = String.Format("category/pmp2g/version/1/geopoint/lat/{0}/lon/{1}/data.json", latitude.ToString(CultureInfo.InvariantCulture), longitude.ToString(CultureInfo.InvariantCulture));

                var content = JsonFetcher(BaseForcastApiUrl, url);

                return PopulateForcastModel(content);
            }

            throw new ArgumentOutOfRangeException();
            
        }


        private IEnumerable<ForcastModel> FetchForcast(string latitude, string longitude)
        {
            //cutting length of decimals if >=8 and repleces punctuation with comma  
            var latString = latitude.Length >= 8 ? latitude.Substring(0, 8) : latitude;
            var latreplaced = latString.Replace(".", ",");
            var lat = Convert.ToDouble(latreplaced);

            var lngString = longitude.Length >= 8? longitude.Substring(0, 8): longitude;
            var lngreplaced = lngString.Replace(".", ",");
            var lng = Convert.ToDouble(lngreplaced);


            if (HasValidGeoPoints(lat, lng))
            {
                string url = String.Format("category/pmp2g/version/1/geopoint/lat/{0}/lon/{1}/data.json", lat.ToString(CultureInfo.InvariantCulture), lng.ToString(CultureInfo.InvariantCulture));

                var content = JsonFetcher(BaseForcastApiUrl, url);

                return PopulateForcastModel(content);
            }

            throw new ArgumentOutOfRangeException();

        }


        
    }
}
