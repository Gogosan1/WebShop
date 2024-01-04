using System;
using System.Windows;
using WebShop.DB;
using WebShop.Model;
 
namespace WebShop.V
{

    public partial class GoodWindow : Window
    {
        private GodMode _mode;
        private User account;
        public GoodWindow(User user)
        {
            InitializeComponent();
            _mode = new GodMode();
            shops.ItemsSource = _mode.shops;
            stoks.ItemsSource = _mode.stoks;
            Counterparties.ItemsSource = _mode.counterparties;
            GoodsDataGrid.ItemsSource = _mode.products;
            account = user;
        }

        
        // обработка ошибок
        private void DeleteShop_Click(object sender, RoutedEventArgs e)
        {
            Shop shop = (Shop)shops.SelectedItems[0];
            _mode.DeleteSturcturalSubdivision(shop.Name);
        }

        private void AddShop_Click(object sender, RoutedEventArgs e)
        {
            int typeId = 2;
            try {
                _mode.AddStructuralSubdivision(typeId, shopName.Text, shopAddress.Text, (long)account.OrganizationId);
            }
            catch(Exception ex)
            {
                errorAddShop.Text = ex.Message;
            }
        }


        private void AddStok_Click(object sender, RoutedEventArgs e)
        {
            int typeId = 1;
            try
            {
                _mode.AddStructuralSubdivision(typeId, shopName.Text, shopAddress.Text, (long)account.OrganizationId);
            }
            catch (Exception ex)
            {
                errorAddStock.Text = ex.Message;
            }
        }

        // обработка ошибок
        private void DeleteStok_Click(object sender, RoutedEventArgs e)
        {
            Stok stock = (Stok)stoks.SelectedItems[0];
            _mode.DeleteSturcturalSubdivision(stock.Name);
        }

     

        
     /*   private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _mode.AddCounterparty(Convert.ToInt64(innTextBox.Text), BanksNameTextBox.Text, Convert.ToInt64(currentAccountNumberTextBox.Text), NameTextBox.Text);
            }
            catch (Exception ex)
            {
                errorAddCounterparty.Text = ex.Message;
            }
        }*/
    }
}
