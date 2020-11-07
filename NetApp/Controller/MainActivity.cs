using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using Android.Views;
using Android.Webkit;
using Android.Graphics;
using Xamarin.Essentials;

namespace NetApp
{
    [Activity(Label = "NET", Theme = "@android:style/Theme.NoTitleBar" )]
    public class MainActivity : Activity
    {
		public IValueCallback mUploadMessage;
		public WebView webview;
		public ProgressBar oSpinner;
		public static int FILECHOOSER_RESULTCODE = 1;
	 
		 
		protected override void OnCreate(Bundle savedInstanceState)
		{
			var current = Connectivity.NetworkAccess;
			if (current != NetworkAccess.Internet)
			{
				 StartActivity(typeof(InternetActivity));               
            }
            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			webview = FindViewById<WebView>(Resource.Id.webView1);
			webview.Settings.JavaScriptEnabled = true;
			webview.Settings.AllowFileAccess = true;
			webview.Settings.MediaPlaybackRequiresUserGesture = true;
			webview.LoadUrl("https://netappsdemo.pw");
			webview.SetWebViewClient(new HelloWebViewClient());
			webview.SetWebChromeClient(new CustomWebChromeClient(this)); 
		}
		protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
		{
			if (requestCode == FILECHOOSER_RESULTCODE)
			{
				if (null == mUploadMessage) return;
				Android.Net.Uri[] result = data == null || resultCode != Result.Ok ? null : new Android.Net.Uri[] { data.Data };
				try
				{
					mUploadMessage.OnReceiveValue(result);
				}
				catch (Exception e)
				{
					throw e;
				}
				mUploadMessage = null;
			}
			base.OnActivityResult(requestCode, resultCode, data);
		}
		public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
		{
			if (keyCode == Keycode.Back && webview.CanGoBack()) // <-- this is the line which brings up the error
			{
				webview.GoBack();

				return true;
			}
			return base.OnKeyDown(keyCode, e);
		}
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
			 
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}