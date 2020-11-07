using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace NetApp
{
    public class CustomWebChromeClient : WebChromeClient
    {
		MainActivity WebViewActivity;
		public CustomWebChromeClient(MainActivity activity)
		{
			WebViewActivity = activity;

		}
		public override bool OnShowFileChooser(WebView webView, IValueCallback filePathCallback, FileChooserParams fileChooserParams)
		{
			WebViewActivity.mUploadMessage = filePathCallback;
			Intent i = new Intent(Intent.ActionGetContent);
			i.AddCategory(Intent.CategoryOpenable);
			i.SetType("*/*");
			WebViewActivity.StartActivityForResult(Intent.CreateChooser(i, "File Chooser"), MainActivity.FILECHOOSER_RESULTCODE);

			return true;
		}
	}
}