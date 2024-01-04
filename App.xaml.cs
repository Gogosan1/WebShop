using System;
using System.Windows;
using WebShop.V;

namespace WebShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        [STAThread]
        static void Main()
        {
            Window view = new LoginWindow();

            App app = new App();
            app.Run((Window)view);
        }
    }
}
