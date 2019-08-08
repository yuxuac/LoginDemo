using LoginDemo.Base;
using LoginDemo.DataModel;
using LoginDemo.DataModel.Model;
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
            var user = Utility.Deserialize<UserLogin>(GetReceivedContent(context));
            IValidateLogin validateLogin = new LoginValidator();
            IValidateCaptcha validateCaptcha = new CaptchaValidator();

            if (validateLogin.IsValidLogin(user) == true &&
                validateCaptcha.IsValid(user.Captcha, context) == true)
            {
                var currentUser = LoginValidator.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                currentUser.LoginTime = DateTime.Now;
                context.Session.Remove(SessionKeys.Captcha);
                context.Session.Add(SessionKeys.LoginUser, user);
                OK(Response, new JsonResponse() { code = RespCode.redirect, message = "ok", respObj = "/views/workpanel.html" });
            }
            else
            {
                OK(Response, new JsonResponse() { code = RespCode.notok, message = "failed" });
            }
        }
    }
}