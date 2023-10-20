using Kursach.Data;
using Microsoft.Data.Sqlite;
using System;

namespace WebShop.M
{
    public class UserDBLogic : IUserDBLogic
    {
        // вызывается только при нажатии на кнопку регистрации
        public void AddUserToTable(IUser user)
        {
            if (!CheckEmailExist(user.Email))
            {
                using (var connection = new SqliteConnection("Data Source=Users.db"))
                {
                    // прежде чем добавлять в бд пароль нужно его захэшировать и посолить
                    // плюс добавлять соль в бд
                    string sqlExspression = $"INSERT INTO Users ('login', 'password') VALUES ('{user.Email}','{user.Password}');";
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExspression, connection);
                    
                    sqlExspression = $"SELECT * FROM Users WHERE login='{user.Email}';";
                    command = new SqliteCommand(sqlExspression, connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            user.Role = Convert.ToString(reader["role"]);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("This email is already exist!");
            }

        }

        // происходит при нажатии на кнопку войти
        public void SignIn(IUser user)
        {
            if (CheckEmailExist(user.Email))
            {
                using (var connection = new SqliteConnection("Data Source=Users.db"))
                {
                    string sqlExspression = $"SELECT * FROM Users WHERE login='{user.Email}'";
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExspression, connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) //??? узнать не лишняя ли проверка ???//
                        {
                            reader.Read();
                            // прежде чем сравнивать необходимо расхешировать с помощью соли
                            if (user.Password == Convert.ToString(reader["password"]))
                            {
                            //??? возможно стоит менять соль в бд при успешном входе ???//
                                user.Role = Convert.ToString(reader["role"]);
                                /// вощвращать роль в делегате когда успешный вход ///
                            }
                            else
                            {
                                throw new ArgumentException("Password isn't correct!", user.Password);
                            }
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("This email doesn't exist!",user.Email);
            }
        }

        private bool CheckEmailExist(string email)
        {
            string SqliteException = $"SELECT login FROM Users WHERE login='{email}'";

            using (var connection = new SqliteConnection("Data Source=Users.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(SqliteException, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToString(reader["login"]) == email)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        private void ChangePassword()
        {
            // UPDATE
        }
        private void DeleteUser()
        {
            // DELETE
        }
    }
}
