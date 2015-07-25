using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GeoCode
{
    /// <summary>
    /// Using google geocoordinats API to retrive geocode from city or address
    /// </summary>
    public class GeoCoordinates
    {
        private static readonly string BaseUrl = @"https://maps.googleapis.com/maps/api/geocode/json?address=";
        private static string ApiKey;

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get { return "Sweden"; } set { value = Country; } }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">Your google api-key</param>
        public GeoCoordinates(string apiKey)
        {
            ApiKey = apiKey;
            
        }

        /// <summary>
        /// Translates city, or address to coordinates 
        /// </summary>
        public void AddressToCoordinates()
        {

            //Check if Api key exists
            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new Exception("No valid google api key");
            }

            //Request url 
            string url = String.Format("{0}, {1}, {2}, {3}, {4}&key={5}", StreetName, StreetNumber, PostalCode, City, Country, ApiKey);


            using (var client = new HttpClient())
            {
                //Read response
                var response = client.GetAsync(BaseUrl + url).Result;

                //Throws an exception if response is anything else than 200
                response.EnsureSuccessStatusCode();

                //Read response
                var content = response.Content.ReadAsStringAsync().Result;

                //Parse to JObject
                var jsonObj = JObject.Parse(content);

                //Assigning value to Latitude and Longitude
                Latitude = Math.Round((double)jsonObj["results"][0]["geometry"]["location"]["lat"], 6);
                Longitude = Math.Round((double)jsonObj["results"][0]["geometry"]["location"]["lng"], 6);

            }
        }
    }
}
