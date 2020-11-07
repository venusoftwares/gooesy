using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Android.Graphics;

namespace Net
{
	[Activity(Label = "Net", Theme = "@android:style/Theme.NoTitleBar")]
	public class MyWb : Activity
	{
		public IValueCallback mUploadMessage;
		public WebView webview;
		public ProgressBar oSpinner;
		public static int FILECHOOSER_RESULTCODE = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			WebView webview = FindViewById<WebView>(Resource.Id.webView1);
			webview.Settings.JavaScriptEnabled = true;
			webview.Settings.AllowFileAccess = true;
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
				}
				mUploadMessage = null;
			}
			base.OnActivityResult(requestCode, resultCode, data);
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
			if (keyCode == Keycode.Back && webview.CanGoBack())
			{
				webview.GoBack();
				return true;
			}
			return base.OnKeyDown(keyCode, e);
		}
	}


	public class CustomWebChromeClient : WebChromeClient
	{

		MyWb WebViewActivity;
		public CustomWebChromeClient(MyWb activity)
		{
			WebViewActivity = activity;

		}



		public override bool OnShowFileChooser(WebView webView, IValueCallback filePathCallback, FileChooserParams fileChooserParams)
		{
			WebViewActivity.mUploadMessage = filePathCallback;
			Intent i = new Intent(Intent.ActionGetContent);
			i.AddCategory(Intent.CategoryOpenable);
			i.SetType("*/*");
			WebViewActivity.StartActivityForResult(Intent.CreateChooser(i, "File Chooser"), MyWb.FILECHOOSER_RESULTCODE);

			return true;
		}


	}

}