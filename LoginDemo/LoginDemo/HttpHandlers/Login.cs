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
            var user = Utility.Deserialize<UserLogin>(GetReceivedContent(context));
            IValidateLogin validateLogin = new LoginValidator();
            IValidateCaptcha validateCaptcha = new CaptchaValidator();

            if (validateLogin.IsValidLogin(user) == true &&
                validateCaptcha.IsValid(user.Captcha, context) == true)
            {
                context.Session.Remove("captcha");
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