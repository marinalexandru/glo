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
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
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
    public sealed partial class Page18Check : Page
    {


        public DateTimeOffset ChosenDay { get; set; }
        public DateTimeOffset ChosenMonth { get; set; }
        public DateTimeOffset ChosenYear { get; set; }

        private MediaPlayerPage mediaPlayerPage;

        private enum CALENDAR_DISPLAY
        {
            DAY_ONLY,
            MONTH_ONLY,
            YEAR_ONLY
        }

        public Page18Check()
        {
            this.InitializeComponent();
            this.Loaded += Page18Check_Loaded;
        }

        private void Page18Check_Loaded(object sender, RoutedEventArgs e)
        {
            configureFlyouts();
            mediaPlayerPage = Utils.Utils.FindParent<MediaPlayerPage>(this);
            Storyboard storyboard = this.Resources["ImageFadeIn"] as Storyboard;
            storyboard.Begin();
            storyboard.Completed += (_1, _2) => showYesNoButtons();
        }

        private void configureFlyouts()
        {
            setDatePicker(CALENDAR_DISPLAY.DAY_ONLY, (day.Flyout as DatePickerFlyout));
            setDatePicker(CALENDAR_DISPLAY.MONTH_ONLY, (month.Flyout as DatePickerFlyout));
            setDatePicker(CALENDAR_DISPLAY.YEAR_ONLY, (year.Flyout as DatePickerFlyout));

        }

        private void setDatePicker(CALENDAR_DISPLAY calendarDisplay, DatePickerFlyout datePickerFlyout)
        {
            datePickerFlyout.DayVisible = calendarDisplay == CALENDAR_DISPLAY.DAY_ONLY;
            datePickerFlyout.MonthVisible = calendarDisplay == CALENDAR_DISPLAY.MONTH_ONLY;
            datePickerFlyout.YearVisible = calendarDisplay == CALENDAR_DISPLAY.YEAR_ONLY;
        }

        private void showYesNoButtons()
        {
            yes.Visibility = Visibility.Visible;
            day.Visibility = Visibility.Visible;
            month.Visibility = Visibility.Visible;
            year.Visibility = Visibility.Visible;
        }

        private void yes_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Storyboard storyboard = this.Resources["ImageFadeOut"] as Storyboard;
            storyboard.Completed += (_1, _2) => navigateForward();
            mediaPlayerPage.loadVideo(PageA.A, MediaPlayerPage.VIDEO_STATE.NO_LOOP);

            Task.Delay(200).ContinueWith(async t =>
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    storyboard.Begin();
                });
            });

        }

        private void no_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Storyboard storyboard = this.Resources["ImageFadeOut"] as Storyboard;
            storyboard.Begin();
            storyboard.Completed += (_1, _2) => navigateBack();
        }

        private void navigateForward()
        {
            mediaPlayerPage.navigateTo(typeof(PageA));
        }

        private void navigateBack()
        {
            mediaPlayerPage.navigateTo(typeof(PageNoCustomerLoop));
        }

        private void day_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //var ap = new ButtonAutomationPeer(Picker);
            //var ip = ap.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            //ip?.Invoke();
        }

        private void month_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void year_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
