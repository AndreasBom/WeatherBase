using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmhiNet.Lib.Observation;
using SmhiNet.Models;

namespace SmhiDemo.Models
{
    public class Sanitized
    {
        private WeatherObservation _weatherObservation;

        public WeatherObservation WeatherObservation
        {
            get { return _weatherObservation ?? (_weatherObservation = new WeatherObservation()); }
        }
        
        
        public IEnumerable<ParameterModel> SanitizedParameters()
        {
            List<ParameterModel> sanitizedParameters = new List<ParameterModel>(6);
            
            var parameters = WeatherObservation.GetParameters();

            sanitizedParameters.AddRange(parameters.Where(para => para.Key == 1 || para.Key == 2 || para.Key == 3 || para.Key == 4 || para.Key == 19 || para.Key == 20));

            return sanitizedParameters;
        }  
    }
}
