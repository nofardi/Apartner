using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class MapModalPage : ContentPage
    {
        public MapModalPage()
        {
            InitializeComponent();
            initMap();
        }

        async void initMap()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                                           Distance.FromMiles(1)));
        }

        async void OnSearchAddressClicked(object sender, EventArgs e)
        {
            
            Geocoder geocoder = new Geocoder();

            if (!string.IsNullOrEmpty(mapEntry.Text))
            {
                IEnumerable<Position> positions = (await geocoder.GetPositionsForAddressAsync(mapEntry.Text));
                foreach (var position in positions)
                {
                    if (position != null)
                    {
                        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                                                   Distance.FromMiles(1)));
                    }
                }
            }
        }

        void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var zoomLevel = e.NewValue; // between 1 and 18
            var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
            MyMap.MoveToRegion(new MapSpan(MyMap.VisibleRegion.Center, latlongdegrees, latlongdegrees));
        }

        async void DismissClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
