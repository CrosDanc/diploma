using diploma.Entities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace diploma.Pages.Student
{
    /// <summary>
    /// Логика взаимодействия для TestControlPage.xaml
    /// </summary>
    public partial class TestControlPage : Page
    {
        private Tests _test;
        private int _time = 600;
        private static Entities.TestsStudentEntities _Entiti { get; } = new TestsStudentEntities();
        public TestControlPage(Entities.Tests test)
        {
            InitializeComponent();
            _test = test;
            NameTest.Text = "Название теста: " +test.Title;
            UpDate();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            AnswersFalse();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timerText.Text = "Осталось секунд: " + Convert.ToString(_time);
            _time--;
            if (_time <= 0)
                AnswersCurrent();
        }

        private void UpDate()
        {
            QuestionsItem.ItemsSource = _test.Questions;
        }

        private void CompletedTest_Click(object sender, RoutedEventArgs e)
        {
            AnswersCurrent();
        }

        private void AnswersFalse()
        {
            foreach(Questions questions in _test.Questions)
            {
                foreach(Answers answers in questions.Answers)
                {
                    answers.IsTrue = false;
                }
            }
        }

        private void AnswersCurrent()
        {
            
            foreach (Questions questions in _test.Questions)
            {
                bool CorrectAnswers = true;
                foreach(Answers answers in questions.Answers)
                {
                    int i = answers.Id;
                    var answer = _Entiti.Answers.Find(i);
                        if (answer.IsTrue != answers.IsTrue)
                        {
                            CorrectAnswers = false;
                        }
                }
                if(CorrectAnswers)
                {
                    _test.CurrentAnswers++;
                }
            }
            var test =  _Entiti.Tests.Find(_test.Id);
            test.CurrentAnswers = _test.CurrentAnswers;
            _Entiti.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
