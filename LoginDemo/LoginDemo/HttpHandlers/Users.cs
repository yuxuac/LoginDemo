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
                var userInSession = (User)context.Session["loginUser"];
                var currentUser = LoginValidator.Users.Where(u => u.UserName == userInSession.UserName).FirstOrDefault();
                var users = LoginValidator.Users;
                IValidateLogin obj = new LoginValidator();
                if (obj.IsValidLogin(currentUser) == true)
                {
                    var respObj = new
                    {
                        currentUser,
                        users
                    };

                    OK(Response, Utility.Serialize(respObj));
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