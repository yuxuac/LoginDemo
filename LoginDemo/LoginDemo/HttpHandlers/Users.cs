using LoginDemo.Base;
using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDemo
{
    public class Users : HttpSyncHandler
    {
        protected override void Get(HttpContext context)
        {
            if (context.Session != null && 
                context.Session["loginUser"] != null)
            {
                var user = (User)context.Session["loginUser"];

                IValidateLogin obj = new LoginValidator();
                if (obj.IsValidLogin(user) == true)
                {
                    OK(Response, Utility.Serialize(LoginValidator.Users));
                }
                else
                {
                    OK(Response, "0-invalid");
                }
            }
            else
            {
                OK(Response, "-2-redirectToLogin");
            } 
        }
    }
}