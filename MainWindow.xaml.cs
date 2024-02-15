using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserPasswordEnumeration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> usersDetails = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool UserNameValidation(string username)
        {
            const string PATTERN = "^[a-zA-Z]\\w{2,9}$";
            return Regex.IsMatch(username, PATTERN);
        }
        private bool PasswordValidation(string password)
        {
            const string PATTERN = "^(?=.*[A-Z\\d])(?=.*[^A-Za-z\\d]).{7,12}$";
            return Regex.IsMatch(password, PATTERN);
        }
        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!UserNameValidation(RegisterUsername.Text))
                {
                    MessageBox.Show("Invalid username.\nusername can have: 3 - 10 chars (including 10), first char must be an English char (lower/ uppercase), the rest of the chars can be digits/ and/ or English characters (lower/ uppercase)");
                    return;
                }
                if (!PasswordValidation(RegisterPassword.Password))
                {
                    MessageBox.Show("Invalid password.\npassword can be between 7 and 12 characters (inclusive), when must contain: at least one capital letter, at least one number and at least one special character.");
                    return;
                }
                string username = RegisterUsername.Text;
                string password = RegisterPassword.Password;
                usersDetails[username] = password;
                MessageBox.Show("Registration process completed successfuly!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string enteredUsername = LoginUsername.Text;
                string enteredPassword = LoginPassword.Password;
                if (usersDetails.ContainsKey(enteredUsername) && usersDetails[enteredUsername] == enteredPassword)
                {
                    MessageBox.Show($"Login successful!\nUsername: {enteredUsername}\nPassword: {enteredPassword}");
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}