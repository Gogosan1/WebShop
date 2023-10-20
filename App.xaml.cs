using System;
using System.Windows;
using WebShop.M;
using WebShop.Pr;
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
            IView view = new Window1();
            IUserDBLogic UserDBLogic = new UserDBLogic();
            var presenter = new UserLogInPresenter(view,UserDBLogic);

            App app = new App();
            app.Run((Window)view);
        }
    }
}
