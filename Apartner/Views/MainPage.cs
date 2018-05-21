using System;

using Xamarin.Forms;

namespace Apartner.Views
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page loginPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    loginPage = new NavigationPage(new LoginPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    loginPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    loginPage = new LoginPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(loginPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
