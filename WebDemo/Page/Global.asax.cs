using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Page
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Visitor"] = 0;
            Application.UnLock();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Visitor"] = (int)Application["Visitor"] + 1;
            Application.UnLock();
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
            //在会话结束时运行的代码
            //注意：在web.config文件中，把sessionstate模式设置为InPro时才引发此事件
            Application.Lock();
            Application["Visitor"] = (int)Application["Visitor"]-1;
            Application.UnLock();
            Server.MapPath("~/UploadFiles");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}