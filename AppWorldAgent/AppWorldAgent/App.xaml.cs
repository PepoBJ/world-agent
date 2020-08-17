using AppWorldAgent.Infrastructure.Services.Settings;
using AppWorldAgent.Services.Navigation;
using AppWorldAgent.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppWorldAgent
{
    public partial class App : Application
    {
        ISettingsService _settingsService;

        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "RadioButton_Experimental" });
            InitApp();

            if (Device.RuntimePlatform == Device.UWP)
            {
                InitNavigation();
            }
            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
        }

        

        private void InitApp()
        {
            _settingsService = LocatorViewModel.Resolve<ISettingsService>();
            if (!_settingsService.UseMocks)
                LocatorViewModel.UpdateDependencies(_settingsService.UseMocks);
        }

        private Task InitNavigation()
        {
            var navigationService = LocatorViewModel.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected async override void OnStart()
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                await InitNavigation();
            }

            base.OnResume();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
