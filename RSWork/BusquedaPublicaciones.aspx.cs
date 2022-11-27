using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using System.Threading;

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
                if (Session["TextoBuscar"].ToString() == "") //aca si esta vacio.
                {
                    CargarTodas();
                }
                if (Session["TextoBuscar"].ToString()!= "") //aca si no está vacio.
                {
                    CargarFiltradas(Session["TextoBuscar"].ToString());
                }
                
            }
        }

        private void CargarTodas()
        {

            publicaciones = publl.ListarTodas();
            DataListPublicaciones.DataSource = publicaciones;
            DataListPublicaciones.DataBind();
        }

        protected void DataListPublicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  
        protected void VerAsideButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                ActualizarAside(int.Parse(btn.CommandArgument));
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



        private void ActualizarAside(int codPublicacion)
        {
            try
            {

                Publicacion publicacion = new Publicacion();
                publicacion = publl.Seleccionar(codPublicacion);
                BLLElemento elembll = new BLLElemento();
                Elemento elemento = new Elemento();
                elemento = elembll.Seleccionar(publicacion.codElemento);
                publicacion.Tipo = elemento.Tipo.ToString();
                publicacion.Caracteristicas = elemento.Caracteristicas;
                publicacion.Condición = elemento.Condición;
                publicacion.Precio = elemento.Precio.ToString();
                List<Publicacion> publicaciones = new List<Publicacion>();
                publicaciones.Add(publicacion);
                AsideDataList.DataSource = publicaciones;
                AsideDataList.DataBind();
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

        protected void ContratarButton_Click(object sender, EventArgs e)
        {
            try
            {

                Button btn = (Button)sender;
                Publicacion publicacion = new Publicacion();
                publicacion = publl.Seleccionar(int.Parse(btn.CommandArgument));
                BLLElemento elembll = new BLLElemento();
                Elemento elemento = new Elemento();
                elemento = elembll.Seleccionar(publicacion.codElemento);
                publicacion.Precio = elemento.Precio.ToString();
                publicacion.Caracteristicas = elemento.Caracteristicas;
                publicacion.Condición = elemento.Condición;
                publicacion.Tipo = elemento.Tipo.ToString();
                Session["PublicacionContratada"] = publicacion;
                Usuario usu = new Usuario();
                usu = (Usuario)Session["Usuario"];
                if (Session["Usuario"] != null)
                {
                    if (usu.empresa.GetType() == typeof(Cliente))
                    {
                        Response.Redirect("ParametrosDelAlquiler.aspx"); 
                    }
                    else
                    {
                        Response.Write("<script>alert('Debe ser Cliente para generar contratos')</script>");

                    }
                }
                if (Session["Usuario"] == null )
                {
                    Response.Write(" < script > alert('Por favor, ingrese en el sistema.') </ script > ");
                    Response.Redirect("Login.aspx");
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


        private void CargarFiltradas(string texto)
        {
            try
            {
                publicaciones = publl.Filtrar(publl.ListarTodas(),texto);
                DataListPublicaciones.DataSource = publicaciones;
                DataListPublicaciones.DataBind();


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


