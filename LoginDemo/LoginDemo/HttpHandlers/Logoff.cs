using LoginDemo.Base;
using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginDemo.DataModel.Model;

namespace LoginDemo
{
    public class Logoff : HttpSyncHandler
    {
        protected override void Post(HttpContext context)
        {
            if (context.Session != null &&
                context.Session[SessionKeys.LoginUser] != null)
            {
                var currentUser = LoginValidator.Users.Where(u => u.UserName == ((User)context.Session["loginUser"]).UserName).FirstOrDefault();
                currentUser.LogoffTime = DateTime.Now;
                context.Session.Remove(SessionKeys.LoginUser);
                OK(Response, new JsonResponse() { code = RespCode.redirect, message = "redirect", respObj = "/views/login.html" });
            }
            else
            {
                OK(Response, new JsonResponse() { code = RespCode.notok, message = "failed." });
            }
        }
    }
}