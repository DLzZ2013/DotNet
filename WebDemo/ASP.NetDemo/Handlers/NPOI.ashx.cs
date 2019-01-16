using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.XSSF;
namespace ASP.NetDemo.Handlers
{
    /// <summary>
    /// NPOI 的摘要说明
    /// </summary>
    public class NPOI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //设置输出类型
            context.Response.ContentType = "application/x-excel";
            //将http头添加到输出流，设置默认导出文件名

            context.Response.Write("Hello World");
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