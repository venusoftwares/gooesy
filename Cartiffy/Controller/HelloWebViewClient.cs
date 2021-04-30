using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using System;

namespace Cartiffy
{
    public class HelloWebViewClient : WebViewClient
    {
        MainActivity _activity;
        InternetActivity _internetActivity = new InternetActivity();

        public HelloWebViewClient(MainActivity activity)
        {
            this._activity = activity;
        }

        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl(request.Url.ToString());
            return true;
        }
        public override void OnPageStarted(WebView view, string url, Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);
        }
        // For API level 24 and later 
        //public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
        //{			 
        //	base.OnReceivedError(view, request, error);
        //}

        public override void OnPageFinished(WebView view, string url)
        {
            //if(view.Progress != 100)
            //{
            //	view.Visibility = ViewStates.Invisible;
            //	_activity.StartActivity(typeof(MainActivity));
            //}
            //else
            //{
            base.OnPageFinished(view, url);
            //} 
        }
        public override void OnReceivedHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
        {
            base.OnReceivedHttpError(view, request, errorResponse);
        }

        [Obsolete]
        public override void OnReceivedError(WebView view, [GeneratedEnum] ClientError errorCode, string description, string failingUrl)
        {
            if (description == "net::ERR_INTERNET_DISCONNECTED")
            {
                view.Visibility = ViewStates.Gone;
                _activity.StartActivity(typeof(InternetActivity));
            }
            else
            {
                base.OnReceivedError(view, errorCode, "Venu Softwares", failingUrl);
            }
        }
    }
}