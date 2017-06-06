using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;

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
                    Crashes.Enabled = true;
                    //throw new System.Exception("error:click>5");
                    //bool isEnabled = Crashes.Enabled;
                    //System.Console.Write(isEnabled);

                    Crashes.GenerateTestCrash();
                }
                Analytics.TrackEvent("Click Me", new Dictionary<string, string> {
                    { "click", "time"+count }});
            };
            MobileCenter.Start("65ff38b5-a7f1-4493-974d-616eef498bfa",
                   typeof(Analytics), typeof(Crashes));
            //MobileCenter.Start("15a993b1-6275-4de7-9091-cf63abc2aa38",
            //       typeof(Analytics), typeof(Crashes));
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

