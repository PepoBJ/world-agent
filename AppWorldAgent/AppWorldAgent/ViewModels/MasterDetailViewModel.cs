using AppWorldAgent.Infrastructure.Services.Settings;
using AppWorldAgent.Models;
using System.Collections.ObjectModel;

namespace AppWorldAgent.ViewModels
{
    public class MasterDetailViewModel : BaseViewModel
    {
        private string _userName = string.Empty;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(() => UserName); }
        }

        private ObservableCollection<MasterDetailModel> _menuItems;
        public ObservableCollection<MasterDetailModel> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; RaisePropertyChanged(() => MenuItems); }
        }
        public MasterDetailViewModel()
        {
            Title = "Inicio";
            UserName = LocatorViewModel.Resolve<ISettingsService>().UserName;
            _menuItems = new ObservableCollection<MasterDetailModel>
            {
                new MasterDetailModel
                {
                    Id = MenuItemType.SelectTestViewModel,
                    Icon = "Test.png",
                    Title = "Test",
                },
                new MasterDetailModel
                {
                    Id = MenuItemType.UrlLogaware,
                    Icon = "Internet.png",
                    Title = "Web World Agent",
                }
            };
        }
    }
}
