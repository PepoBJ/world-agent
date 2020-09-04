namespace AppWorldAgent.ViewModels
{
    using AppWorldAgent.Infrastructure.Globalization;
    using AppWorldAgent.Infrastructure.Services.Settings;
    using System.Threading.Tasks;

    public class SettingsViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;

        #region Constructor
        public SettingsViewModel(ISettingsService settingsService)
        {
            Title = DisplayInformation.Settings;
            _settingsService = settingsService;
        }
        #endregion

        #region Initialize
        public override Task InitializeAsync(object navigationData)
        {
            this.IsBusy = true;

            this.IsBusy = false;

            return base.InitializeAsync(navigationData);
        }
        #endregion
    }
}
