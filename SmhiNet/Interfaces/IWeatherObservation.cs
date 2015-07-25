
using System.Collections.Generic;
using SmhiNet.Models;

namespace SmhiNet.Interfaces
{
    /// <summary>
    /// Interface for getting observations
    /// </summary>
    public interface IWeatherObservation
    {
        IEnumerable<ParameterModel> GetParameters();

        IEnumerable<WeatherStationModel> GetWeatherStations(int parameter);

        IEnumerable<ObservationModel> GetWindLatestHour(int stationId);
        IEnumerable<ObservationModel> GetWindLatestDay(int stationId);
        IEnumerable<ObservationModel> GetWindLatestMonths(int stationId);
        IEnumerable<ObservationModel> GetWindDirLatestHour(int stationId);
        IEnumerable<ObservationModel> GetWindDirLatestDay(int stationId);
        IEnumerable<ObservationModel> GetWindDirLatestMonth(int stationId);

        IEnumerable<ObservationModel> GetTempLatestHour(int stationId);
        IEnumerable<ObservationModel> GetTempLatestDay(int stationId);
        IEnumerable<ObservationModel> GetTempLatestMonths(int stationId);
        IEnumerable<ObservationModel> GetMeanTempLatestDay(int stationId);

        IEnumerable<ObservationModel> GetMeanTempLatestMonths(int stationId);

        IEnumerable<ObservationModel> GetMaxTempLatestDay(int stationId);
        IEnumerable<ObservationModel> GetMaxTempLatestMonths(int stationId);

        IEnumerable<ObservationModel> GetMinTempLatestDay(int stationId);

        IEnumerable<ObservationModel> GetMinTempLatestMonths(int stationId);
    }
}
