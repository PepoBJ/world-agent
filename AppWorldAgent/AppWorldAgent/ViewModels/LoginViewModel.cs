namespace AppWorldAgent.ViewModels
{
    using AppWorldAgent.Infrastructure;
    using AppWorldAgent.Infrastructure.Globalization;
    using AppWorldAgent.Infrastructure.Models.Enum;
    using AppWorldAgent.Infrastructure.Models.User;
    using AppWorldAgent.Infrastructure.Services.Settings;
    using AppWorldAgent.Infrastructure.Validations;
    using AppWorldAgent.Services.Criteria;
    using AppWorldAgent.Services.DataAccess.Identity;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class LoginViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly IIdentityService _identityService;

        #region Properties
        private ValidatableObject<string> _userName;
        public ValidatableObject<string> UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
                RaisePropertyChanged(() => IsPassword);
            }
        }

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }



        public bool _isPassword = false;
        public bool IsPassword
        {
            get { return _isPassword; }
            set { _isPassword = value; RaisePropertyChanged(() => IsPassword); }
        }


        #endregion

        #region Constructor
        public LoginViewModel(ISettingsService settingsService, IIdentityService identityService)
        {
            Title = "Login";
            _settingsService = settingsService;
            _identityService = identityService;

            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }
        #endregion

        #region Initialize
        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is LogoutParameter logoutParameter)
            {
                if (logoutParameter.Logout)
                {
                    _settingsService.AccessToken = string.Empty;
                    _settingsService.UserName = string.Empty;
                    _settingsService.UserLastName = string.Empty;
                    _settingsService.UserType = string.Empty;
                }
            }

            return base.InitializeAsync(navigationData);
        }
        #endregion

        #region Command
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());
        public ICommand SignInCommand => new Command(async () => await SignInAsync());
        public ICommand ToggleIsPasswordServicesCommand => new Command(async () => await ToggleIsPasswordServicesasync());

        private async Task ToggleIsPasswordServicesasync()
        {
            await Task.Delay(10);
        }
        #endregion

        #region Sign In Async

        private async Task SignInAsync()
        {
            DialogService.ShowLoading(DisplayInformation.SignInInit);
            try
            {
                if (Validate())
                {
                    UserCredentialCriteria criteria = new UserCredentialCriteria
                    {
                        UserName = UserName.Value,
                        Password = Password.Value,
                    };

                    var result = await _identityService.SignInAsync(criteria);
                    if (result.Successful)
                    {
                        _settingsService.AccessToken = result.AccessToken;
                        _settingsService.UserName = result.UserName;
                        _settingsService.UserLastName = result.UserLastName;
                        _settingsService.UserType = result.UserType;
                        GlobalSetting.Instance.BaseEndpoint = _settingsService.UrlBase = result.URLService.ToString();
                        await NavigationService.NavigateToAsync<MainViewModel>();
                    }
                    else
                    {
                        DialogService.ShowToast($"Sign In \nDetalle:{result.Errors[0]} ", ToastConfigEnum.Error);
                    }
                }
                else
                {
                    if (!_settingsService.UseMocks)
                        DialogService.ShowToast(DisplayInformation.NetworkAccessMessage, ToastConfigEnum.Warning);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowToast($"Sign In Error \nDetalle : {ex.Message}", ToastConfigEnum.Error);
            }

            DialogService.HideLoading();
        }
        #endregion

        #region Methods
        private bool Validate() => (ValidateUserName() && ValidatePassword());
        private bool ValidateUserName() => _userName.Validate();
        private bool ValidatePassword() => _password.Validate();


        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = DisplayInformation.NameIsRequired });
            _userName.Validations.Add(new StringLengthValidateRule<string> { ValidationMessage = DisplayInformation.MaxLength, Length = 15 });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = DisplayInformation.PasswordIsRequired });
        }

        #endregion

    }
}
