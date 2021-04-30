using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using Xamarin.Essentials;

namespace SevanSports
{
    [Activity(Label = "7 Sports", Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
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
            webview.Settings.JavaScriptEnabled = appConfig.JAVA_SCRIPT_ENABLED;
            webview.Settings.AllowFileAccess = appConfig.ALLOW_FILE_ACCESS;
            webview.Settings.MediaPlaybackRequiresUserGesture = appConfig.MEDIA_PLAY_BACK_REQUIRES_USER_GESTURE;
            //webview.Settings.SetSupportZoom(appConfig.SET_SUPPORT_VIEW);
            //webview.Settings.BuiltInZoomControls = appConfig.BUILD_IN_ZOOM_CONTROLS;
            //webview.Settings.DisplayZoomControls = appConfig.DISPLAY_ZOOM_CONTROLS;
            webview.LoadUrl(appConfig.URL);
            webview.SetWebViewClient(new HelloWebViewClient(this));
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
            if (keyCode == Keycode.Back && webview.CanGoBack())
            {
                webview.GoBack();

                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}