using System;
using Apartner.ViewModels;
using Xamarin.Forms;
using System.Collections.Generic;
using Apartner.Models;

namespace Apartner.Views
{
    public partial class SwipePage : ContentPage, ISwipeCallBack
    {
        ApartmentViewModel m_ApartmentModel;
        List<StackLayout> m_PropLayouts;

        public SwipePage()
        {
            InitializeComponent();
            m_ApartmentModel = new ApartmentViewModel();
            m_ApartmentModel.LoadItemsCommand.Execute(null);
            SwipeListener swipeListener = new SwipeListener(apartSwipe, this);
            BindingContext = m_ApartmentModel;
            m_PropLayouts = new List<StackLayout>();
            m_ApartmentModel.Apartment.DeserializeApart(m_ApartmentModel.ApartmentsJson[0]);
            addPropsToGrid();
        }

        private void addPropsToGrid()
        {
            List <string> propeties = m_ApartmentModel.Apartment.Properties;
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
                m_PropLayouts.Add(propLayout);
                Grid.SetRow(propLayout, (propIdx / 3) + 5);
                Grid.SetColumn(propLayout, (propIdx % 3) + 1);
            }
        }

        private void removePropFromView()
        {
            foreach(StackLayout prop in m_PropLayouts)
            {
                ApartmentView.Children.Remove(prop);
            }
        }

        async void Image_Clicked(object sender, System.EventArgs e)
        {
            var imageSource = new ImageModalPage(m_ApartmentModel.Apartment.Images[0]);
            await Navigation.PushModalAsync(imageSource);
        }

        public void onBottomSwipe(View view)
        {
            throw new NotImplementedException();
        }

        public void onLeftSwipe(View view)
        {
            //remove apratment for list
            MessagingCenter.Send(this, "DislikedApartment", m_ApartmentModel.Apartment);
            m_ApartmentModel.RemoveApartment();
            removePropFromView();
            addPropsToGrid();
            //remove apartment from user DB
        }

        public void onNothingSwiped(View view)
        {
            throw new NotImplementedException();
        }

        public void onRightSwipe(View view)
        {
            MessagingCenter.Send(this, "LikedApartment", m_ApartmentModel.Apartment);
            m_ApartmentModel.RemoveApartment();
            removePropFromView();
            addPropsToGrid();
        }

        public void onTopSwipe(View view)
        {
            throw new NotImplementedException();
        }

    }
}
