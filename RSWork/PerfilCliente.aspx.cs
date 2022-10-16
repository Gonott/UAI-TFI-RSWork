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
        Empleado emptemporal = new Empleado();
        EmpleadoBLL empBLL = new EmpleadoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatosEmpresa();
                EnlazarEmpleados();
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
            catch (Exception ex)
            {

                throw ex;
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
                Response.Write("<script>alert('El Cliente fue dado de baja'); window.location='PerfilCliente.aspx'</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('El Cliente no pudo ser dado de baja'); window.location='PerfilCliente.aspx'</script>");
                throw;
            }
        }



        protected void BtnModificar_Click(object sender, EventArgs e)
        {

            emptemporal.DNI = int.Parse(TextBoxDNI.Text.ToString());
            emptemporal.Nombre = TextBoxNombreEmp.Text.ToString();
            emptemporal.Dirección = TextBoxDireccionEmp.Text.ToString();
            emptemporal.Email = TextBoxEmail.Text.ToString();
            try
            {
                empBLL.modificar(emptemporal);
                EnlazarEmpleados();
                LimpiarTextEmpleados();
            }
            catch (Exception ee)
            {

                throw ee;
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
            //grillaEmpleados.Columns[0].Visible = false;
        }


        protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            Empleado emptemp= new Empleado();
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


        
        
        private void LimpiarTextEmpleados()
        {

            TextBoxDNI.Text = "";
            TextBoxNombreEmp.Text = " ";
            TextBoxEmail.Text = "";
            TextBoxDireccionEmp.Text = "";
        }
    }
}