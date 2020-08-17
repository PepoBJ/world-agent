using Android.App;
using Android.Content;
using Android.OS;
using System.Threading;

namespace AppWorldAgent.Droid.Activities
{
    [Activity(Theme = "@style/MainTheme.Splash",
        Label = "World Agent ",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ThreadPool.QueueUserWorkItem(o => LoadActivity());
            // Create your application here
        }

        private void LoadActivity()
        {
            RunOnUiThread(() =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            });
        }
    }
}