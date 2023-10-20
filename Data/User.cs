using System;
using System.Windows.Data;
using Microsoft.Data.Sqlite;

namespace Kursach.Data
{
    public class User : IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }

        public User (string email, string password)
        {
           if (email == null || !email.Contains('@'))
               throw new ArgumentException("Uncorrect email address!");
            Email = email;
            Password = password ?? throw new ArgumentException("Uncorrect password!");
        }

    }
}
