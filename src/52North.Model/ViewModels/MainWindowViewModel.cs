using _52North.Model.Commands;
using _52North.Model.Exceptions;
using _52North.Model.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace _52North.Model.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private DelegateCommand _getProcessesCommand;
        private string _wpsServiceUrl;
        private string _status;
        private ProcessSummaryViewModel _selectedProcess;
        private bool _isFetchingData;

        public DelegateCommand GetProcessesCommand
        {
            get => _getProcessesCommand;
            set => Set(ref _getProcessesCommand, value);
        }
        public string WpsServiceUrl
        {
            get => _wpsServiceUrl;
            set => Set(ref _wpsServiceUrl, value);
        }
        public ProcessSummaryViewModel SelectedProcess
        {
            get => _selectedProcess;
            set => Set(ref _selectedProcess, value);
        }
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public ObservableCollection<ProcessSummaryViewModel> Processes { get; set; } = new ObservableCollection<ProcessSummaryViewModel>();

        private readonly IWpsClient _wpsClient;

        public MainWindowViewModel(IWpsClient wpsClient)
        {
            _wpsClient = wpsClient;

            WpsServiceUrl = "http://geoprocessing.demo.52north.org:8080/wps/WebProcessingService";

            GetProcessesCommand = new DelegateCommand(FetchWpsData, () => !_isFetchingData);
        }

        private async void FetchWpsData()
        {
            _isFetchingData = true;
            GetProcessesCommand.RaiseCanExecuteChanged();

            Status = "Fetching the process information...";

            try
            {
                var processes = await _wpsClient.GetServiceProcesses(WpsServiceUrl);

                var processesVm = processes.Select(p => new ProcessSummaryViewModel
                {
                    Title = p.Title,
                    Identifier = p.Identifier,
                    Version = p.Version
                });

                Processes.Clear();
                foreach (var vm in processesVm)
                {
                    Processes.Add(vm);
                }

                Status = string.Empty;
            }
            catch (WpsApiBadRequestException e)
            {
                Status = $"Bad request: {e.Message}";
            }
            catch (WpsApiNotImplementedException)
            {
                Status = $"Method not implemented.";
            }
            finally
            {
                _isFetchingData = false;
                GetProcessesCommand.RaiseCanExecuteChanged();
            }
        }

    }
}
