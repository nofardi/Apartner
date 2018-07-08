using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class FilterConfPage : ContentPage
    {
        public FilterConfPage()
        {
            InitializeComponent();
        }

        async void OnSetFilterClicked(object sender, EventArgs e)
        {
            var swipePage = new Views.SwipePage();
            Navigation.InsertPageBefore(swipePage, this);
            await Navigation.PopAsync();
        }
    }
}
