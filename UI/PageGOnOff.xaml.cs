using kent_glo_20180830.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace kent_glo_20180830.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageGOnOff : Page
    {
        private MediaPlayerPage mediaPlayerPage;
        private VideoTupleParams parameters;

        public PageGOnOff()
        {
            this.InitializeComponent();
            this.Loaded += PageGOnOff_Loaded;
        }

        private void PageGOnOff_Loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayerPage = Utils.Utils.FindParent<MediaPlayerPage>(this);
            mediaPlayerPage.loadVideo(parameters.On, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () => { showUi(); });
        }

        private void showUi()
        {
            continueToVideo.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
            blue.Visibility = Visibility.Visible;
            yellow.Visibility = Visibility.Visible;
            green.Visibility = Visibility.Visible;
            purple.Visibility = Visibility.Visible;
            velvet.Visibility = Visibility.Visible;
        }

        private void disableUi()
        {
            continueToVideo.Visibility = Visibility.Collapsed;
            back.Visibility = Visibility.Collapsed;
            blue.Visibility = Visibility.Collapsed;
            yellow.Visibility = Visibility.Collapsed;
            green.Visibility = Visibility.Collapsed;
            purple.Visibility = Visibility.Collapsed;
            velvet.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            parameters = (VideoTupleParams)e.Parameter;
        }


        private void continueToVideo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.loadVideo(parameters.Off,MediaPlayerPage.VIDEO_STATE.NO_LOOP ,() => {
                mediaPlayerPage.navigateTo(typeof(PageH));
            });
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.loadVideo(parameters.Off, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () =>
            {
                mediaPlayerPage.navigateTo(typeof(PageGBack));
            });
        }

        private void blue_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.loadVideo(parameters.Off, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () =>
            {
                mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = PageGLoop.G_BLUE_ON, Off = PageGLoop.G_BLUE_OFF });
            });
        }

        private void yellow_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.loadVideo(parameters.Off, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () =>
            {
                mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = PageGLoop.G_YELLOW_ON, Off = PageGLoop.G_YELLOW_OFF });
            });
        }

        private void green_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.loadVideo(parameters.Off, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () =>
            {
                mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = PageGLoop.G_GREEN_ON, Off = PageGLoop.G_GREEN_OFF });
            });
        }

        private void purple_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.loadVideo(parameters.Off, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () =>
            {
                mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = PageGLoop.G_PURPLE_ON, Off = PageGLoop.G_PURPLE_OFF });
            });
        }

        private void velvet_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.loadVideo(parameters.Off, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () =>
            {
                mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = PageGLoop.G_VELVET_ON, Off = PageGLoop.G_VELVET_OFF });
            });
        }
    }
}
