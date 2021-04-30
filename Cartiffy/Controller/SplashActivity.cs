﻿using Android.App;
using Android.OS;
using System.Threading;

namespace Cartiffy
{
    [Activity(Label = "Cartiffy", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(4000);
            StartActivity(typeof(MainActivity));
        }
    }
}