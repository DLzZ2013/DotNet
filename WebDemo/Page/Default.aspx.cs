using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page
{
    //对象名称           |存储位置       |有效时间  |信息共享范围
    //Request, Response |请求和响应过程中|请求结束前|-次请求的一一个页面
    //ViewState |被请求的页面中|页面关闭前|多次请求的一个页面
    //Session |Web服务器端|规定时间内|同一网站的不同页面
    //Cookie |客户端的硬盘中|规定时间内|同一网站的不同页面
    //Application |Web服务器I端|IIS重启前|整个应用程序中
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("当前访客数：" + Application["Visitor"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Write("当前访客数：" + Application["Visitor"]);
        }
    }
}