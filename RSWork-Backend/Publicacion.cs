using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Data.Sql;
using System.Data;

namespace BE
{
    public class Publicacion
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public string Nombre{ get; set; }

        public string Imagen { get; set; }


        public string Resumen { get; set; }

        public int codElemento{ get; set; }

        public int codProveedor { get; set; }


        /// <summary>
        /// Las siguientes son para poder desplegar el detalle de las publicaciones
        /// en cuanto a las caracteristicas del elemento que tienen adentro.
        /// </summary>

        public string Tipo { get; set; }
        public string Caracteristicas { get; set; }
        public string Condición { get; set; }
        public string Precio { get; set; }

    }



 }


namespace BLL
{

    
    public class PublicacionBLL
    {PublicacionDAL mapper = new PublicacionDAL();

        public void Alta(Publicacion publicacion)
        {
            try
            {
                mapper.Alta(publicacion);
            }
            catch (Exception exx)
            {

                throw exx;
            }
        }


        public void Baja(Publicacion publicacion)
        {
            try
            {
                mapper.baja(publicacion);
            }
            catch (Exception exx)
            {

                throw exx;
            }
        }



        public void Modificar(Publicacion publicacion)
        {
            try
            {
                mapper.Modificar(publicacion);
            }
            catch (Exception exx)
            {

                throw exx;
            }
        }
        


        public List<Publicacion> ListarPorProveedor(Proveedor proveedor)
        {
            try
            {
                return mapper.listarMisPub(proveedor);
            }
            catch (Exception ex)
            {

                throw ex; //test comment to github
            }
        }



        public List<Publicacion> ListarTodas()
        {
            try
            {
                return mapper.ListarTodo();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Publicacion Seleccionar(int idpub)
        {
            try
            {
                return mapper.Seleccionar(idpub);
            }
            catch (Exception exep)
            {

                throw exep;
            }
        }


        public List<Publicacion> Filtrar(List<Publicacion> aFiltrar, string texto)
        {

            List<Publicacion> filtrados = new List<Publicacion>();
            foreach (Publicacion publicacion in aFiltrar)
            {
                if (publicacion.Nombre.Contains(texto) || publicacion.Resumen.Contains(texto)) 
                {
                    filtrados.Add(publicacion);
                }

            }
            return filtrados;

        }


    }
    
}

namespace DAL
{
    public class PublicacionDAL
    {
        public void Alta(Publicacion publicacion)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(DAO.CrearParametro("@cantidad", publicacion.Cantidad));
            parameters.Add(DAO.CrearParametro("@nombre", publicacion.Nombre));
            parameters.Add(DAO.CrearParametro("@imagen", publicacion.Imagen));
            parameters.Add(DAO.CrearParametro("@resumen", publicacion.Resumen));
            parameters.Add(DAO.CrearParametro("@codproveedor", publicacion.codProveedor));
            parameters.Add(DAO.CrearParametro("@codelemento", publicacion.codElemento));
            DAO.Escribir("AltaPublicacion", parameters);

            DAO.Cerrar();
        }

        public void baja(Publicacion publicacion)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@id", publicacion.Id));
            DAO.Escribir("BajaPublicacion", parameters);

            DAO.Cerrar();
        }


        public void Modificar(Publicacion publicacion)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@id", publicacion.Id));
            parameters.Add(DAO.CrearParametro("@cantidad", publicacion.Cantidad));
            parameters.Add(DAO.CrearParametro("@nombre", publicacion.Nombre));
            parameters.Add(DAO.CrearParametro("@resumen", publicacion.Resumen));
            parameters.Add(DAO.CrearParametro("@codproveedor", publicacion.codProveedor));
            parameters.Add(DAO.CrearParametro("@codelemento", publicacion.codElemento));
            DAO.Escribir("ModificarPublicacion", parameters);
            if (publicacion.Imagen != "" )
            {
                parameters.Clear();
                parameters.Add(DAO.CrearParametro("@id", publicacion.Id));
                parameters.Add(DAO.CrearParametro("@imagen", publicacion.Imagen));
                DAO.Escribir("CambiarImagenPublicacion");
            }
            DAO.Cerrar();
        }

        public List<Publicacion> listarMisPub(Proveedor proveedor)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codigoproveedor", proveedor.CodigoProveedor));
            DataTable tabla = DAO.LeerConParametros("ListarPublicacionesProveedor", parameters);
            DAO.Cerrar();

            foreach (DataRow registro in tabla.Rows)
            {
                Publicacion publicacion = new Publicacion();
                publicacion.Id = int.Parse(registro["Id"].ToString());
                publicacion.Cantidad = int.Parse(registro["Cantidad"].ToString());
                publicacion.Nombre = registro["Nombre"].ToString();
                publicacion.Imagen = registro["Imagen"].ToString();
                publicacion.Resumen = registro["Resumen"].ToString();
                publicacion.codElemento = int.Parse(registro["codElemento"].ToString());
                publicacion.codProveedor = int.Parse(registro["codProveedor"].ToString());
                publicaciones.Add(publicacion);
            }
            return publicaciones;

        }


        public List<Publicacion> ListarTodo()
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            DataTable tabla = DAO.Leer("ListarPublicaciones", parameters);

            DAO.Cerrar();

            foreach (DataRow registro in tabla.Rows)
            {
                Publicacion publicacion = new Publicacion();
                publicacion.Id = int.Parse(registro["Id"].ToString());
                publicacion.Cantidad = int.Parse(registro["Cantidad"].ToString());
                publicacion.Nombre = registro["Nombre"].ToString();
                publicacion.Imagen = registro["Imagen"].ToString();
                publicacion.Resumen = registro["Resumen"].ToString();
                publicacion.codElemento = int.Parse(registro["codElemento"].ToString());
                publicacion.codProveedor = int.Parse(registro["codProveedor"].ToString());
                publicaciones.Add(publicacion);

            }
            return publicaciones;
        } 

        public Publicacion Seleccionar(int idpublicacion)
        {

            List<Publicacion> publicaciones = new List<Publicacion>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@idpublicacion",idpublicacion));
            DataTable tabla = DAO.LeerConParametros("SeleccionarPublicacion", parameters);
            DAO.Cerrar();

            foreach (DataRow registro in tabla.Rows)
            {
                Publicacion publicacion = new Publicacion();
                publicacion.Id = int.Parse(registro["Id"].ToString());
                publicacion.Cantidad = int.Parse(registro["Cantidad"].ToString());
                publicacion.Nombre = registro["Nombre"].ToString();
                publicacion.Imagen = registro["Imagen"].ToString();
                publicacion.Resumen = registro["Resumen"].ToString();
                publicacion.codElemento = int.Parse(registro["codElemento"].ToString());
                publicacion.codProveedor = int.Parse(registro["codProveedor"].ToString());
                publicaciones.Add(publicacion);
            }
            return publicaciones[0];
        }
            


        

    }


}


