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
    public partial class PerfilProveedor : System.Web.UI.Page
    {
        ProveedorBLL proveedorbll = new ProveedorBLL();
        BLLElemento elmsbll = new BLLElemento();
        Elemento elemTemp;
        PublicacionBLL pubbll = new PublicacionBLL();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarDatosEmpresa();
                EnlazarGrillaElementos();
                DropDownTipo.Enabled = true;
                EnlazarGrillaPublicaciones();
                LimpiarCamposPublicacion();
            }

        }

        protected void CargarDatosEmpresa()
        {

            Usuario usuarioActual = new Usuario();
            Proveedor estaEmpresa = new Proveedor();
            estaEmpresa = (Proveedor) Session["Proveedor"];
            usuarioActual = (Usuario) Session["Usuario"];
            LabelCod.InnerText = "Cod. " + estaEmpresa.CodigoProveedor.ToString();
            LabelCUIT.InnerText = "CUIT "+ estaEmpresa.CUIT.ToString();
            txtBoxTelefono.Text = estaEmpresa.Telefono;
            txtBoxDireccion.Text = estaEmpresa.Direccion;
            LabelCat.InnerText = "Tipo "+ estaEmpresa.tipoProveedor.ToString();
            LabelNombreEmp.InnerText = estaEmpresa.Nombre;
            txtboxEmail.Text = estaEmpresa.email;
        }

        protected void ModificarBtn_Click(object sender, EventArgs e)
        {
            Proveedor estaEmpresa = (Proveedor)Session["Proveedor"];
            estaEmpresa.Telefono = txtBoxTelefono.Text.ToString();
            estaEmpresa.Direccion = txtBoxDireccion.Text;
            estaEmpresa.email = txtboxEmail.Text;
            proveedorbll.Modificar(estaEmpresa);
            Session["Proveedor"] = null;
            Session["Proveedor"] = estaEmpresa;
            CargarDatosEmpresa();
        }

        #region ABM Elementos

        protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e) //Grilla Elementos
        {
            elemTemp = new Elemento();
            int codigoElemento = int.Parse(grillaElementos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
            string nombreElemento = (grillaElementos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
            string descripcionElemento = (grillaElementos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
            string tipoElemento = (grillaElementos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text);
            float precioElemento = float.Parse(grillaElementos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text);
            elemTemp = elmsbll.Seleccionar(codigoElemento);
            Session["ElemTemp"] = elemTemp;
            switch (e.CommandName)
            {
                case "btnSeleccionarElemento":

                    TextBoxNombre.Text = nombreElemento.ToString();
                    TextBoxDescripcion.Text = descripcionElemento.ToString();
                    TextBoxPrecio.Text = precioElemento.ToString();
                    TextBoxCaracteristicas.Text = elemTemp.Caracteristicas;
                    DropDownCondicion.SelectedValue = elemTemp.Condición;
                    DropDownTipo.SelectedValue = elemTemp.Tipo.ToString();

                    break;
            }


        }


        private void EnlazarGrillaElementos()
        {
            List<Elemento> elementos = new List<Elemento>();
            elementos = elmsbll.ListarElementos((Proveedor)Session["Proveedor"]);

            grillaElementos.DataSource = elementos.Select(elem =>new
            {
                Codigo = elem.Código,
                Nombre = elem.Nombre,
                Descripcion = elem.Descripción,
                Tipo = elem.Tipo,
                Precio = elem.Precio,
            });
            grillaElementos.DataBind();

            DropDownElementos.DataSource = elementos;
            DropDownElementos.DataTextField = "Nombre";
            DropDownElementos.DataBind();


        }

        private void LimpiarCamposElementos()
        {

            TextBoxNombre.Text = "";
            TextBoxDescripcion.Text = "";
            TextBoxPrecio.Text = "";
            TextBoxCaracteristicas.Text = "";
        }


        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                
                Elemento elemTemp = new Elemento();
                elemTemp.Nombre = TextBoxNombre.Text;
                elemTemp.Descripción = TextBoxDescripcion.Text;
                elemTemp.Precio = decimal.Parse(TextBoxPrecio.Text);
                elemTemp.Tipo = (Elemento.TipoElemento)System.Enum.Parse(typeof(Elemento.TipoElemento), DropDownTipo.SelectedItem.Text);
                elemTemp.Condición = DropDownCondicion.SelectedItem.Text;
                elemTemp.Caracteristicas = TextBoxCaracteristicas.Text;
                elmsbll.Alta(elemTemp, (Proveedor)Session["Proveedor"]);
                EnlazarGrillaElementos();
                LimpiarCamposElementos();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                elemTemp = (Elemento)Session["ElemTemp"];
                elemTemp.Nombre = TextBoxNombre.Text;
                elemTemp.Descripción = TextBoxDescripcion.Text;
                elemTemp.Precio = decimal.Parse(TextBoxPrecio.Text);
                elemTemp.Tipo = (Elemento.TipoElemento)System.Enum.Parse(typeof(Elemento.TipoElemento), DropDownTipo.SelectedItem.Text);
                elemTemp.Condición = DropDownCondicion.SelectedItem.Text;
                elemTemp.Caracteristicas = TextBoxCaracteristicas.Text;
                elmsbll.Modificar(elemTemp, (Proveedor)Session["Proveedor"]);
                EnlazarGrillaElementos();
                LimpiarCamposElementos();
            }
            catch (Exception eeexx)
            {

                throw eeexx;
            }
        }

        protected void BtnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                elemTemp = (Elemento)Session["ElemTemp"];
                elemTemp.Nombre = TextBoxNombre.Text;
                elemTemp.Descripción = TextBoxDescripcion.Text;
                elemTemp.Precio = decimal.Parse(TextBoxPrecio.Text);
                elemTemp.Tipo = (Elemento.TipoElemento)System.Enum.Parse(typeof(Elemento.TipoElemento), DropDownTipo.SelectedItem.Text);
                elemTemp.Condición = DropDownCondicion.SelectedItem.Text;
                elemTemp.Caracteristicas = TextBoxCaracteristicas.Text;
                elmsbll.Baja(elemTemp, (Proveedor)Session["Proveedor"]);
                EnlazarGrillaElementos();
                LimpiarCamposElementos();
            }
            catch (Exception eeexx)
            {

                throw eeexx;
            }
        }



        #endregion


        #region ABM Publicaciones
        protected void GrillaPublicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Publicacion publiTemporal = new Publicacion();
            int idPublicacion = int.Parse(grillaPublicaciones.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
            string nombrePublicacion = (grillaPublicaciones.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
            int cantidadElementos = int.Parse(grillaPublicaciones.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
            string resumenPublicacion = (grillaPublicaciones.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text);
            publiTemporal = pubbll.Seleccionar(idPublicacion);
            Session["PublicacionTemp"] = publiTemporal;
            switch (e.CommandName)
            {
                case "btnSeleccionarPublicacion":
                    LabelIDPub.Text = idPublicacion.ToString();
                    ImagenPublicacion.ImageUrl = publiTemporal.Imagen;
                    TextBoxCantPub.Text = cantidadElementos.ToString();
                    TextBoxNomPub.Text = nombrePublicacion;
                    TextBoxResumenPub.Text = resumenPublicacion;
                    DropDownElementos.SelectedValue = elmsbll.Seleccionar(publiTemporal.codElemento).Nombre.ToString();
                    break;
            }

        }

        protected void BtnAltaPub_Click(object sender, EventArgs e)
        {
            Publicacion publiTemporal = new Publicacion();
            publiTemporal.Cantidad = int.Parse(TextBoxCantPub.Text);
            publiTemporal.Nombre = TextBoxNomPub.Text;
            
            if (FileUploadImagen.HasFile)
            {
                publiTemporal.Imagen = "/img/imgPublicaciones/" + FileUploadImagen.FileName;
                int tam = FileUploadImagen.PostedFile.ContentLength;
                if (tam <= 1048576)
                {
                    
                    FileUploadImagen.SaveAs(Server.MapPath("~/img/imgPublicaciones/" + FileUploadImagen.FileName));
                }
                else
                {
                    Response.Redirect("Seleccione un archivo mas pequeño");
                }
            }
            if (!FileUploadImagen.HasFile)
            {
                Response.Write("Debe seleccionar un archivo");
            }
            publiTemporal.Resumen = TextBoxResumenPub.Text;

            List<Elemento> elementos = new List<Elemento>();
            elementos = elmsbll.ListarElementos((Proveedor)Session["Proveedor"]);
            foreach (Elemento elemento in elementos)
            {
                if (elemento.Nombre == DropDownElementos.SelectedValue.ToString())
                {
                    publiTemporal.codElemento = elemento.Código;
                }
            }

            Proveedor proveedor = new Proveedor();
            proveedor = (Proveedor)Session["Proveedor"];
            publiTemporal.codProveedor = proveedor.CodigoProveedor;

            pubbll.Alta(publiTemporal);
            EnlazarGrillaPublicaciones();
            LimpiarCamposPublicacion();

        }

        protected void BtnModificarPub_Click(object sender, EventArgs e)
        {
            Publicacion publiTemporal = new Publicacion();
            publiTemporal.Id = int.Parse(LabelIDPub.Text);
            publiTemporal.Cantidad = int.Parse(TextBoxCantPub.Text);
            publiTemporal.Nombre = TextBoxNomPub.Text;
            if (FileUploadImagen.HasFile)
            {
                publiTemporal.Imagen = "/img/imgPublicaciones/" + FileUploadImagen.FileName;
                int tam = FileUploadImagen.PostedFile.ContentLength;
                if (tam <= 1048576)
                {

                    FileUploadImagen.SaveAs(Server.MapPath("~/img/imgPublicaciones/" + FileUploadImagen.FileName));
                }
                else
                {
                    Response.Redirect("Seleccione un archivo mas pequeño");
                }
            }
            if (!FileUploadImagen.HasFile)
            {
                publiTemporal.Imagen = "";
            }
            publiTemporal.Resumen = TextBoxResumenPub.Text;

            List<Elemento> elementos = new List<Elemento>();
            elementos = elmsbll.ListarElementos((Proveedor)Session["Proveedor"]);
            foreach (Elemento elemento in elementos)
            {
                if (elemento.Nombre == DropDownElementos.SelectedValue.ToString())
                {
                    publiTemporal.codElemento = elemento.Código;
                }
            }

            Proveedor proveedor = new Proveedor();
            proveedor = (Proveedor)Session["Proveedor"];
            publiTemporal.codProveedor = proveedor.CodigoProveedor;

            pubbll.Modificar(publiTemporal);
            EnlazarGrillaPublicaciones();
            LimpiarCamposPublicacion();

        }

        protected void BtnBajaPub_Click(object sender, EventArgs e)
        {
            Publicacion publiTemporal = new Publicacion();
            publiTemporal.Id = int.Parse(LabelIDPub.Text);
            pubbll.Baja(publiTemporal);
            EnlazarGrillaPublicaciones();
            LimpiarCamposPublicacion();

        }

        public void EnlazarGrillaPublicaciones()
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            publicaciones = pubbll.ListarPorProveedor((Proveedor)Session["Proveedor"]);

            grillaPublicaciones.DataSource = publicaciones.Select(pub => new
            {
                Id = pub.Id,
                Nombre = pub.Nombre,
                Resumen = pub.Resumen,
                Cantidad = pub.Cantidad,
                
            });
            grillaPublicaciones.DataBind();
        }


        private void LimpiarCamposPublicacion()
        {
            TextBoxCantPub.Text = "";
            TextBoxNomPub.Text = "";
            TextBoxResumenPub.Text = "";
            ImagenPublicacion.ImageUrl = "";
            
        }



        #endregion

    }
}