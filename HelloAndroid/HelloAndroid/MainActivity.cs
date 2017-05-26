using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace HelloAndroid
{
    [Activity(Label = "HelloAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            int count = 1;
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.button1);
            TextView ts = FindViewById<TextView>(Resource.Id.textView1);
            button.Click += delegate
            {
                ts.Text = "Hello Android";
                button.Text = string.Format("第{0}次点击", count++);
            };

            MobileCenter.Start("3c6f2c4c-21cc-4f14-9598-649112f8d1b4",
                   typeof(Analytics), typeof(Crashes));
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

