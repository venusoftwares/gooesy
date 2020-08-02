using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;
using gooesyPartner.Views;
using gooesyPartner.Models;
using Android.Graphics;

namespace gooesyPartner
{
    [Activity(Label = "Gooesy Franchise", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        WebView webView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            webView = FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new HelloWebViewClient());
            webView.LoadUrl("https://www.gooesy.com/index.php/adminpanel");


            base.OnCreate(bundle);

        }
        public class HelloWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {
                view.LoadUrl(request.Url.ToString());
                return false;
            }
            public override void OnPageStarted(WebView view, string url, Bitmap favicon)
            {
                base.OnPageStarted(view, url, favicon);
            }

            // For API level 24 and later


            public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
            {

                base.OnReceivedError(view, request, error);

                //------------------------------
                // In this line, I want to redirect my page

            }
            public override void OnPageFinished(WebView view, string url)
            {
                base.OnPageFinished(view, url);
            }
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && webView.CanGoBack())
            {
                webView.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }


    }
}

