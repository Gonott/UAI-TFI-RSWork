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
    public partial class PerfilCliente : System.Web.UI.Page
    {
        ClienteBLL clientebll = new ClienteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatosEmpresa();
            }
        }


        private void CargarDatosEmpresa()
        { 
            Usuario usuarioActual = new Usuario();
            Cliente estaEmpresa = new Cliente();
            estaEmpresa = (Cliente)Session["Cliente"];
            usuarioActual = (Usuario)Session["Usuario"];
            LabelCod.InnerText = "Cod. " + estaEmpresa.CodigoCliente.ToString();
            LabelCUIT.InnerText = "CUIT "+ estaEmpresa.CUIT.ToString();
            txtBoxTelefono.Text = estaEmpresa.Telefono;
            txtBoxDireccion.Text = estaEmpresa.Direccion;
            LabelCat.InnerText = "Cat. "+ estaEmpresa.Categoria.ToString();
            LabelNombreEmp.InnerText = estaEmpresa.Nombre;
            txtboxEmail.Text = estaEmpresa.email;
        
        }

        protected void ModificarBtn_Click(object sender, EventArgs e)
        {
            
                Cliente estaEmpresa = (Cliente)Session["Cliente"];
                estaEmpresa.Telefono = txtBoxTelefono.Text.ToString();
                estaEmpresa.Direccion = txtBoxDireccion.Text;
                estaEmpresa.email = txtboxEmail.Text;
                clientebll.ModificarCliente(estaEmpresa);
                Session["Cliente"] = null;
                Session["Cliente"] = estaEmpresa;
                CargarDatosEmpresa();
            
            


            

        }
    }
}