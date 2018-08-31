using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
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
    public sealed partial class PageA : Page
    {
        public PageA()
        {
            this.InitializeComponent();
            this.Loaded += PageA_Loaded;
        }

        private void PageA_Loaded(object sender, RoutedEventArgs e)
        {
            Uri pathUri = new Uri(String.Format("ms-appx:///Assets/Videos/{0}.mp4", "no_customer_loop"));
            MediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
            MediaPlayer.MediaPlayer.Play();
            MediaPlayer.MediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private async void MediaPlayer_MediaEnded(MediaPlayer sender, object args)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                MediaPlayer.MediaPlayer.Play();
            });
        }

        private void MediaPlayer_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
