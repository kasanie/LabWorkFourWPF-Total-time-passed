using System;
using System.Windows;
using System.Windows.Controls;

namespace LabWorkFourWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Day.IsEnabled = false;
            AddYears();
            AddMonths();

        }

        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Month.SelectedItem != null)
            {
                if (Day.IsEnabled == false)
                {
                    Day.IsEnabled = true;
                }
                AddDays();
            }
        }

        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Year.SelectedItem != null)
            {

                if (Day.IsEnabled == false)
                {
                    Day.IsEnabled = true;
                }
                AddDays();
            }


        }

        private void Day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Day.SelectedItem != null)
            {
                TimePassed();
            }
        }
        private void TimePassed()
        {

            int yy = Convert.ToInt32(Year.SelectedValue);
            int mm = Convert.ToInt32(Month.SelectedValue);
            int dd = Convert.ToInt32(Day.SelectedValue);
            var currentDate = DateTime.Now;
            var pastDate = new DateTime(yy, mm, dd);
            var days = currentDate.Day - pastDate.Day;
            var daysInLastMonth = DateTime.DaysInMonth(pastDate.Year, pastDate.Month);
            var changeMonth = 0;
            if (days < 0)
            {
                days += daysInLastMonth;
                changeMonth = -1;
            }
            var months = currentDate.Month - pastDate.Month + changeMonth;
            var changeYear = 0;
            if (months < 0)
            {
                months += 12;
                changeYear = -1;
            }
            var years = currentDate.Year - pastDate.Year + changeYear;
            MessageBox.Show($"{years} years {months} months and {days} days have passed.");
        }
        private void AddYears()
        {
            int currentYear = DateTime.Now.Year;
            for (var years = 1; years <= currentYear; years++)
            {
                Year.Items.Add(years.ToString());
            }
        }
        private void AddMonths()
        {
            for (var months = 1; months <= 12; months++)
            {
                Month.Items.Add(months.ToString());
            }
        }
        private void AddDays()
        {
            Day.Items.Clear();
            var daysInMonth = DateTime.DaysInMonth(Convert.ToInt32(Year.SelectedValue), Convert.ToInt32(Month.SelectedValue));
            for (var i = 1; i <= daysInMonth; i++)
            {
                Day.Items.Add(i.ToString());
            }
        }
    }
}
