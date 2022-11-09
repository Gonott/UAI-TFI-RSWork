﻿using System;
using System.Collections;
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

        protected void DataListPublicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  
        protected void VerAsideButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActualizarAside(int.Parse(btn.CommandArgument));
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
            catch (Exception ex)

            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        protected void ContratarButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Publicacion publicacion = new Publicacion();
            publicacion =  publl.Seleccionar(int.Parse(btn.CommandArgument));
            Session["PublicacionContratada"] = publicacion;
            Usuario usu = new Usuario();
            usu = (Usuario)Session["Usuario"];
            if (usu.empresa.GetType() == typeof(Cliente))
            {
                Response.Redirect("ParametrosDelAlquiler.aspx");
                //llevar perfil cliente
            }
            else
            {
                 Response.Write("<script>alert('Debe ser Cliente para generar contratos')</script>");
                
            }
            
        }





    }
}


