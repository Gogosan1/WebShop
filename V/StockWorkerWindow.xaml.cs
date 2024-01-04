using System.Windows;
using WebShop.DB;
using WebShop.Model;

namespace WebShop.V
{
    /// <summary>
    /// Логика взаимодействия для StockWorkerWindow.xaml
    /// </summary>
    public partial class StockWorkerWindow : Window
    {
        private StockMode stock;
        private User account;
        public StockWorkerWindow(User user)
        {
            InitializeComponent();
           // stock = new StockMode(user.);
        }

        public StockWorkerWindow(string stockName)
        {
            InitializeComponent();
            stock = new StockMode();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
