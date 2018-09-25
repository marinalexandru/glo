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
            var dayPickerFlyout = day.Flyout as DatePickerFlyout;
            var monthPickerFlyout = month.Flyout as DatePickerFlyout;
            var yearPickerFlyout = year.Flyout as DatePickerFlyout;

            setDatePicker(CALENDAR_DISPLAY.DAY_ONLY, dayPickerFlyout);
            setDatePicker(CALENDAR_DISPLAY.MONTH_ONLY, monthPickerFlyout);
            setDatePicker(CALENDAR_DISPLAY.YEAR_ONLY, yearPickerFlyout);

            dayPickerFlyout.DatePicked += (_1, _2) => DayText.Text = ChosenDay.ToString("dd");
            monthPickerFlyout.DatePicked += (_1, _2) => MonthText.Text = ChosenMonth.ToString("MM");
            yearPickerFlyout.DatePicked += (_1, _2) => YearText.Text = ChosenYear.ToString("yyyy");

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

            if (DayText.Text == String.Empty || MonthText.Text == String.Empty || YearText.Text == String.Empty)
            {
                return;
            }

            var birthDate = new DateTime(ChosenYear.Year, ChosenMonth.Month, ChosenDay.Day);

            if (birthDate.AddYears(18) < DateTime.Now)
            {
                acceptUser();
                return;
            }
            rejectUser();

        }

        private void acceptUser()
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

        private void rejectUser()
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

    }
}
