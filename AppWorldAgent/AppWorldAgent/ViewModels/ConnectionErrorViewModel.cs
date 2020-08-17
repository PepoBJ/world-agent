using AppWorldAgent.Infrastructure.Services.Settings;

namespace AppWorldAgent.ViewModels
{
    public class ConnectionErrorViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;
        public ConnectionErrorViewModel(ISettingsService settingsService)
        {
            Title = "Test";
            _settingsService = settingsService;
        }
    }
}
