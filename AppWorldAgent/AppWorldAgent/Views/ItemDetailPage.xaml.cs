using System.ComponentModel;
using Xamarin.Forms;
using AppWorldAgent.ViewModels;

namespace AppWorldAgent.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}