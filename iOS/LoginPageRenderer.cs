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
                authorizeUrl: new Uri("https://www.facebook.com/v2.8/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += (sender, eventArgs) =>
            {
                DismissViewController(true, null);

                if (eventArgs.IsAuthenticated)
                {
                    App.SuccessfulLoginAction.Invoke();
                    // Use eventArgs.Account to do wonderful things
                    App.SaveToken(eventArgs.Account.Properties["access_token"]);
                }
                else
                {
                    // The user cancelled
                }
            };

            if(App.Token == null)
                PresentViewController(auth.GetUI(), true, null);
        }
    }
}
