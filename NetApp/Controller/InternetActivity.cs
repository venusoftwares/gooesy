using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NetApp
{
    [Activity(Label = "NET", Theme = "@android:style/Theme.NoTitleBar")]
    public class InternetActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string text = "Internet Connection Failed..!";          
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity);
            ImageButton imageButton = FindViewById<ImageButton>(Resource.Id.imageView);
            imageButton.Click += ImageButton_Click;
            Context context = Application.Context;
            ToastLength duration = ToastLength.Long;
            var toast = Toast.MakeText(context, text, duration);
            toast.Show();
            // Create your application here
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}