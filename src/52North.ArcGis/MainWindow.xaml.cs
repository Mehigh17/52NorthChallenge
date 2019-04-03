using _52North.Model.ViewModels;

namespace _52North.ArcGis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ArcGIS.Desktop.Framework.Controls.ProWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MainWindowViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }

    }
}
