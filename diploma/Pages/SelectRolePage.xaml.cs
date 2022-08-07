using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace diploma.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectRolePage.xaml
    /// </summary>
    public partial class SelectRolePage : Page
    {
        public SelectRolePage()
        {
            InitializeComponent();
        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.LoginTeacherPage() );
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Student.StudentPage());
        }
    }
}
