using System;

using Xamarin.Forms;

namespace Apartner
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
        static NavigationPage _NavPage;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            //else
            //DependencyService.Register<CloudDataStore>();
           // _NavPage = new NavigationPage(new Views.ServiceToLogin());

            MainPage = _NavPage = new NavigationPage(new Views.LoginPage());

        }


        static string _Token;

        public static bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }

        public static string Token
        {
            get { return _Token; }
        }

        public static void SaveToken(string token)
        {
            _Token = token;
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => {
                   _NavPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
