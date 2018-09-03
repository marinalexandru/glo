using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using Windows.UI.Xaml.Media.Animation;
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

        private VideoEnded videoEnded;

        public string currentPlayingVideo;

        private MediaPlayerElement focussedMediaPLayerElement;


        public MediaPlayerPage()
        {
            this.InitializeComponent();
            this.Loaded += MediaPlayerPage_Loaded;
        }

        private void MediaPlayerPage_Loaded(object sender, RoutedEventArgs e)
        {
            focussedMediaPLayerElement = MediaPlayer1;
            navigateTo(typeof(PageNoCustomerLoop));
        }

        public void loadVideo(String video, VIDEO_STATE videoState, VideoEnded videoEnded = null)
        {
            currentPlayingVideo = video;
            Uri pathUri = new Uri(String.Format("ms-appx:///Assets/Videos/{0}.mp4", video));
            MediaSource source = MediaSource.CreateFromUri(pathUri);

            getFocusedMediaPlayerElement().MediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
            switchFocusedMediaPlayers();
            getFocusedMediaPlayerElement().MediaPlayer.MediaEnded += MediaPlayer_MediaEnded;

            if (videoState == VIDEO_STATE.LOOP)
            {
                getFocusedMediaPlayerElement().MediaPlayer.IsLoopingEnabled = true;
            }
            else
            {
                getFocusedMediaPlayerElement().MediaPlayer.IsLoopingEnabled = false;
            }

            this.videoState = videoState;
            if (videoEnded != null)
            {
                this.videoEnded = videoEnded;
            }
            else
            {
                this.videoEnded = null;
            }

            getFocusedMediaPlayerElement().Source = source;

            getFocusedMediaPlayerElement().MediaPlayer.Play();
            animateMediaPlayers();
        }

        private void animateMediaPlayers()
        {
            if (focussedMediaPLayerElement == MediaPlayer2)
            {
                Task.Delay(350).ContinueWith(async t =>
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        Storyboard storyboardFadeOut = this.Resources["MediaPlayer1FadeOut"] as Storyboard;
                        storyboardFadeOut.Begin();

                    });
                });
                Storyboard storyboardFadeIn = this.Resources["MediaPlayer2FadeIn"] as Storyboard;
                storyboardFadeIn.Begin();
            }
            else
            {
                Task.Delay(350).ContinueWith(async t =>
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        Storyboard storyboardFadeOut = this.Resources["MediaPlayer2FadeOut"] as Storyboard;
                        storyboardFadeOut.Begin();
                    });
                });

                Storyboard storyboardFadeIn = this.Resources["MediaPlayer1FadeIn"] as Storyboard;
                storyboardFadeIn.Begin();
            }
        }

        public void setOnVideoEnded(VideoEnded videoEnded)
        {
            this.videoEnded = videoEnded;
        }

        private void switchFocusedMediaPlayers()
        {
            if (focussedMediaPLayerElement == MediaPlayer1)
            {
                focussedMediaPLayerElement = MediaPlayer2;
            }
            else
            {
                focussedMediaPLayerElement = MediaPlayer1;
            }
        }

        private MediaPlayerElement getFocusedMediaPlayerElement()
        {
            return focussedMediaPLayerElement;
        }

        public void navigateTo(Type pageType, Object payload = null)
        {
            if (NavFrame.BackStack.Count > 0)
            {
                NavFrame.BackStack.RemoveAt(0);
            }
            if (payload == null)
            {
                NavFrame.Navigate(pageType);
                return;
            }
            NavFrame.Navigate(pageType, payload);

        }

        private async void MediaPlayer_MediaEnded(MediaPlayer sender, object args)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                videoEnded?.Invoke();
            });
        }
    }
}
