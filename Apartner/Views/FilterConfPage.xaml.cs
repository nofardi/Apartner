using System;
using System.Collections.Generic;
using Apartner.Models;
using Xamarin.Forms;
using Plugin.InputKit.Shared.Controls;

namespace Apartner.Views
{
    public partial class FilterConfPage : ContentPage
    {
        public FilterConfPage()
        {
            InitializeComponent();
            setFacilitiesUI();
        }

        private void setFacilitiesUI()
        {
            StackLayout stackLayout;
            int propIdx = 0;
            foreach (var item in PropertiesImages.m_PropertiesImages)
            {
                stackLayout = new StackLayout();
                stackLayout.HorizontalOptions = LayoutOptions.Center;
                Label propLabel = new Label();
                Image propImg = new Image();
                propLabel.Text = item.Key;
                propImg.Source = item.Value;
                propImg.WidthRequest = 30;
                propImg.HeightRequest = 30;
                propImg.HorizontalOptions = LayoutOptions.StartAndExpand;

                stackLayout.Children.Add(propImg);
                stackLayout.Children.Add(propLabel);
                CheckBox checkBox = new CheckBox("", propIdx);
                checkBox.CheckChanged += saveFilterProp;

                stackLayout.Children.Add(checkBox);
                FacilitiesGrid.Children.Add(stackLayout);
                Grid.SetRow(stackLayout, (propIdx / 3));
                Grid.SetColumn(stackLayout, (propIdx % 3));
                propIdx++;
            }
        }

        private void saveFilterProp(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            List<string> keys = new List<string>(PropertiesImages.m_PropertiesImages.Keys);
            if(checkBox.IsChecked)
            {
                //TODO: save this filter to user's defined filters.

                System.Console.WriteLine("save " + keys[int.Parse(checkBox.Key.ToString())]);
            }
            else
            {
                //TODO: delete filter from saved filters.
            }
        }

        public void OnSetFilterClicked(object sender, EventArgs e)
        {
            setFilterOnServer();
            navigateToSwipe();
        }

        void OnSkipClicked(object sender, EventArgs e)
        {
            navigateToSwipe();
        }

        private void setFilterOnServer()
        {
            Console.WriteLine(PriceSlider.Value);
            //TODO: send all filters to server.
        }

        async void navigateToSwipe()
        {
            var swipePage = new Views.SwipePage();
            Navigation.InsertPageBefore(swipePage, this);
            await Navigation.PopAsync();
        }
    }
}
