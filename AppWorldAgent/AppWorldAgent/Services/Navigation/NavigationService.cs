namespace AppWorldAgent.Services.Navigation
{
    using AppWorldAgent.Infrastructure.Services.Settings;
    using AppWorldAgent.ViewModels;
    using AppWorldAgent.Views;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public class NavigationService : INavigationService
    {
        private readonly ISettingsService _settingsService;

        public BaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BaseViewModel;
            }
        }

        public NavigationService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Task InitializeAsync()
        {
            if (string.IsNullOrEmpty(_settingsService.AuthAccessToken))
                return NavigateToAsync<LoginViewModel>();
            else
                return NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            if (_settingsService.UseMocks)
                return InternalNavigateToAsync(typeof(TViewModel), null);
            else
            {
                if (typeof(TViewModel) == typeof(MainViewModel))
                    return InternalNavigateToAsync(typeof(TViewModel), null);
                return InternalNavigateToAsync(typeof(ConnectionErrorViewModel), null);
            }
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            if (_settingsService.UseMocks)
                return InternalNavigateToAsync(typeof(TViewModel), parameter);
            else
            {
                if (typeof(TViewModel) == typeof(MainViewModel))
                    return InternalNavigateToAsync(typeof(TViewModel), null);
                return InternalNavigateToAsync(typeof(ConnectionErrorViewModel), null);
            }
        }
        public async Task NavigatePopToRootAsync()
        {
            if (Application.Current.MainPage is CustomMasterView masterDetailPage)
            {
                if (masterDetailPage.Detail is CustomNavigationView mnavigationPage)
                    await mnavigationPage.PopToRootAsync();
            }
        }

        public Task RemoveLastFromBackStackAsync()
        {
            if (Application.Current.MainPage is CustomMasterView masterDetailPage)
            {
                if (masterDetailPage.Detail is CustomNavigationView mainPage)
                {
                    var navigationPages = mainPage.Navigation.NavigationStack.ToList();
                    navigationPages.Remove(mainPage.Navigation.NavigationStack.FirstOrDefault());
                    navigationPages.Remove(mainPage.Navigation.NavigationStack.LastOrDefault());

                    navigationPages.ForEach(page =>
                    {
                        mainPage.Navigation.RemovePage(page);
                    });
                }
            }

            return Task.FromResult(true);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);

            if (page is LoginView)
                Application.Current.MainPage = new LoginView();
            else if(page is RegisterView)
                Application.Current.MainPage = new RegisterView();
            else if (page is MainView)
                Application.Current.MainPage = new CustomMasterView(page);
            else if (Application.Current.MainPage is CustomMasterView masterDetailPage)
            {
                if (masterDetailPage.Detail is CustomNavigationView mnavigationPage)
                    await mnavigationPage.PushAsync(page);
                else
                    Application.Current.MainPage = new CustomMasterView(page);
            }
            else
                Application.Current.MainPage = new CustomMasterView(page);

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

    }
}
