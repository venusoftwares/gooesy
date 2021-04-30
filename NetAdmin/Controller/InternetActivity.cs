using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using System;

namespace NetAdmin
{
    [Activity(Label = "NET", Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class InternetActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity);
            ImageButton imageButton = FindViewById<ImageButton>(Resource.Id.imageView);
            imageButton.Click += ImageButton_Click;
            // Create your application here
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}