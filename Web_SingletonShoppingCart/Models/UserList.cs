using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SingletonShoppingCart.Models
{
    public class UserList
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User { Id = 1, Name = "User1" });
            users.Add(new User { Id = 2, Name = "User2" });
            users.Add(new User { Id = 3, Name = "User3" });
            users.Add(new User { Id = 4, Name = "User4" });

            return users;
        }
    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}