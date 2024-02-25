using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItayProject.WebPages
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public bool Admin { get; set; }
        public bool Login { get; set; }
        public User()
        {
            UserId = -1;
            UserName = "";
            FirstName = "";
            LastName = "";
            Password = "";
            Phone = 0;
            Email = "";
            Admin = false;
            Login = false;
        }
        public User(int userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }

    }
}
