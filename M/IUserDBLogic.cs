using Kursach.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.M
{
    public interface IUserDBLogic
    {
        public void AddUserToTable(IUser user);
        public void SignIn(IUser user);

    }
}
