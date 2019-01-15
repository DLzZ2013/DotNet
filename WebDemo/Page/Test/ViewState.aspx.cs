using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page
{

    //键值对保存
    //ViewSite中保存的数据全部被转成object类型，取出时要强制转成特定类型
    //只能在同一个页面的连续多个请求之间保存信息，页面跳转后信息丢失
    //事件驱动模型编程(控件+事件)
    //HTML控件没有回传,不能用ViewState维持状态
    public partial class ViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["counter"] = 0;
            }           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var count = (int)ViewState["counter"];
            count++;
            ViewState["counter"] = count;
            Response.Write(count);
        }
    }

}