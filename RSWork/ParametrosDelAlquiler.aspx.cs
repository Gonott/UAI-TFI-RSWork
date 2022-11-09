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
    public partial class ParametrosDelAlquiler : System.Web.UI.Page
    {
        Publicacion publicacionTemporal = new Publicacion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //cargar cosas
            }

        }







    }    
 


}