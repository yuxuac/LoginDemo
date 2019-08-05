using LoginDemo.Base;
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
                return new List<User>()
                {
                    new User() { ID = 1, UserName = "nezha", Password = "abc.123", DisplayName = "哪吒" },
                    new User() { ID = 2, UserName = "aobing", Password = "abc.123", DisplayName = "敖丙" },
                    new User() { ID = 3, UserName = "taiyizhenren", Password = "abc.123", DisplayName = "太乙真人" },
                    new User() { ID = 4, UserName = "shengongbao", Password = "abc.123", DisplayName = "申公豹" },
                    new User() { ID = 5, UserName = "yuanshitianzun", Password = "abc.123", DisplayName = "元始天尊" },
                };
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