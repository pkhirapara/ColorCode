using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using System;

namespace ColorCode
{
    [Activity(Label = "ColorCode", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        WebView localWebView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
            localWebView.Settings.JavaScriptEnabled = true;
            localWebView.AddJavascriptInterface(new MyJSInterface(this), "CSharp");
            localWebView.LoadUrl("file:///android_asset/HTMLPage1.html");
            

            var button = FindViewById<Button>(Resource.Id.dobutton);
            button.Click += Button_Click;

        //F:\VB Programms\ColorCode\ColorCode\Assets\HTMLPage1.html
       // C: \Users\USER\Desktop\prettify\HTMLPage1.html
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var codeString = @"#include <stdio.h>
int main()
{
                int number;
                // printf() dislpays the formatted output 
                printf(""Enter an integer: "");

                // scanf() reads the formatted input and stores them
                scanf(""%d"", &number);

                // printf() displays the formatted output
                printf(""You entered: %d"", number);
                return 0;
            }";
            //codeString = codeString.Replace(System.Environment.NewLine, "\r\n");
            localWebView.EvaluateJavascript($"showCode('{codeString.Replace("\r","<lb>").Replace("\n","")}')", null);
        }
    }
}

