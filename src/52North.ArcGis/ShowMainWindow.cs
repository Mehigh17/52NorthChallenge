using _52North.Model.Services;
using _52North.Model.ViewModels;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using DryIoc;

namespace _52North.ArcGis
{
    internal class ShowMainWindow : Button
    {

        private MainWindow _mainwindow = null;
        private readonly IContainer _container;

        public ShowMainWindow()
        {
            _container = CreateContainer();
        }

        protected override void OnClick()
        {
            //already open?
            if (_mainwindow != null)
                return;

            _mainwindow = _container.Resolve<MainWindow>();
            _mainwindow.Owner = FrameworkApplication.Current.MainWindow;
            _mainwindow.Closed += (o, e) => { _mainwindow = null; };
            _mainwindow.Show();
            //uncomment for modal
            //_mainwindow.ShowDialog();
        }

        /// <summary>
        /// Creates an IoC container and registers the needed services.
        /// </summary>
        private static IContainer CreateContainer()
        {
            var container = new Container();

            // Services
            container.Register<IWpsClient, WpsClient>(Reuse.Singleton);

            // View Models
            container.Register<MainWindowViewModel>();

            // Views
            container.Register(made: Made.Of(() => new MainWindow(Arg.Of<MainWindowViewModel>())));

            return container;
        }

    }
}
