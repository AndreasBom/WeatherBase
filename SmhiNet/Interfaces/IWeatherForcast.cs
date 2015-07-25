using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmhiNet.Models;

namespace SmhiNet.Interfaces
{

    /// <summary>
    /// Interface for getting forcast
    /// </summary>
    public interface IWeatherForcast
    {
        IEnumerable<ForcastModel> GetForcast(double latitude, double longitude);
        IEnumerable<ForcastModel> GetForcast(string latitude, string longitude);
    }
}
