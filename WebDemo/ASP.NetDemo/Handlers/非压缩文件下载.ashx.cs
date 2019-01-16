using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ASP.NetDemo.Handlers
{
    /// <summary>
    /// 非压缩文件下载 的摘要说明
    /// </summary>
    public class 非压缩文件下载 : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/JPG";
            //获取文件名
            var filename = context.Request.Params["filename"];
            //文件名编码
            var codedName = HttpUtility.UrlEncode(filename + ".jpg");
            
            context.Response.AddHeader("Content-Disposition","attachment;filename="+codedName);
            context.Response.WriteFile("~/res/"+codedName);
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