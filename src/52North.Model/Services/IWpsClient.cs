using _52North.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _52North.Model.Services
{
    public interface IWpsClient : IDisposable
    {

        Task<IReadOnlyList<ProcessSummary>> GetServiceProcesses(string url);

    }
}
