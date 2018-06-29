using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class ImageModalPage : ContentPage
    {
        public ImageModalPage(string i_ImageSource)
        {
            InitializeComponent(); 
            apartmentImg.Source = i_ImageSource;
       
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
