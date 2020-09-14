using AppWorldAgent.Infrastructure.Globalization;
using AppWorldAgent.Infrastructure.Models.Enum;
using AppWorldAgent.Infrastructure.Services.Settings;
using AppWorldAgent.Infrastructure.Validations;
using AppWorldAgent.Services.Criteria;
using AppWorldAgent.Services.DataAccess.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppWorldAgent.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly IIdentityService _identityService;


        #region Properties
        private ValidatableObject<string> _firstName;
        public ValidatableObject<string> FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged(() => FirstName);
            }
        }

        private ValidatableObject<string> _lastName;
        public ValidatableObject<string> LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(() => LastName); }
        }

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(() => Email); }
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
        public RegisterViewModel(ISettingsService settingsService, IIdentityService identityService)
        {
            Title = "Registro";
            _settingsService = settingsService;
            _identityService = identityService;
            _firstName = new ValidatableObject<string>();
            _lastName = new ValidatableObject<string>();
            _email = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            AddValidations();
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

        #region Command
        public ICommand ValidateFirstNameCommand => new Command(() => ValidateFirstName());
        public ICommand ValidateLastNameCommand => new Command(() => ValidateLastName());
        public ICommand ValidateEmailCommand => new Command(() => ValidateEmail());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());
        public ICommand SignInCommand => new Command(async () => await NavigationService.NavigateToAsync<LoginViewModel>());
        public ICommand RegisterCommand => new Command(async () => await RegisterAsync());

        #endregion

        #region Methods
        private async Task RegisterAsync()
        {
            bool isValid = Validate();
            try
            {
                this.IsBusy = true;
                if (isValid)
                {
                    await Task.Delay(20);

                    RegisterUserCriteria criteria = new RegisterUserCriteria
                    {
                        FirstName = FirstName.Value,
                        LastName = LastName.Value,
                        Email = Email.Value,
                        Password = Password.Value
                    };

                    var result = await _identityService.RegisterAsync(criteria);

                    if (result.Successful)
                    {
                        _settingsService.UserName = result.Data.FirstName;
                        _settingsService.UserLastName = result.Data.LastName;

                        var resultToken = await _identityService.SignInAsync(new UserCredentialCriteria { Email = Email.Value, Password = Password.Value });

                        if (resultToken.Successful)
                        {
                            _settingsService.AuthAccessToken = resultToken.AccessToken;
                            await NavigationService.NavigateToAsync<MainViewModel>();
                        }
                    }
                    else
                    {
                        DialogService.ShowToast($"Register Error \n {result.Errors.FirstOrDefault()}", ToastConfigEnum.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowToast(ex.Message, ToastConfigEnum.Warning);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private bool Validate() => (ValidateFirstName() && ValidatePassword() && ValidateLastName() && ValidateEmail());
        private bool ValidateFirstName() => _firstName.Validate();
        private bool ValidateLastName() => LastName.Validate();
        private bool ValidateEmail() => _email.Validate();
        private bool ValidatePassword() => _password.Validate();


        private void AddValidations()
        {
            _firstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = DisplayInformation.NameIsRequired });
            _firstName.Validations.Add(new StringMinLength<string> { ValidationMessage = DisplayInformation.MinLength, Length = 5 });
            _firstName.Validations.Add(new StringLengthValidateRule<string> { ValidationMessage = DisplayInformation.MaxLength, Length = 100 });

            _lastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = DisplayInformation.LastNameIsRequired });
            _lastName.Validations.Add(new StringMinLength<string> { ValidationMessage = DisplayInformation.MinLength, Length = 5 });
            _lastName.Validations.Add(new StringLengthValidateRule<string> { ValidationMessage = DisplayInformation.MaxLength, Length = 100 });

            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = DisplayInformation.EmailIsRequired });
            _email.Validations.Add(new StringMinLength<string> { ValidationMessage = DisplayInformation.MinLength, Length = 5 });
            _email.Validations.Add(new StringLengthValidateRule<string> { ValidationMessage = DisplayInformation.MaxLength, Length = 100 });
            _email.Validations.Add(new EmailValidationRule<string> { ValidationMessage = DisplayInformation.EmailAddressFailed });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = DisplayInformation.PasswordIsRequired });
            _password.Validations.Add(new StringMinLength<string> { ValidationMessage = DisplayInformation.MinLength, Length = 8 });
            _password.Validations.Add(new StringLengthValidateRule<string> { ValidationMessage = DisplayInformation.MaxLength, Length = 100 });
        }

        #endregion
    }
}
