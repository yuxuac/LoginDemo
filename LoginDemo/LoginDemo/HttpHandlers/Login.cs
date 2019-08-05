using LoginDemo.Base;
using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDemo
{
    public class Login : HttpSyncHandler
    {
        protected override void Post(HttpContext context)
        {
            var user = Utility.Deserialize<User>(GetReceivedContent(context));
            IValidateLogin obj = new LoginValidator();
            if (obj.IsValidLogin(user) == true)
            {
                context.Session.Add("loginUser", user);
                OK(Response, "1-valid");
            }
            else
            {
                OK(Response, "0-invalid");
            }
            
        }
    }
}