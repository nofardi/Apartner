using System;
using Plugin.InputKit.Shared.Controls;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class LocationSelectionModalPage : ContentPage
    {
        public LocationSelectionModalPage()
        {
            InitializeComponent();
        }


        void OnCheckAllChanged(object sender, System.EventArgs e)
        {
            if(allAreasChecked.IsChecked)
            {
                foreach(CheckBox checkbox in specificAreas.Children)
                {
                    checkbox.IsChecked = true;
                }
            }
            else
            {
                foreach (CheckBox checkbox in specificAreas.Children)
                {
                    checkbox.IsChecked = false;
                }
            }
        }

        async void OnDoneClickedAsync(object sender, EventArgs e)
        {
            saveLocationChoices();
            await Navigation.PopModalAsync();
        }

        private void saveLocationChoices()
        {
            //TODO
        }

        async void OnNearbyClicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            //TODO save position
            await Navigation.PopModalAsync();
        }
    }
}
