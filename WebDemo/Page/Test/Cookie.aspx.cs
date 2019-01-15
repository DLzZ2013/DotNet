using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page
{
    public partial class Cookie : System.Web.UI.Page
    {
        //存储少量不重要的数据
        //存储在客户端的文本文件中（必须设置有效期，否则不被存储）
        //安全性差
        //存储的数据类型一一字符串浏览器窗口无关，但与访问的站点相关
        //具体特定的过期时间和日期
        //在客户端存储后，将随着浏览器对相关网站页面请求而一并发送到 Web 服务器
        protected void Page_Load(object sender, EventArgs e)
        {
            //创建
            Response.Cookies["username"].Value = "DLzZ";
            var cookies = new HttpCookie("username","DLzZ");
            Response.Cookies.Add(cookies);
            var str = Request.Cookies["username"];
            //保存有效期
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(1.0);
        }
    }
}