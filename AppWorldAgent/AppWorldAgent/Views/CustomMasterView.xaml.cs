
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWorldAgent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomMasterView : MasterDetailPage
    {
        public CustomMasterView() : base()
        {
            InitializeComponent();
        }

        public CustomMasterView(Page root) : base()
        {
            InitializeComponent();
            Detail = new CustomNavigationView(root);
            IsPresented = false;
        }
    }
}