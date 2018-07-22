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
        LoginAPIs m_LoginAPIType;
        public LoginPageRenderer(LoginAPIs i_LoginApiType)
        {
            m_LoginAPIType = i_LoginApiType;
        }

        public LoginPageRenderer()
        {
            
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            OAuth2Authenticator auth = null;

            //if (m_LoginAPIType == LoginAPIs.Facebook)
            //{
                 auth = new OAuth2Authenticator
                (
                    clientId: "2270292349662788",
                    scope: "",
                    authorizeUrl: new Uri("https://www.facebook.com/v2.8/dialog/oauth/"),
                    redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));
            //}
            //else
            //{  
            //    auth = new OAuth2Authenticator(
            //        "2270292349662788",
            //   string.Empty,
            //   "email",
            //   new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
            //        new Uri("http://bla.html"),
            //   new Uri("https://www.googleapis.com/oauth2/v4/token"),
            //   isUsingNativeUI: true);
                
            //}
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


public enum LoginAPIs
{
    Facebook, Google
}