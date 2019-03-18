using _52North.Model.ViewModels;
using System.Windows;

namespace _52North.Wpf.Views
{
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        public MainWindowView(MainWindowViewModel vm) : this()
        {
            DataContext = vm;
        }

    }
}
