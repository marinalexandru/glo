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
    public sealed partial class PageG : Page
    {
        private MediaPlayerPage mediaPlayerPage;

        private const string G = "g";

        public PageG()
        {
            this.InitializeComponent();
            this.Loaded += PageG_Loaded;
        }

        private void PageG_Loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayerPage = Utils.Utils.FindParent<MediaPlayerPage>(this);
            mediaPlayerPage.loadVideo(G, MediaPlayerPage.VIDEO_STATE.NO_LOOP, () => { goToGLoop(); });
        }

        private void goToGLoop()
        {
            mediaPlayerPage.navigateTo(typeof(PageGLoop));
        }
    }
}
