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
    public sealed partial class MediaPlayerPage : Page
    {

        public enum VIDEO_STATE
        {
            LOOP,
            NO_LOOP
        }

        public delegate void VideoEnded();

        private VIDEO_STATE videoState;

        private String currentPlayingVideo;

        private VideoEnded videoEnded;

        public MediaPlayerPage()
        {
            this.InitializeComponent();
            this.Loaded += MediaPlayerPage_Loaded;
        }

        public void loadVideo(String video)
        {
            currentPlayingVideo = video;
            Uri pathUri = new Uri(String.Format("ms-appx:///Assets/Videos/{0}.mp4", video));
            MediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
        }

        public void playVideo(VIDEO_STATE videoState, VideoEnded videoEnded = null)
        {
            this.videoState = videoState;
            this.videoEnded = videoEnded;
            MediaPlayer.MediaPlayer.Play();
        }

        public string getCuurentVideo()
        {
            return currentPlayingVideo;
        }

        public void navigateTo(Type pageType)
        {
            NavFrame.Navigate(pageType);
        }

        private void MediaPlayerPage_Loaded(object sender, RoutedEventArgs e)
        {
            MediaPlayer.MediaPlayer.MediaEnded += MediaPlayer_MediaEnded;

            navigateTo(typeof(PageNoCustomerLoop));
        }

        private async void MediaPlayer_MediaEnded(MediaPlayer sender, object args)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                videoEnded?.Invoke();
                switch (videoState)
                {
                    case VIDEO_STATE.NO_LOOP:
                        return;
                    case VIDEO_STATE.LOOP:
                        this.MediaPlayer.MediaPlayer.Play();
                        return;
                }

            });
        }
    }
}
