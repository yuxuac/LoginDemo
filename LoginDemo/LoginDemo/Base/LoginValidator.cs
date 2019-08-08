using LoginDemo.Base;
using LoginDemo.DataAccess;
using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDemo.Base
{
    public class LoginValidator : IValidateLogin
    {
        public static List<User> Users
        {
            get
            {
                return DB.GetUsers();
            }
        }

        public bool? IsValidLogin(User input)
        {
            bool flag = false;
            if (Users.Any(u => u.UserName == input.UserName &&
                               u.Password == input.Password))
            {
                flag = true;
            }
            return flag;
        }
    }
}