using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Playground.Models;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Playground.Templates
{
    public sealed partial class UnifiedTemplate : UserControl
    {
        public Unified Data
        {
            get { return (Unified)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(Unified), typeof(UnifiedTemplate), new PropertyMetadata(null, OnChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var that = d as UnifiedTemplate;

            if (that == null || e.NewValue == null || e.NewValue == e.OldValue) return;

            var data = (Unified) e.NewValue;

            if (data.GetItemType() == typeof(Follow))
            {
                that.FindName(nameof(FollowButton));
                that.FindName(nameof(FollowPanel));
            }
            else
            {
                that.FindName(nameof(LikeButton));
                that.FindName(nameof(LikePanel));
            }
        }

        public UnifiedTemplate()
        {
            this.InitializeComponent();
        }

        private void FollowButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var value = !Data.FollowInfo.IsFollowed;
            Data.FollowInfo.IsFollowed = value;
            Data.FollowInfo.FollowCount += (bool)value ? +1 : -1;
        }

        private void LikeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var value = !Data.LikeInfo.IsLiked;
            Data.LikeInfo.IsLiked = value;
            Data.LikeInfo.LikeCount += (bool)value ? +1 : -1;
        }
    }
}
