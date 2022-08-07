using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace diploma.Pages.Student
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            UpDate();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpDate();
        }

        private void UpDate()
        {
            LViewTest.ItemsSource = App.Context.Tests.ToList();
        }

        private void btnOpenTest_Click(object sender, RoutedEventArgs e)
        {
            var currentService = (sender as Button).DataContext as Entities.Tests;
            if (currentService.CurrentAnswers == 0)
                NavigationService.Navigate(new TestControlPage(currentService));
        }
    }
}
