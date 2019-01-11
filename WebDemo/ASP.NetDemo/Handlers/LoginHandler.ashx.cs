using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NetDemo.Handlers
{
    /// <summary>
    /// 一般处理程序
    /// </summary>
    public class LoginHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var username = context.Request.Params["username"];
            var password = context.Request.Params["password"];
            context.Response.Write("Info:"+username+" -- "+password);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}