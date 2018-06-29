using System;
using Apartner.ViewModels;
using Xamarin.Forms;
using System.Collections.Generic;
using Apartner.Models;

namespace Apartner.Views
{
    public partial class SwipePage : ContentPage, ISwipeCallBack
    {
        ApartmentViewModel apartmentModel;
        
        public SwipePage()
        {
            apartmentModel = new ApartmentViewModel();
            apartmentModel.LoadItemsCommand.Execute(null);
            InitializeComponent();
            addPropsToGrid();
            SwipeListener swipeListener = new SwipeListener(apartSwipe, this);
            BindingContext = apartmentModel;

        }

        private void addApartPhotoToGrid()
        {
            Image apartImage = new Image();
            apartImage.Source = PropertiesImages.m_PropertiesImages["apartImage"];
            Grid.SetRow(apartImage, 1);
            Grid.SetColumn(apartImage, 1);
        }

        private void addPropsToGrid()
        {
            List <string> propeties = apartmentModel.Apartment.Properties;

            for (int propIdx = 0; propIdx < propeties.Count; propIdx++)
            {
                StackLayout propLayout = new StackLayout();
                Label propLabel = new Label();
                Image propImg = new Image();
                propLabel.Text = propeties[propIdx];
                propImg.Source = PropertiesImages.m_PropertiesImages[propeties[propIdx]];
                propImg.WidthRequest = 30;
                propImg.HeightRequest = 30;
                propImg.HorizontalOptions = LayoutOptions.StartAndExpand;

                propLayout.Children.Add(propImg);
                propLayout.Children.Add(propLabel);
                propLayout.Margin = new Thickness(0, 0, 0, 10);
                ApartmentView.Children.Add(propLayout);
                Grid.SetRow(propLayout, (propIdx / 3) + 5);
                Grid.SetColumn(propLayout, (propIdx % 3) + 1);

            }

        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var detailPage = new ImageModalPage();
            await Navigation.PushModalAsync(detailPage);
        }

        public void onBottomSwipe(View view)
        {
            throw new NotImplementedException();
        }

        public void onLeftSwipe(View view)
        {
            //remove apratment for list
            apartmentModel.RemoveApartment();
            addPropsToGrid();
            //remove apartment from user DB
        }

        public void onNothingSwiped(View view)
        {
            throw new NotImplementedException();
        }

        public void onRightSwipe(View view)
        {
            apartmentModel.RemoveApartment();
            addPropsToGrid();
        }

        public void onTopSwipe(View view)
        {
            throw new NotImplementedException();
        }

    }
}
