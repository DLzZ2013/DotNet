using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.ServiceReference1;
namespace WebService
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tel = "13648075413";
            ServiceReference1.MobileCodeWSSoapClient mbphone = new MobileCodeWSSoapClient();
            var msg = mbphone.getMobileCodeInfo(tel, null);
            Response.Write(msg);
        }
    }
}