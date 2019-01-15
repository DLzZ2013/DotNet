using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page.Test
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //地址栏变化
            Response.Redirect("../Request.aspx");
            //当在trycatch块中时终止页面的运行
            Response.Redirect("../Request.aspx",false);
            //地址栏不变化
            Server.Transfer("./Request.aspx");
        }
    }
}