using Kursach.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using WebShop.M;
using WebShop.V;

namespace WebShop.Pr
{
    public class UserLogInPresenter
    {
        public UserLogInPresenter(IView view, IUserDBLogic UserDBLogic) 
        {
            this.view = view;
            this.UserDBLogic = UserDBLogic;
            view.SignUpButtonClickHandler += View_SignUpButtonClickHandler;
            view.SignInButtonClickHandler += View_SignInButtonClickHandler;
        }

        private void View_SignInButtonClickHandler(object? sender, SignInOrUpEventArgs e)
        {
            IUser user = new User(e.Login, e.Password);
            UserDBLogic.SignIn(user);
            //throw new NotImplementedException();
        }

        private void View_SignUpButtonClickHandler(object? sender, SignInOrUpEventArgs e)
        {
            IUser user = new User(e.Login, e.Password);
            UserDBLogic.AddUserToTable(user);
            
            //throw new NotImplementedException();
        }

        private IView view;
        private IUserDBLogic UserDBLogic;
    }
}
