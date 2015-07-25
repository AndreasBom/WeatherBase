using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SmhiNet.Interfaces
{
    /// <summary>
    /// Interface for fetching json data from a REST service
    /// </summary>
    internal interface IHttpFetcher
    {
        JObject JsonFetcher(string  baseApiUrl, string apiUrl);
    }
}
