using LoginDemo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LoginDemo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // 1. 注册路由
            RouteTable.Routes.Add(CustomRouteGenerator.GetRoute<Login>("login"));
            RouteTable.Routes.Add(CustomRouteGenerator.GetRoute<Users>("users"));
            RouteTable.Routes.Add(CustomRouteGenerator.GetRoute<Captcha>("captcha"));
            RouteTable.Routes.Add(CustomRouteGenerator.GetRoute<Logoff>("logoff"));

            Logging.Setup(log4net.Core.Level.All);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}