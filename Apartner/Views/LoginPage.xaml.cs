using System;
using Xamarin.Forms;
using Apartner.Models;

namespace Apartner.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //var user = new User
            //{
            //    Username = usernameEntry.Text,
            //    Password = passwordEntry.Text
            //};

           // var isValid = AreCredentialsCorrect(user);
            //if (isValid)
            //{
                //App.IsUserLoggedIn = true;

                var swipePage = new Views.SwipePage();
                Navigation.InsertPageBefore(swipePage, this);
                await Navigation.PopAsync();
            //}
            //else
            //{
            //    //messageLabel.Text = "Login failed";
            //    //passwordEntry.Text = string.Empty;
            //}
        }

        async void OnFacebookClick(object sender, EventArgs e)
        {
            var swipePage = new Views.SwipePage();
            Navigation.InsertPageBefore(swipePage, this);
            await Navigation.PopAsync();
        }

        async void OnGmailClick(object sender, EventArgs e)
        {
            var swipePage = new Views.SwipePage();
            Navigation.InsertPageBefore(swipePage, this);
            await Navigation.PopAsync();
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.IsUserSignedUp();
        }
    }
}