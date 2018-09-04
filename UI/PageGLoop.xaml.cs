using kent_glo_20180830.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
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
    public sealed partial class PageGLoop : Page
    {
        private MediaPlayerPage mediaPlayerPage;

        private const string G_LOOP = "g_loop";

        public const string G_BLUE_ON = "g_blue_on";
        public const string G_BLUE_OFF = "g_blue_off";
        public const string G_YELLOW_ON = "g_yellow_on";
        public const string G_YELLOW_OFF = "g_yellow_off";
        public const string G_GREEN_ON = "g_green_on";
        public const string G_GREEN_OFF = "g_green_off";
        public const string G_PURPLE_ON = "g_purple_on";
        public const string G_PURPLE_OFF = "g_purple_off";
        public const string G_VELVET_ON = "g_velvet_on";
        public const string G_VELVET_OFF = "g_velvet_off";


        public PageGLoop()
        {
            this.InitializeComponent();
            this.Loaded += PageGLoop_Loaded;
        }

        private void PageGLoop_Loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayerPage = Utils.Utils.FindParent<MediaPlayerPage>(this);
            mediaPlayerPage.loadVideo(G_LOOP, MediaPlayerPage.VIDEO_STATE.LOOP);

            Task.Delay(2000).ContinueWith(async t =>
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    enableUi();
                });
            });
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

        private void enableUi()
        {
            continueToVideo.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
            blue.Visibility = Visibility.Visible;
            yellow.Visibility = Visibility.Visible;
            green.Visibility = Visibility.Visible;
            purple.Visibility = Visibility.Visible;
            velvet.Visibility = Visibility.Visible;
        }

        private void continueToVideo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.navigateTo(typeof(PageH));
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.navigateTo(typeof(PageGBack));
        }

        private void blue_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = G_BLUE_ON, Off = G_BLUE_OFF });
        }

        private void yellow_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = G_YELLOW_ON, Off = G_YELLOW_OFF });
        }

        private void green_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = G_GREEN_ON, Off = G_GREEN_OFF });
        }

        private void purple_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = G_PURPLE_ON, Off = G_PURPLE_OFF });
        }

        private void velvet_Tapped(object sender, TappedRoutedEventArgs e)
        {
            disableUi();
            mediaPlayerPage.navigateTo(typeof(PageGOnOff), new VideoTupleParams() { On = G_VELVET_ON, Off = G_VELVET_OFF });
        }
    }
}
