using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace NetApp
{
	public class HelloWebViewClient : WebViewClient
	{ 
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
		public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
		{

			base.OnReceivedError(view, request, error);

			//------------------------------
			// In this line, I want to redirect my page

		}
		 
		public override void OnPageFinished(WebView view, string url)
		{  
			if(view.Progress != 100)
			{

				//view.SetBackgroundResource(Resource.Drawable.Error);
				view.LoadDataWithBaseURL("file:///android_res/drawable/", "<img src='Error.png' />", "text/html", "UTF-8", null) ; 
			  var context = Application.Context;
                //view.Visibility = ViewStates.Invisible; 
                Toast.MakeText(context, "Internet Connection failed", ToastLength.Long).Show();
            }
            else
            {
				base.OnPageFinished(view, url);
			} 
		} 
	}
}