using AppWorldAgent.Infrastructure;
using AppWorldAgent.Models;
using AppWorldAgent.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWorldAgent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : ContentPage
    {
        CustomMasterView RootPage { get => Application.Current.MainPage as CustomMasterView; }
        public MasterDetailView()
        {
            InitializeComponent();
            BindingContext = new MasterDetailViewModel();
        }

        private async void MenuItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (BindingContext is MasterDetailViewModel vm)
            {
                if (!(e.SelectedItem is MasterDetailModel item))
                    return;

                if (RootPage.Detail is CustomNavigationView mnavigationPage)
                    await mnavigationPage.PopToRootAsync();

                RootPage.IsPresented = false;

                switch (item.Id)
                {
                    case MenuItemType.ProfileView:
                        await vm.NavigationService.NavigateToAsync<ProfileViewModel>();
                        break;

                    //case MenuItemType.RegisterView:
                    //    await vm.NavigationService.NavigateToAsync<RegisterViewModel>();
                    //    break;

                    case MenuItemType.SettingsView:
                        await vm.NavigationService.NavigateToAsync<SettingsViewModel>();
                        break;

                    case MenuItemType.SelectTestViewModel:
                        await vm.NavigationService.NavigateToAsync<ConnectionErrorViewModel>();
                        break;

                    case MenuItemType.UrlLogaware:
                        await Browser.OpenAsync(GlobalSetting.UrlWeb);
                        break;
                }

                MenuItemsListView.SelectedItem = null;
            }
        }
    }
}