using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDemo.DataModel
{
    public class UserLogin : User
    {
        public string Captcha { get; set; }
    }
}