using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class ProfileSelectPage : ContentPage
    {
        public ProfileSelectPage()
        {
            InitializeComponent();

        }

        async void OnSetProfileClicked(object sender, EventArgs e)
        {
            if(isLookingForApartment.IsChecked)
            {
                var filterApartPage = new Views.FilterConfPage();
                Navigation.InsertPageBefore(filterApartPage, this);
                await Navigation.PopAsync();
            }
        }
    }
}
