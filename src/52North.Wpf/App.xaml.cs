using _52North.Model.Services;
using _52North.Model.ViewModels;
using _52North.Wpf.Views;
using DryIoc;
using System.Windows;

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

            // Services
            container.Register<IWpsClient, WpsClient>(Reuse.Singleton);

            // View Models
            container.Register<MainWindowViewModel>();
            
            // Views
            container.Register(made: Made.Of(() => new MainWindowView(Arg.Of<MainWindowViewModel>())));

            return container;
        }

    }
}
