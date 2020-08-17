namespace AppWorldAgent.ViewModels
{
    using AppWorldAgent.Infrastructure.Services.Dialog;
    using AppWorldAgent.Infrastructure.Services.RequestProvider;
    using AppWorldAgent.Infrastructure.Services.Settings;
    using AppWorldAgent.Infrastructure.TinyIoC;
    using AppWorldAgent.Services.DataAccess.Identity;
    using AppWorldAgent.Services.Navigation;
    using System;
    using System.Globalization;
    using System.Reflection;
    using Xamarin.Forms;
    public static class LocatorViewModel
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(LocatorViewModel), default(bool), propertyChanged: OnAutoWireViewModelChanged);
        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(LocatorViewModel.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(LocatorViewModel.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static LocatorViewModel()
        {
            _container = new TinyIoCContainer();
            _container.Register<LoginViewModel>();
            _container.Register<MainViewModel>();

            _container.Register<IDialogService, DialogService>();
            _container.Register<IIdentityService, IdentityService>();
            _container.Register<IRequestProvider, RequestProvider>();
            _container.Register<ISettingsService, SettingsService>();
            _container.Register<INavigationService, NavigationService>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            if (useMockServices)
            {
                UseMockService = true;
            }
            else
            {
                UseMockService = false;
            }
        }

        private static TinyIoCContainer _container;

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
