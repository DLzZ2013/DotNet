using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Page
{
    public partial class Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("GOGOGOOoooo");
            }
            else
            {
                var name = Request.QueryString["username"];
                var name1 = Request.Params["username"];
                var password = Request.QueryString["password"];
                Response.Write(name + "--" + password);                
                
            }
            
        }
    }
}