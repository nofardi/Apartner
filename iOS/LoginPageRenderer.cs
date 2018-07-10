using Apartner.iOS;
using Apartner.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Auth;
using System;

[assembly: ExportRenderer(typeof(ServiceToLogin), typeof(LoginPageRenderer))]
namespace Apartner.iOS
{
    public class LoginPageRenderer : PageRenderer
    {
        public LoginPageRenderer()
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            OAuth2Authenticator auth = new OAuth2Authenticator
            (
                clientId: "2270292349662788",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://m.facebook.com/connect/login_success.html"),
                // switch for new Native UI API
                //      true = Android Custom Tabs and/or iOS Safari View Controller
                //      false = Embedded Browsers used (Android WebView, iOS UIWebView)
                //  default = false  (not using NEW native UI)
                isUsingNativeUI: true
            );

            auth.Completed += (sender, eventArgs) =>
            {
                // UI presented, so it's up to us to dimiss it on iOS
                // dismiss ViewController with UIWebView or SFSafariViewController
                DismissViewController(true, null);

                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    App.SuccessfulLoginAction.Invoke();
                    // Use eventArgs.Account to do wonderful things
                    App.SaveToken(eventArgs.Account.Properties["access_token"]);
                }
                else
                {
                    // The user cancelled
                }
            };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
