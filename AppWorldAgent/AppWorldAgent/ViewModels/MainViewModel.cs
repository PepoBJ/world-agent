using AppWorldAgent.Infrastructure.Services.Settings;

namespace AppWorldAgent.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;

        public MainViewModel(ISettingsService settingsService)
        {
            Title = "Inicio";
            _settingsService = settingsService;
        }
    }
}
