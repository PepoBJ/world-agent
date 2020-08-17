namespace AppWorldAgent.ViewModels
{
    using AppWorldAgent.Infrastructure;
    using AppWorldAgent.Infrastructure.Globalization;
    using AppWorldAgent.Infrastructure.Models.Enum;
    using AppWorldAgent.Infrastructure.Models.User;
    using AppWorldAgent.Infrastructure.Services.Dialog;
    using AppWorldAgent.Infrastructure.Services.Settings;
    using AppWorldAgent.Infrastructure.ViewModels;
    using AppWorldAgent.Services.Navigation;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class BaseViewModel : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        public readonly INavigationService NavigationService;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(() => Title); }
        }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; RaisePropertyChanged(() => IsValid); }
        }

        public BaseViewModel()
        {
            DialogService = LocatorViewModel.Resolve<IDialogService>();
            NavigationService = LocatorViewModel.Resolve<INavigationService>();
            GlobalSetting.Instance.BaseEndpoint = LocatorViewModel.Resolve<ISettingsService>().UrlBase;
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public async Task LogoutAsync()
        {
            DialogService.ShowToast(DisplayInformation.MessageLogout, ToastConfigEnum.Error);
            await NavigationService.NavigateToAsync<LoginViewModel>(new LogoutParameter { Logout = true });
        }

        public async Task LogoutAsync(LogoutParameter parameter)
        {
            if (parameter.Logout)
            {
                DialogService.ShowToast(parameter.Message, ToastConfigEnum.Error);
                await NavigationService.NavigateToAsync<LoginViewModel>(parameter);
            }
            else
            {
                if (!string.IsNullOrEmpty(parameter.Message))
                    DialogService.ShowToast(parameter.Message, ToastConfigEnum.Error);
            }
        }

        /// <summary>
        /// LogoutMaterAsync
        /// </summary>
        /// <returns></returns>
        private async Task LogoutMaterAsync()
        {
            IsBusy = true;

            // Logout
            await NavigationService.NavigateToAsync<LoginViewModel>(new LogoutParameter { Logout = true });

            IsBusy = false;
        }

        #region Command
        public ICommand HomeCommand => new Command(async () => await NavigationService.NavigatePopToRootAsync());
        public ICommand LogoutCommand => new Command(async () => await LogoutMaterAsync());

        #endregion
    }
}
