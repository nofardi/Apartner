using System;
using System.Collections.Generic;
using Apartner.ViewModels;
using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class ImageModalPage : ContentPage, ISwipeCallBack
    {
        List<string> m_Images;
        int photoPosition;

        public ImageModalPage(List<string> i_ImageSource)
        {
            photoPosition = 0;
            m_Images = i_ImageSource;
            this.BackgroundImage = m_Images[photoPosition];

            InitializeComponent();
            SwipeListener swipeListener = new SwipeListener(photoSwipe, this);
        }

        public void onBottomSwipe(View view)
        {
            throw new NotImplementedException();
        }

        public void onLeftSwipe(View view)
        {
            if (photoPosition != m_Images.Count - 1)
            {
                photoPosition = (photoPosition + 1) % m_Images.Count;
                this.BackgroundImage = m_Images[photoPosition];
            }
        }

        public void onNothingSwiped(View view)
        {
            throw new NotImplementedException();
        }

        public void onRightSwipe(View view)
        {
            if(photoPosition != 0)
            {
                photoPosition = (photoPosition - 1) % m_Images.Count;
                this.BackgroundImage = m_Images[photoPosition];
            }
        }

        public void onTopSwipe(View view)
        {
            throw new NotImplementedException();
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
