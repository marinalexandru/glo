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
    public sealed partial class PageEBack : Page
    {
        private MediaPlayerPage mediaPlayerPage;

        private const string E_BACK = "e_back";

        public PageEBack()
        {
            this.InitializeComponent();
            this.Loaded += PageD_Loaded;
        }

        private void PageD_Loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayerPage = Utils.Utils.FindParent<MediaPlayerPage>(this);
            mediaPlayerPage.loadVideo(E_BACK, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () => showContinue());
        }

        private void showContinue()
        {
            continueToVideo.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
        }

        private void continueToVideo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mediaPlayerPage.navigateTo(typeof(PageE));
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mediaPlayerPage.navigateTo(typeof(PageDBack));
        }
    }
}
