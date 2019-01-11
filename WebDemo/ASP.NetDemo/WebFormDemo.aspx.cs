using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NetDemo
{
    public partial class WebFormDemo : System.Web.UI.Page
    {
        //回发：
        /*当用户操作让表单产生submit时产生回发
         *当前页面被递交给服务器处理，处理时服务器会对当前页面重新加载（绘制）
         * Load事件：不管是首次加载还是回发网页都会激发Load事件
         * AutoEventWireup = true
         */
        protected void InitializeComponent()
        {
            this.Load += this.Page_Load;
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            //Page为页面内置对象
            if (IsPostBack)
            {
                //判断是第一次呈现还是为了响应回发而加载
            }
        }
        //ASP.Net中的默认按钮都是submit类型，能够提交表单
        //点击按钮后，页面的_VIETSTATE隐藏域将控件的状态提交到服务器
        //服务器刷新Page_Load重新执行，执行请求（WebForm页面就是请求自己）
        //返回html响应，及返回控件状态
        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }
    }
}