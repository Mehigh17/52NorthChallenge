using _52North.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _52North.Model.Services
{
    public interface IWpsClient : IDisposable
    {

        /// <summary>
        /// Fetch all the process summaries from a WPS running v2.0.0.
        /// </summary>
        /// <param name="url">The WPS url</param>
        /// <returns>A list of processes</returns>
        Task<IReadOnlyList<ProcessSummary>> GetServiceProcesses(string url);

    }
}
