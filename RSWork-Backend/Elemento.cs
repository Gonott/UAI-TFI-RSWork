using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Elemento
    {
        public string Caracteristicas { get; set; }

        public string Condición { get; set; }

        public string Descripción { get; set; }

        public string NombreElemento { get; set; }

        public int Código { get; set; }

        public decimal Precio { get; set; }


        public TipoElemento Tipo { get; set; }


        public enum TipoElemento
        {
            Notebook,
            Desktop,
            Monitor,
            Periferico,
            Escritorio,
            Silla
        }


        public int stockProveedor;


    }

}


namespace BLL
{
    using BE;
    using DAL;

    public class BLLElemento
    {
        ElementoDAL mapper = new ElementoDAL();

        public List<BE.Elemento> FiltrarElementos(string a, BE.Elemento.TipoElemento unelemento, string b)
        {
            List<BE.Elemento> elementos = new List<BE.Elemento>();
            return elementos;
        }


        public List<BE.Elemento> ListarElementos(Proveedor proveedor)
        {
            List<BE.Elemento> elementos = mapper.listar(proveedor);
            return elementos;
        }


        public void Alta(Elemento elemento, Proveedor proveedor)
        {
            try
            {
                mapper.alta(elemento, proveedor);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Baja(Elemento elemento, Proveedor proveedor)
        {
            try
            {
               mapper.baja(elemento, proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Elemento Seleccionar(int cod)
        {
            try
            {
                return mapper.Seleccionar(cod);
            }
            catch (Exception exx)
            {

                throw exx;
            }


        }
        public void Modificar(Elemento elemento, Proveedor proveedor)
        {
            try
            {
                mapper.modificar(elemento,proveedor); 
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}



namespace DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using BE;

    public class ElementoDAL
    {





        public void alta(Elemento elemento,Proveedor proveedor)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(DAO.CrearParametro("@caracteristicas",elemento.Caracteristicas));
            parameters.Add(DAO.CrearParametro("@condicion",elemento.Condición));
            parameters.Add(DAO.CrearParametro("@descripcion", elemento.Descripción));
            parameters.Add(DAO.CrearParametro("@nombre",elemento.NombreElemento));
            parameters.Add(DAO.CrearParametro("@tipo", elemento.Tipo.ToString()));
            parameters.Add(DAO.CrearParametro("@precio", elemento.Precio));
            parameters.Add(DAO.CrearParametro("@cantidad", elemento.stockProveedor));
            parameters.Add(DAO.CrearParametro("@codproveedor", proveedor.CodigoProveedor));
            DAO.Escribir("AltaElemento", parameters);

            DAO.Cerrar();
        }


        public void baja(Elemento elemento, Proveedor proveedor)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codigo", elemento.Código));
            parameters.Add(DAO.CrearParametro("@codproveedor", proveedor.CodigoProveedor));
            DAO.Escribir("BajaElemento", parameters);

            DAO.Cerrar();
        }


        public void modificar(Elemento elemento,Proveedor proveedor)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codigo", elemento.Código));
            parameters.Add(DAO.CrearParametro("@caracteristicas", elemento.Caracteristicas));
            parameters.Add(DAO.CrearParametro("@nombre", elemento.NombreElemento));
            parameters.Add(DAO.CrearParametro("@tipo", elemento.Tipo.ToString()));
            parameters.Add(DAO.CrearParametro("@descripcion", elemento.Descripción));
            parameters.Add(DAO.CrearParametro("@precio", elemento.Precio));
            parameters.Add(DAO.CrearParametro("@cantidad", elemento.stockProveedor));
            parameters.Add(DAO.CrearParametro("@codproveedor", proveedor.CodigoProveedor));
            DAO.Escribir("ModificarElemento", parameters);
            DAO.Cerrar();
        }

        public List<Elemento> listar(Proveedor proveedor)
        {
            List<Elemento> elementos = new List<Elemento>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codigoproveedor", proveedor.CodigoProveedor));
            DataTable tabla = DAO.LeerConParametros("ListarElementos", parameters); //lista haciendo inner join con la tabla intermedia de stock.

            DAO.Cerrar();

            foreach (DataRow registro in tabla.Rows)
            {
                Elemento elemento = new Elemento();
                elemento.Código=int.Parse(registro["Codigo"].ToString());
                elemento.Caracteristicas =registro["Caracteristicas"].ToString();
                elemento.Condición =registro["Condicion"].ToString();
                elemento.Descripción=registro["Descripcion"].ToString();
                elemento.NombreElemento = registro["Nombre"].ToString();
                elemento.stockProveedor = int.Parse(registro["Cantidad"].ToString());
                switch (registro["Tipo"].ToString())
                {
                    case "Notebook":
                        elemento.Tipo = Elemento.TipoElemento.Notebook;
                        break;
                    case "Desktop":
                        elemento.Tipo = Elemento.TipoElemento.Desktop;
                        break;
                    case "Monitor":
                        elemento.Tipo = Elemento.TipoElemento.Monitor;
                        break;
                    case "Periferico":
                        elemento.Tipo = Elemento.TipoElemento.Periferico;
                        break;
                    case "Escritorio":
                        elemento.Tipo = Elemento.TipoElemento.Escritorio;
                        break;
                    case "Silla":
                        elemento.Tipo = Elemento.TipoElemento.Silla;
                        break;
                }
                elemento.Precio = decimal.Parse(registro["Precio"].ToString());
                elementos.Add(elemento);

            }

            return elementos;



        }


        public Elemento Seleccionar(int cod)
        {

            List<Elemento> elementos = new List<Elemento>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codigoelemento", cod));
            DataTable tabla = DAO.LeerConParametros("SeleccionarElemento", parameters); 
            DAO.Cerrar();

            foreach (DataRow registro in tabla.Rows)
            {
                Elemento elemento = new Elemento();
                elemento.Código = int.Parse(registro["Codigo"].ToString());
                elemento.Caracteristicas = registro["Caracteristicas"].ToString();
                elemento.Condición = registro["Condicion"].ToString();
                elemento.Descripción = registro["Descripcion"].ToString();
                elemento.NombreElemento = registro["Nombre"].ToString();
                switch (registro["Tipo"].ToString())
                {
                    case "Notebook":
                        elemento.Tipo = Elemento.TipoElemento.Notebook;
                        break;
                    case "Desktop":
                        elemento.Tipo = Elemento.TipoElemento.Desktop;
                        break;
                    case "Monitor":
                        elemento.Tipo = Elemento.TipoElemento.Monitor;
                        break;
                    case "Periferico":
                        elemento.Tipo = Elemento.TipoElemento.Periferico;
                        break;
                    case "Escritorio":
                        elemento.Tipo = Elemento.TipoElemento.Escritorio;
                        break;
                    case "Silla":
                        elemento.Tipo = Elemento.TipoElemento.Silla;
                        break;
                }
                elemento.Precio = decimal.Parse(registro["Precio"].ToString());
                elementos.Add(elemento);

            }
            return elementos[0];
        }



    }

}


  
