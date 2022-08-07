using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace diploma.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {

        public AdminPage()
        {
            InitializeComponent();            UpDateTests();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        } 

        private void timer_Tick(object sender, EventArgs e)
        {
            UpDateTests();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentService = (sender as Button).DataContext as Entities.Tests;

            if(MessageBox.Show("Уверены что хотите удалить: " + $"{currentService.Title}?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if(currentService.Questions != null)
                while (currentService.Questions.Count > 0)
                {
                    var FirstQuestions = currentService.Questions.First();
                    if (FirstQuestions.Answers != null)
                    {
                        while (FirstQuestions.Answers.Count > 0)
                        {
                            App.Context.Answers.Remove(FirstQuestions.Answers.First());
                        }
                    }
                    App.Context.Questions.Remove(currentService.Questions.First());
                }

                App.Context.Tests.Remove(currentService);
                App.Context.SaveChanges();
                UpDateTests();
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentService = (sender as Button).DataContext as Entities.Tests;
            NavigationService.Navigate(new AddEditTestPage(currentService));
        }
        private void UpDateTests()
        {
            LViewTest.ItemsSource = App.Context.Tests.ToList();
        }

        private void AddTest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditTestPage());
        }

    }
}
