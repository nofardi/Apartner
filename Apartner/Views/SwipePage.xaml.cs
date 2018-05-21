using System;
using System.Collections.Generic;
using Apartner.ViewModels;
using Xamarin.Forms;

namespace Apartner.Views
{
    public partial class SwipePage : ContentPage, ISwipeCallBack
    {
        public SwipePage()
        {
            InitializeComponent();
            SwipeListener swipeListener = new SwipeListener(apartSwipe, this);
        }

        public void onBottomSwipe(View view)
        {
            throw new NotImplementedException();
        }

        public void onLeftSwipe(View view)
        {
            throw new NotImplementedException();
        }

        public void onNothingSwiped(View view)
        {
            throw new NotImplementedException();
        }

        public void onRightSwipe(View view)
        {
            throw new NotImplementedException();
        }

        public void onTopSwipe(View view)
        {
            throw new NotImplementedException();
        }
    }
}
