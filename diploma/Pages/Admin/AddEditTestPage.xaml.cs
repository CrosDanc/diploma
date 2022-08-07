using diploma.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace diploma.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddEditTestPage.xaml
    /// </summary>
    public partial class AddEditTestPage : Page
    {
        public Tests _test;
        Questions _Question;
        public AddEditTestPage()
        {
            InitializeComponent();
            _test = new Tests();
        }

        public AddEditTestPage(Entities.Tests tests)
        {
            InitializeComponent();
            _test = tests;
            TitleTest.Text = tests.Title;

            _Question = _test.Questions.Last();
            Question();
        }

        public void Question()
        {
            App.Context.SaveChanges();
            QuestionsItem.ItemsSource = _test.Questions.ToList();
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            _Question = new Questions();
            _test.Questions.Add(_Question);

            Question();
        }

        private void AddAnswer_Click(object sender, RoutedEventArgs e)
        {
            if(_Question != null)
            {
                _Question.Answers.Add(new Answers() { IsTrue = false});
            }
            Question();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            _test.CurrentAnswers = 0;
            if (App.Context.Tests.Find(_test.Id) == null)
                App.Context.Tests.Add(_test);
            App.Context.SaveChanges();
            NavigationService.GoBack();
            
        }

        private void TitleTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            _test.Title = TitleTest.Text;
        }
        //
    }
}