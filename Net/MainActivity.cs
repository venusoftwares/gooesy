using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;
 

namespace Net
{
	[Activity(Label = "Net", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
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
			webview.SetWebViewClient(new WebViewClient());
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