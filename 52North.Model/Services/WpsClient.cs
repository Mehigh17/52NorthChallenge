using _52North.Model.Exceptions;
using _52North.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace _52North.Model.Services
{
    public class WpsClient : IWpsClient
    {

        private readonly HttpClient _httpClient;

        public WpsClient()
        {
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<IReadOnlyList<ProcessSummary>> GetServiceProcesses(string url, string version)
        {
            var uriBuilder = new UriBuilder(url);
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["service"] = "WPS";
            parameters["version"] = version;
            parameters["request"] = "GetCapabilities";
            uriBuilder.Query = parameters.ToString();

            var response = await _httpClient.GetAsync(uriBuilder.Uri);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var xmlSerializer = new XmlSerializer(typeof(ProcessSummaryCollection));

                using (var reader = new StringReader(data))
                {
                    var str = reader.ToString();
                    var processCollection = xmlSerializer.Deserialize(reader) as ProcessSummaryCollection;
                    return processCollection.Processes;
                }
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotImplemented:
                    throw new WpsApiNotImplementedException();
                case HttpStatusCode.BadRequest:
                    throw new WpsApiBadRequestException($"Unexpected response from the API. ({response.ReasonPhrase})");
            }

            return null;
        }

    }
}
