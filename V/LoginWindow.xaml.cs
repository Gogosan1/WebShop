using System;
using System.Windows;
using WebShop.DB;
using WebShop.Model;

namespace WebShop.V
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            SignInWindowErrorsTextBlock.Visibility = Visibility.Visible;
            SignInWindowErrorsTextBlock.Text = string.Empty;
            try
            {
                SignInLogic signInLogic = new SignInLogic();
                User user = signInLogic.GetUser(SignInLoginTextBox.Text, SignInPasswordTextBox.Text);
                
                if (user.RoleId == 1)
                {
                    GoodWindow goodWindow = new GoodWindow(user);
                    this.Close();
                    goodWindow.Show();
                }
                if (user.RoleId == 2)
                {
                    ShopWorkerWindow shopWorker = new ShopWorkerWindow();
                    this.Close();
                    shopWorker.Show();
                }
                if (user.RoleId == 3)
                {
                   // StockWorkerWindow stokWorker = new StockWorkerWindow();
                    this.Close();
                   // stokWorker.Show();
                }
            }
            catch (Exception ex)
            {
                SignInWindowErrorsTextBlock.Text = ex.Message;
            }
        }

    }
}
