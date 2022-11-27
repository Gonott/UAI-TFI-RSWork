using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        Empleado emptemporal = new Empleado();
        EmpleadoBLL empBLL = new EmpleadoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                if ((Cliente)Session["Cliente"] != null)
                {
                    CargarDatosEmpresa();
                    EnlazarEmpleados();
                    EnlazarContratos();

                }
                else
                {
                    Response.Redirect("Default.aspx");
                    
                }
                
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
            try
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
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }
        }

        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                emptemporal.DNI = int.Parse(TextBoxDNI.Text.ToString());
                emptemporal.Nombre = TextBoxNombreEmp.Text.ToString();
                emptemporal.Dirección = TextBoxDireccionEmp.Text.ToString();
                emptemporal.Email = TextBoxEmail.Text.ToString();
                empBLL.alta(emptemporal, (Cliente)Session["Cliente"]);
                EnlazarEmpleados();
                LimpiarTextEmpleados();

            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }
        }


        protected void BtnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                emptemporal.DNI = int.Parse(TextBoxDNI.Text.ToString());
                emptemporal.Nombre = TextBoxNombreEmp.Text.ToString();
                emptemporal.Dirección = TextBoxDireccionEmp.Text.ToString();
                emptemporal.Email = TextBoxEmail.Text.ToString();
                empBLL.baja(emptemporal, (Cliente)Session["Cliente"]);
                EnlazarEmpleados();
                LimpiarTextEmpleados();
                Response.Write("<script>alert('El Empleado fue dado de baja'); window.location='PerfilCliente.aspx'</script>");
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }
        }



        protected void BtnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                emptemporal.DNI = int.Parse(TextBoxDNI.Text.ToString());
                emptemporal.Nombre = TextBoxNombreEmp.Text.ToString();
                emptemporal.Dirección = TextBoxDireccionEmp.Text.ToString();
                emptemporal.Email = TextBoxEmail.Text.ToString();

                empBLL.modificar(emptemporal);
                EnlazarEmpleados();
                LimpiarTextEmpleados();
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }

        }






        private void EnlazarEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            empleados = empBLL.ListarEmpleados((Cliente)Session["Cliente"]);

            grillaEmpleados.DataSource = empleados.Select(emp => new
            {
                Direccion = emp.Dirección,
                Nombre = emp.Nombre,
                Email = emp.Email,
                DNI = emp.DNI
            });

            grillaEmpleados.DataBind();
        }


        protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                Empleado emptemp = new Empleado();
                int dniEmpleado = int.Parse(grillaEmpleados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                string nombreEmpleado = (grillaEmpleados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
                string direccionEmpleado = (grillaEmpleados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
                string emailEmpleado = (grillaEmpleados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text);

                switch (e.CommandName)
                {
                    case "btnSeleccionarEmpleado":
                        {

                            TextBoxDNI.Text = dniEmpleado.ToString();
                            TextBoxNombreEmp.Text = nombreEmpleado.ToString();
                            TextBoxDireccionEmp.Text = direccionEmpleado.ToString();
                            TextBoxEmail.Text = emailEmpleado.ToString();

                            break;
                        }


                }
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }
        }

        
        
        
        private void LimpiarTextEmpleados()
        {

            TextBoxDNI.Text = "";
            TextBoxNombreEmp.Text = " ";
            TextBoxEmail.Text = "";
            TextBoxDireccionEmp.Text = "";
        }



        private void EnlazarContratos()
        {
            ContratoBLL contratoBLL = new ContratoBLL();
            
            List<Contrato> contratos = new List<Contrato>();
            contratos = contratoBLL.ContratosCliente((Cliente)Session["Cliente"]);

            GrillaContratos.DataSource = contratos.Select(cont => new
            {
                NroContrato = cont.NumeroContrato,
                CodProveedor = cont.codProveedor,
                FechaContrato = cont.FechaContrato,
                FechaInicio = cont.FechaInicio,
                FechaFin = cont.FechaFinal,
                Monto = cont.Monto

            }) ;

            GrillaContratos.DataBind();

        }

        protected void GrillaContrato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Contrato conTemp = new Contrato();
                int codContrato = int.Parse(GrillaContratos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                int codProveedor = int.Parse(GrillaContratos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
                DateTime fecContrato = DateTime.Parse(GrillaContratos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
                DateTime fecInicio = DateTime.Parse(GrillaContratos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text);
                DateTime fecFin = DateTime.Parse(GrillaContratos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text);


                switch (e.CommandName) //aca hay que ir a llenar el contrato con los elementos y demás.
                {
                    case "btnVerContrato":
                        {

                            //TextBoxDNI.Text = dniEmpleado.ToString();
                            //TextBoxNombreEmp.Text = nombreEmpleado.ToString();
                            //TextBoxDireccionEmp.Text = direccionEmpleado.ToString();
                            //TextBoxEmail.Text = emailEmpleado.ToString();

                            break;
                        }


                }
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }
        }

        protected void GrillaContratos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CerrarSesionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("Default.aspx");
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }

        }
    }
}