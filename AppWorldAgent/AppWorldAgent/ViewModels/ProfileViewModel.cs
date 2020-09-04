namespace AppWorldAgent.ViewModels
{
    using AppWorldAgent.Infrastructure.Globalization;
    using AppWorldAgent.Infrastructure.Services.Settings;
    using AppWorldAgent.Models;
    using System.Threading.Tasks;

    public class ProfileViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;

        #region Properties
        public ProfileModel _profileModel;
        public ProfileModel ProfileModel
        {
            get { return _profileModel; }
            set { _profileModel = value; RaisePropertyChanged(() => ProfileModel); }
        }
        #endregion

        #region Constructor
        public ProfileViewModel(ISettingsService settingsService)
        {
            Title = DisplayInformation.Profile;
            _settingsService = settingsService;
            _profileModel = new ProfileModel();
            ProfileModel.Name = _settingsService.UserName;
            ProfileModel.LastName = _settingsService.UserLastName;
            ProfileModel.UserType = _settingsService.UserType;
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
