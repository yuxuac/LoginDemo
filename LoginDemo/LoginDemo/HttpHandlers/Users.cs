using LoginDemo.Base;
using LoginDemo.DataModel;
using LoginDemo.DataModel.Model;
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
                context.Session[SessionKeys.LoginUser] != null)
            {
                var userInSession = (User)context.Session[SessionKeys.LoginUser];
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

                    OK(Response, new DataModel.Model.JsonResponse() { respObj = respObj, code = RespCode.ok, message = "ok"});
                }
                else
                {
                    OK(Response, new DataModel.Model.JsonResponse() { code = RespCode.notok, message = "invalid" });
                }
            }
            else
            {
                OK(Response, new DataModel.Model.JsonResponse() { code = RespCode.notok, message = "redirectToLogin" });
            } 
        }
    }
}