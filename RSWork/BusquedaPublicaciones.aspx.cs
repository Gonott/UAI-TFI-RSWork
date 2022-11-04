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
    public partial class BusquedaPublicaciones : System.Web.UI.Page
    {
        List<Publicacion> publicaciones = new List<Publicacion>();
        PublicacionBLL publl = new PublicacionBLL();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarTodas();
            }
        }

        private void CargarTodas()
        {

            publicaciones = publl.ListarTodas();
            DataListPublicaciones.DataSource = publicaciones;
            DataListPublicaciones.DataBind();
        }

    }
}