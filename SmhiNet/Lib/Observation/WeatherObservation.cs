using System.Collections.Generic;
using SmhiNet.Interfaces;
using SmhiNet.Models;
using SmhiNet.Repositories;

namespace SmhiNet.Lib.Observation
{
    public class WeatherObservation : IWeatherObservation
    {
        private readonly IWeatherObservation _weatherobservationRepository;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public WeatherObservation() : this(new WeatherObservationRepository())
        {
        }

        /// <summary>
        ///     Constructor injection
        /// </summary>
        /// <param name="weatherObservation">Object that retrives weather data</param>
        public WeatherObservation(IWeatherObservation weatherObservation)
        {
            _weatherobservationRepository = weatherObservation;
        }

        /// <summary>
        ///     Gets list of parameters. The data is saved in cache memory for 60 minutes
        /// </summary>
        /// <returns>IEnumerable ParameterModel</returns>
        public IEnumerable<ParameterModel> GetParameters()
        {
            return _weatherobservationRepository.GetParameters();
        }

        /// <summary>
        /// Gets a list of stations for a specified parameter. The data is saved in cache memory for 60 minutes
        /// </summary>
        /// <param name="parameter">int parameter</param>
        /// <returns>IEnumerable WeatherStationModel</returns>
        public IEnumerable<WeatherStationModel> GetWeatherStations(int parameter)
        {
            return _weatherobservationRepository.GetWeatherStations(parameter);
        }


        /// <summary>
        /// Gets on object with data based on wind observation lates hour
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindLatestHour(int stationId)
        {
            return _weatherobservationRepository.GetWindLatestHour(stationId);
        }


        /// <summary>
        /// Gets on object with data based on wind observation lates day
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindLatestDay(int stationId)
        {
            return _weatherobservationRepository.GetWindLatestDay(stationId);
        }


        /// <summary>
        /// Gets on object with data based on wind observation lates month
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindLatestMonths(int stationId)
        {
            return _weatherobservationRepository.GetWindLatestMonths(stationId);
        }


        /// <summary>
        /// Gets on object with data based on wind direction observation lates hour
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindDirLatestHour(int stationId)
        {
            return _weatherobservationRepository.GetWindDirLatestHour(stationId);
        }

        /// <summary>
        /// Gets on object with data based on wind direction observation lates day
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindDirLatestDay(int stationId)
        {
            return _weatherobservationRepository.GetWindDirLatestDay(stationId);
        }

        /// <summary>
        /// Gets on object with data based on wind direction observation lates months
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWindDirLatestMonth(int stationId)
        {
            return _weatherobservationRepository.GetWindDirLatestMonth(stationId);
        }


        /// <summary>
        /// Gets on object with data based on temperature observation lates hour
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetTempLatestHour(int stationId)
        {
            return _weatherobservationRepository.GetTempLatestHour(stationId);
        }

        /// <summary>
        /// Gets on object with data based on temperature observation lates day
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetTempLatestDay(int stationId)
        {
            return _weatherobservationRepository.GetTempLatestDay(stationId);
        }

        /// <summary>
        /// Gets on object with data based on temperature observation lates months
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetTempLatestMonths(int stationId)
        {
            return _weatherobservationRepository.GetTempLatestMonths(stationId);
        }


        /// <summary>
        /// Gets on object with data based on mean temperature observation lates day
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetMeanTempLatestDay(int stationId)
        {
            return _weatherobservationRepository.GetMeanTempLatestDay(stationId);
        }

        /// <summary>
        /// Gets on object with data based on mean temperature observation lates months
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetMeanTempLatestMonths(int stationId)
        {
            return _weatherobservationRepository.GetMeanTempLatestMonths(stationId);
        }

        /// <summary>
        /// Gets on object with data based on max temperature observation lates day
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetMaxTempLatestDay(int stationId)
        {
            return _weatherobservationRepository.GetMaxTempLatestDay(stationId);
        }

        /// <summary>
        /// Gets on object with data based on max temperature observation lates months
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetMaxTempLatestMonths(int stationId)
        {
            return _weatherobservationRepository.GetMaxTempLatestMonths(stationId);
        }

        /// <summary>
        /// Gets on object with data based on min temperature observation lates day
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetMinTempLatestDay(int stationId)
        {
            return _weatherobservationRepository.GetMinTempLatestDay(stationId);
        }

        /// <summary>
        /// Gets on object with data based on min temperature observation lates months
        /// </summary>
        /// <param name="stationId">Id of the weather station </param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetMinTempLatestMonths(int stationId)
        {
            return _weatherobservationRepository.GetMinTempLatestMonths(stationId);
        }

        /// <summary>
        /// Weather observation latest hour.
        /// </summary>
        /// <param name="parameter">int parameter</param>
        /// <param name="stationId">int stationId</param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWeatherLatestHour(int parameter, int stationId)
        {
            IEnumerable<ObservationModel> weather = new List<ObservationModel>();
            switch (parameter)
            {
                case 1:
                    weather = GetTempLatestHour(stationId);
                    break;
                case 3:
                    weather = GetWindDirLatestHour(stationId);
                    break;
                case 4:
                    weather = GetWindLatestHour(stationId);
                    break;
            }
            return weather;
        }


        /// <summary>
        /// Weather observation latest hour.
        /// </summary>
        /// <param name="parameter">int parameter</param>
        /// <param name="stationId">int stationId</param>
        /// <returns>IEnumerable ObservationModel</returns>
        public IEnumerable<ObservationModel> GetWeatherLatestDay(int parameter, int stationId)
        {
            IEnumerable<ObservationModel> weather = new List<ObservationModel>();
            switch (parameter)
            {
                case 1:
                    weather = GetTempLatestDay(stationId);
                    break;
                case 2:
                    weather = GetMeanTempLatestDay(stationId);
                    break;
                case 3:
                    weather = GetWindDirLatestDay(stationId);
                    break;
                case 4:
                    weather = GetWindLatestDay(stationId);
                    break;
                case 19:
                    weather = GetMinTempLatestDay(stationId);
                    break;
                case 20:
                    weather = GetMaxTempLatestDay(stationId);
                    break;
            }
            return weather;
        }
    }
}