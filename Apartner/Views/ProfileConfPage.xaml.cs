using System;
using System.Collections.Generic;
using Apartner.Models;
using Xamarin.Forms;
using System.Json;

namespace Apartner.Views
{
    public partial class ProfileConfPage : ContentPage
    {
        private User m_LoggedInUser;
        public ProfileConfPage()
        {
            m_LoggedInUser = new User();
            m_LoggedInUser.Name = "nofar";
            InitializeComponent();
            // m_LoggedInUser = User.createUserFromFBAPI(null);

            BindingContext = m_LoggedInUser;

        }

        public User User { get => m_LoggedInUser; }

        async void OnProfileSetClicked(object sender, System.EventArgs e)
        {
            var profileSelect = new Views.ProfileSelectPage();
            Navigation.InsertPageBefore(profileSelect, this);
            await Navigation.PopAsync();
        }
    }
}
