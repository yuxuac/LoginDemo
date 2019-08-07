using LoginDemo.Base;
using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDemo.Base
{
    public class CaptchaValidator : IValidateCaptcha
    {
        public bool? IsValid(string input, HttpContext context)
        {
            var flag = false; 
            var captchaInSession = context.Session["captcha"];
            if (captchaInSession != null && (string)captchaInSession == input.ToUpper())
            {
                flag = true;
            }
            return flag;
        }
    }
}