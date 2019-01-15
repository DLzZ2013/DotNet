using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page
{
    public partial class Session : System.Web.UI.Page
    {
        //SessionID、Timeout
        //Add(),Remove(),Clear(),Abandon()
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = new List<string>();
                Session["list"] = list;
            }
        }
    }
}