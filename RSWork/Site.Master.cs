using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RSWork
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPerfil_Click(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null)
            //    Request.Cookies["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if(this.Session["Usuario"].ToString() != null)
                //(Request.Cookies["Usuario"]!= null)
            {
                Response.Redirect("PerfilProveedor.aspx");
            }
        }
    }
}