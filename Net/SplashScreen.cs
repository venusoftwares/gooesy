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
using Android.Webkit;
using Android.Widget;

namespace Net
{
    [Activity(Label = "Net", MainLauncher = true, Theme = "@style/Theme.NoTitleBar", NoHistory = true )]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); 
            Thread.Sleep(4000);
            StartActivity(typeof(MyWb));             
        }
    }
}