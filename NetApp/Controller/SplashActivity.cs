using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace NetApp
{
    [Activity(Label = "NET", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)] 
    public class SplashActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.activity);
            Thread.Sleep(4000);
            StartActivity(typeof(MainActivity));
        }
    }
}