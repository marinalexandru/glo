﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace kent_glo_20180830.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageGBack : Page
    {
        private MediaPlayerPage mediaPlayerPage;

        private const string G_BACK = "g_back";

        public PageGBack()
        {
            this.InitializeComponent();
            this.Loaded += PageGBack_Loaded;
        }

        private void PageGBack_Loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayerPage = Utils.Utils.FindParent<MediaPlayerPage>(this);
            mediaPlayerPage.loadVideo(G_BACK, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () => showContinue());
        }

        private void showContinue()
        {
            continueToVideo.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
        }

        private void continueToVideo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mediaPlayerPage.navigateTo(typeof(PageG));
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mediaPlayerPage.navigateTo(typeof(PageFBack));
        }
    }
}
