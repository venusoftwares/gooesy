using Android.Content;
using Android.Webkit;

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