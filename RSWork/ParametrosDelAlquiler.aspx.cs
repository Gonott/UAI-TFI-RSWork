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

        EmpleadoBLL empBLL = new EmpleadoBLL();
        
        BLLElemento elementobll = new BLLElemento();
        Elemento elemento = new Elemento();
        List<Empleado> empleadosSeleccionados = new List<Empleado>();
        List<Empleado> empleados = new List<Empleado>();
        Contrato contrato = new Contrato();
        ContratoBLL contratoBll = new ContratoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                if (Session["Cliente"] != null)
                {

                    empleados = empBLL.ListarEmpleados((Cliente)Session["Cliente"]);
                    EnlazarEmpleados(empleados);
                    LlenarDatosPublicacionElemento();

                }//cargar cosas
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }


        public void LlenarDatosPublicacionElemento()
        {
            Publicacion publicacionTemporal = new Publicacion();
            publicacionTemporal = (Publicacion)Session["PublicacionContratada"];
            //se cargan dlas cosas en la pagina
            ImagenPublicacion.ImageUrl = publicacionTemporal.Imagen;
            LabelNumeroPub.Text = publicacionTemporal.Id.ToString();
            LabelNombrePub.Text = publicacionTemporal.Nombre;
            LabelTipo.Text = publicacionTemporal.Tipo;
            LabelResumenPub.Text = publicacionTemporal.Resumen;
            LabelCaracteristicas.Text = publicacionTemporal.Caracteristicas;
            LabelCondicion.Text = publicacionTemporal.Condición;
            LabelPrecio.Text = publicacionTemporal.Precio;

        }

        public Contrato ConstruirContrato()
        {
            Random generator = new Random();
            int r = generator.Next(0, 1000000);
            Publicacion publicacionTemporal = new Publicacion();
            Contrato contrato = new Contrato();
            contrato.NumeroContrato = r;
            publicacionTemporal = (Publicacion)Session["PublicacionContratada"];
            elemento = elementobll.Seleccionar(publicacionTemporal.codElemento);
            empleadosSeleccionados = (List<Empleado>)Session["empleadosSeleccionados"];
            ///Para esta ocasión se toma un solo elemento en la lista cuya cantidad va a ser igual
            ///a la cantidad de empleados seleccionados para el bien. 
            List<Elemento> elementos = new List<Elemento>();
            Elemento unElemento = new Elemento();
            unElemento = elemento;
            unElemento.cantidad = empleadosSeleccionados.Count();
            elementos.Add(unElemento);
            contrato.Elementos = elementos;
            contrato.FechaContrato = System.DateTime.Now;
            contrato.FechaInicio = CalendarioInicio.SelectedDate;
            Cliente cliente = new Cliente();
            cliente = (Cliente)Session["Cliente"];
            contrato.codCliente = cliente.CodigoCliente;
            contrato.codProveedor = publicacionTemporal.codProveedor;
            int cantidadTiempo = int.Parse(TxtBoxCantidadTiempo.Text);
            float valorElementoTiempo = 0;
            switch (RadioButtonList1.SelectedItem.Text)
            {
                case "Días": //seleccionó dias.
                    contrato.FechaFinal = contrato.FechaInicio.AddDays(cantidadTiempo);
                    valorElementoTiempo = contratoBll.CalcularValorElementoTiempo(contrato, "Días", elemento.Precio);
                    contrato.Monto = valorElementoTiempo * empleadosSeleccionados.Count();
                    contrato.pagos = contratoBll.CalcularPlanPagos(contrato, "Días");
                    break;
                case "Meses":
                    contrato.FechaFinal = contrato.FechaInicio.AddMonths(cantidadTiempo);
                    valorElementoTiempo = contratoBll.CalcularValorElementoTiempo(contrato, "Meses", elemento.Precio);
                    contrato.Monto = valorElementoTiempo * empleadosSeleccionados.Count();
                    contrato.pagos = contratoBll.CalcularPlanPagos(contrato, "Meses");
                    break;
                case "Años":
                    contrato.FechaFinal = contrato.FechaInicio.AddYears(cantidadTiempo);
                    valorElementoTiempo = contratoBll.CalcularValorElementoTiempo(contrato, "Años", elemento.Precio);
                    contrato.Monto = valorElementoTiempo * empleadosSeleccionados.Count();
                    contrato.pagos = contratoBll.CalcularPlanPagos(contrato, "Años");
                    break;
                default:
                    break;
            }
            return contrato;
            



        }

        public void VerContratoPreliminar(Contrato uncontrato)
        {
            Publicacion publicacion = new Publicacion();
            publicacion = (Publicacion)Session["PublicacionContratada"];
            BLLElemento elmbll = new BLLElemento();
            Elemento elemento =  elmbll.Seleccionar(publicacion.codElemento);
            lblfecha.Text = uncontrato.FechaContrato.ToString();
            lblfinicio.Text = uncontrato.FechaInicio.ToString();
            lblffin.Text = uncontrato.FechaFinal.ToString();
            lblmonto.Text = uncontrato.Monto.ToString();
            lblcantelem.Text = uncontrato.Elementos.Count() + " " + elemento.Descripción + " " + elemento.Caracteristicas;
            GridViewPagos.DataSource = uncontrato.pagos;
            GridViewPagos.DataBind();

        }

        #region Seleccion de Empleados

       

        private void EnlazarEmpleados(List<Empleado> empleados)
        {
            
            GrillaEmpleados.DataSource = empleados.Select(emp => new
            {
                Direccion = emp.Dirección,
                Nombre = emp.Nombre,
                Email = emp.Email,
                DNI = emp.DNI
            });

            GrillaEmpleados.DataBind();
        }


        private void EnlazarEmpleadosSeleccionados(List<Empleado> empleadosSeleccionados)
        {
            
            GrillaEmpleadosSeleccionados.DataSource = empleadosSeleccionados.Select(emp => new
            {
                Direccion = emp.Dirección,
                Nombre = emp.Nombre,
                Email = emp.Email,
                DNI = emp.DNI
            });

            GrillaEmpleadosSeleccionados.DataBind();
        }

        private void AgregarEmpleado(int dniEmpleado)
        {
            empleados = empBLL.ListarEmpleados((Cliente)Session["Cliente"]);
            List<Empleado> empleadosSeleccionados = new List<Empleado>();
            if (Session["empleadosSeleccionados"] != null)
            {
                empleadosSeleccionados = (List<Empleado>)Session["empleadosSeleccionados"];
               
            }
            
            foreach (Empleado empleado in empleados)
            {
                if (empleado.DNI == dniEmpleado)
                {
                    empleadosSeleccionados.Add(empleado);
                    break;
                }
                
            }
            foreach (Empleado empsel in empleadosSeleccionados)
            {
                foreach (Empleado emp in empleados)
                {
                    if (emp.DNI == empsel.DNI)
                    {
                        empleados.Remove(emp);
                        break;
                    }
                }
            }

            EnlazarEmpleados(empleados);
            EnlazarEmpleadosSeleccionados(empleadosSeleccionados);
            Session["empleadosSeleccionados"] = empleadosSeleccionados;

        }

        private void QuitarEmpleado(int dniEmpleado)
        {
            empleadosSeleccionados = (List<Empleado>)Session["empleadosSeleccionados"];
            empleados = empBLL.ListarEmpleados((Cliente)Session["Cliente"]);
            foreach (Empleado empleado in empleadosSeleccionados)
            {
                
                if (empleado.DNI == dniEmpleado)
                {
                    empleadosSeleccionados.Remove(empleado);
                    break;
                }

            }
            foreach (Empleado empsel in empleadosSeleccionados)
            {
                foreach (Empleado emp in empleados)
                {
                    if (emp.DNI == empsel.DNI)
                    {
                        empleados.Remove(emp);
                        break;
                    }
                }
            }
            Session.Remove("empleadosSeleccionados");
            Session["empleadosSeleccionados"] = empleadosSeleccionados;
            EnlazarEmpleados(empleados);
            EnlazarEmpleadosSeleccionados(empleadosSeleccionados);
            
        }

        protected void GrillaEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Empleado emptemp = new Empleado();
                int dniEmpleado = int.Parse(GrillaEmpleados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                switch (e.CommandName)
                {
                    case "btnSeleccionarEmpleado":
                        {
                            AgregarEmpleado(dniEmpleado);                 
                            break;
                        }
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            
        }


        protected void GrillaEmpleadosSeleccionados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Empleado emptemp = new Empleado();
                int dniEmpleado = int.Parse(GrillaEmpleadosSeleccionados.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
           
                switch (e.CommandName)
                {
                    case "btnQuitarEmpleado":
                        {
                            QuitarEmpleado(dniEmpleado);
                            break;
                        }


                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            
        }


        #endregion

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ContratoFinal"]!= null)
                {
                    Session.Remove("ContratoFinal");
                }
                Contrato contrato = new Contrato();
                contrato = ConstruirContrato();
                Session["ContratoFinal"] = contrato;
                VerContratoPreliminar(contrato);

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            
        }

        protected void BtnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ContratoFinal"] != null)
                {
                    Response.Redirect("ContratoPreliminar.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Debe generar un contrato')</script>");
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            
        }
    }



}