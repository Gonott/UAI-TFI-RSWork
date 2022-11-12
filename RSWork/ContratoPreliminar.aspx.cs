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
    public partial class ContratoPreliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                LlenarDatosEmpleados();
                LlenarPagos();
                LlenarCabeceraContrato();
                //llenar data grid de empleados
                //llenar dadta grid de pagos.
            }

        }




        public void LlenarDatosEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            empleados = (List<Empleado>)Session["empleadosSeleccionados"];
            GrillaEmpleadosSeleccionados.DataSource = empleados;
            GrillaEmpleadosSeleccionados.DataBind();
        
        }


        public void LlenarPagos()
        {
            Contrato contratoFinal = new Contrato();
            contratoFinal = (Contrato)Session["ContratoFinal"];
            List<Pago> pagos = new List<Pago>();
            pagos = contratoFinal.pagos;
            GridViewPagos.DataSource = pagos;
            GridViewPagos.DataBind();
            
        }

        public void LlenarCabeceraContrato()
        {
            //Contrato uncontrato = new Contrato();
            Contrato uncontrato = (Contrato)Session["ContratoFinal"];
            Publicacion publicacion = new Publicacion();
            publicacion = (Publicacion)Session["PublicacionContratada"];
            BLLElemento elmbll = new BLLElemento();
            Elemento elemento = elmbll.Seleccionar(publicacion.codElemento);
            lblfecha.Text = uncontrato.FechaContrato.ToString();
            lblfinicio.Text = uncontrato.FechaInicio.ToString();
            lblffin.Text = uncontrato.FechaFinal.ToString();
            lblmonto.Text = uncontrato.Monto.ToString();
            lblcantelem.Text = uncontrato.Elementos.Count() + " " + elemento.Descripción + " " + elemento.Caracteristicas;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                ContratoBLL contratobll = new ContratoBLL();
                Contrato contrato = new Contrato();
                contrato = (Contrato)Session["ContratoFinal"];
                Publicacion publicacion = new Publicacion();
                publicacion = (Publicacion)Session["PublicacionContratada"];
                List<Empleado> empleados = new List<Empleado>();
                empleados = (List<Empleado>)Session["empleadosSeleccionados"];
                BLLElemento elmbll = new BLLElemento();
                Elemento elemento = elmbll.Seleccionar(publicacion.codElemento);
                elemento.cantidad = empleados.Count();
                contrato.Elementos.Add(elemento);
                contratobll.AltaContrato(contrato);
                Response.Write("<script>alert('Se ha dado de alta el contrato Exitosamente')</script>");
                Response.Redirect("PerfilCliente.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}