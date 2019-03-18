using System.Windows;
using DryIoc;
using _52North.Model.ViewModels;
using _52North.Wpf.Views;

namespace _52North.Wpf
{
    public partial class App : Application
    {

        public App()
        {
            var container = CreateContainer();

            var mainWindow = container.Resolve<MainWindowView>();
            mainWindow?.Show();
        }

        private static IContainer CreateContainer()
        {
            var container = new Container();

            // View Models
            container.Register<MainWindowViewModel>();
            
            // Views
            container.Register(made: Made.Of(() => new MainWindowView(Arg.Of<MainWindowViewModel>())));

            return container;
        }

    }
}
