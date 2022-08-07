using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace diploma.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginTeacherPage.xaml
    /// </summary>
    public partial class LoginTeacherPage : Page
    {
        public LoginTeacherPage()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                if(TextBoxPassword.Text == "a")
                {
                    NavigationService.Navigate(new Pages.Admin.AdminPage());
                }
                else
                {
                    MessageBox.Show("Не верный пароль");
                }
            }
        }
    }
}
