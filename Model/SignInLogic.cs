using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.DB;

namespace WebShop.Model
{
    public class SignInLogic
    {
        public User GetUser(string login, string password)
        {
            using (WebShopContext webShopContext = new WebShopContext())
            {
                bool existringFlag = false;
                var users = webShopContext.Users.ToList();
                foreach (var user in users)
                {
                    if (user.Login == login)
                    {
                       existringFlag |= true;
                        if (user.Password == password)
                        {
                            return user;
                        }
                        else
                            throw new Exception("Пароль неверный!");
                    }
                }
                if (!existringFlag) 
                {
                    throw new Exception($"{login} логина не существует!");
                }
            }
            throw new Exception("Ошибка подключения к БД");
        }
    }
}
