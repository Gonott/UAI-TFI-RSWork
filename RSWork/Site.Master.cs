using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

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
            {
                Usuario usu = new Usuario();
                usu = (Usuario)Session["Usuario"];
                if (usu.empresa.GetType() == typeof(Cliente))
                {
                    Response.Redirect("PerfilCliente.aspx");
                    //llevar perfil cliente
                }
                if(usu.empresa.GetType()==typeof(Proveedor))
                {
                    //llevar a perfil proveedor
                    Response.Redirect("PerfilProveedor.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Ha ocurrido un error, contacta a soporte')</script>");
                }
            }
        }

        protected void LogoHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}