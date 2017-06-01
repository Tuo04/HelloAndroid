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
        int count = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // 加载布局
            SetContentView(Resource.Layout.Main);
            // 获取布局中的控件
            Button say = FindViewById<Button>(Resource.Id.sayHello);
            TextView show = FindViewById<TextView>(Resource.Id.showHello);
            // 绑定 Click 事件
            say.Click += (sender, e) =>
            {
                count++;
                show.Text = "Hello, Android";
                say.Text = $"You Clicked {count}";
                // Toast 通知
                Toast.MakeText(this, $"You Clicked {count}", ToastLength.Short).Show();
                if (count > 5)
                {
                    throw new System.Exception("error:click>5");
                    Crashes.GenerateTestCrash();
                }
            };
            Crashes.Enabled=true;
            MobileCenter.Start("3c6f2c4c-21cc-4f14-9598-649112f8d1b4",
                   typeof(Analytics), typeof(Crashes));
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

