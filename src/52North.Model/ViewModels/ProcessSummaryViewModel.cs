namespace _52North.Model.ViewModels
{
    public class ProcessSummaryViewModel : ViewModelBase
    {

        private string _title;
        private string _identifier;
        private string _version;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string Identifier
        {
            get => _identifier;
            set => Set(ref _identifier, value);
        }

        public string Version
        {
            get => _version;
            set => Set(ref _version, value);
        }

    }
}
