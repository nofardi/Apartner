using System;
using System.Collections.Generic;



using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class ProfileConfPage : ContentPage
    {
        public ProfileConfPage()
        {
            InitializeComponent();

        }

        async void OnProfileSetClicked(object sender, System.EventArgs e)
        {
            var profileSelect = new Views.ProfileSelectPage();
            Navigation.InsertPageBefore(profileSelect, this);
            await Navigation.PopAsync();
        }
    }
}
