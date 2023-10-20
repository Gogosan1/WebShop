using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WebShop.V
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window, IView 
    {
        public Window1()
        {
            InitializeComponent();
        }


        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = SignInLoginTextBox.Text;
            string password = SignInPasswordTextBox.Text;
            

            try
            {
                var eventArgs = new SignInOrUpEventArgs(login,password);
                SignInButtonClickHandler?.Invoke(this, eventArgs);
            }
            catch(Exception ex)
            {
                SignInWindowErrorsTextBlock.Text = ex.Message;
            }
        }

        public event EventHandler<SignInOrUpEventArgs> SignUpButtonClickHandler;
        public event EventHandler<FogotPasswordEventArgs> FogotPasswordButtonClickHandler;
        public event EventHandler<SignInOrUpEventArgs> SignInButtonClickHandler;

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string login = SignUpLoginTextBox.Text;
            string password = SignUpPasswordTextBox.Text;
            string repeatPassword = SignUpRepeatPasswordTextBox.Text;

            if (!repeatPassword.Contains(password))
            {
                SignUpWindowErrorsTextBlock.Text = "Ошибка пароли не совпадают!";
                return;
            }

            try
            {
                var eventAgrs = new SignInOrUpEventArgs(login,password);
                SignUpButtonClickHandler?.Invoke(this, eventAgrs);
            }
            catch( Exception ex ) 
            {
                SignUpWindowErrorsTextBlock.Text = ex.Message;
            }
        }
    }
    public class SignInOrUpEventArgs : EventArgs
    {
        public SignInOrUpEventArgs(string login, string password)
        {
            if (login.Length == 0 || !login.Contains('@'))
                throw new ArgumentException("Ошибка! Email некорректный");
  
            if (password.Length == 0)
                throw new ArgumentException("Ошибка! Пароль не может отсутсвовать!");
            
            Login = login;
            Password = password;
        }
        public string Login { get; private set; }
        public string Password { get; private set; }
    }
    public class FogotPasswordEventArgs :EventArgs
    {
        public string Login { get; private set; }
    }
}
