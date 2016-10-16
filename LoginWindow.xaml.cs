using System.Windows;
using System.Windows.Input;
using PublicEventsManager.Repositories;
using PublicEventsManager.BusinessLogic;
using PublicEventsManager.Entities;
using System.Configuration;

namespace PublicEventsManager
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["PublicEventsManagerConnectionString"].ConnectionString;
        private readonly ManagerRepository _managerRepository;

        public LoginWindow()
        {
            InitializeComponent();
            _managerRepository = new ManagerRepository(_connectionString);

            FocusManager.SetFocusedElement(this, loginTextBox);
            Keyboard.Focus(loginTextBox);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            
            // string password = passwordBox.Password;
            string password = MD5Hash.CalculateMD5Hash(passwordBox.Password);

            Manager manager = _managerRepository.GetManagerByLogin(login, password);

            if (manager != null)
            {
                CurrentManager.Authorize(manager);
                this.DialogResult = true;         
            }
            else
            {
                MessageBox.Show(this, "Invalid manager login or password");
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
