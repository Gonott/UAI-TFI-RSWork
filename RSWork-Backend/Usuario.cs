using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {

        public string Contraseña { get; set; }

        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public Empresa empresa { get; set; }

        public int idempresa { get; set; }



    }



}


namespace BLL
{
    using BE;
    using SERVICIOS;
    using DAL;

    public class UsuarioBLL
    {

        UsuarioDAL mapper = new UsuarioDAL();

        public bool ComprobarUsuario(Usuario UnUsuario)
        {

            bool rta = false;

            if (mapper.ValidarUsuario()== true)
            {
                IniciarSesion();
                rta = true;
            }
            return rta;
       
        }


        public void IniciarSesion()
        {
            //crear cookies y llevar a perfil segun empresa

            mapper.CargarEmpresa(Sesion.ObtenerInstancia.EsteUsuario.idempresa);
            if (Sesion.ObtenerInstancia.EsteUsuario.empresa.GetType() == typeof(Cliente))
            {
                
                //llevar a perfil cliente


            }
            if (Sesion.ObtenerInstancia.EsteUsuario.empresa.GetType() == typeof(Proveedor))
            {

                //llevar a perfil proveedor

            }
        }



    }



}


namespace DAL
{
    using BE;
    using SERVICIOS;
    using System.Data;
    using System.Data.SqlClient;


    public class UsuarioDAL
    {
        public bool ValidarUsuario()
        {

            try
            {
                Usuario usu = new Usuario();

                DAO.Abrir();
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(DAO.CrearParametro("@usu", usu.Nombre));
                parameters.Add(DAO.CrearParametro("@pwd", usu.Contraseña));
                DataTable tabla = DAO.Leer("ValidarUsuario", parameters);
                DAO.Cerrar();

                foreach ( DataRow row in tabla.Rows)
                {
                    Sesion.ObtenerInstancia.EsteUsuario.IdUsuario = int.Parse(row["IdUsuario"].ToString());
                    Sesion.ObtenerInstancia.EsteUsuario.Nombre = row["Nombre"].ToString();
                    Sesion.ObtenerInstancia.EsteUsuario.idempresa = int.Parse(row["IdEmpresa"].ToString());

                }

                
                if (tabla.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DAO.Cerrar();
            }




        }

        public void CargarEmpresa(int idempresa)
        {

            try
            {
                

                DAO.Abrir();
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                DAO.CrearParametro("@idempresa", idempresa);
                DataTable tabla = DAO.Leer("EncontrarEmpresa", parameters);
                DAO.Cerrar();

                //se verifica el campo tipoEmpresa


                
                foreach (DataRow row in tabla.Rows)
                {
                    if (row["TipoEmpresa"].ToString() == "Cliente")
                    { 
                        Cliente empresa = new Cliente();
                        empresa.CodigoCliente = int.Parse(row["id"].ToString());
                        empresa.Nombre = row["Nombre"].ToString();
                        empresa.CUIT = Int64.Parse(row["CUIT"].ToString());
                        empresa.Telefono = row["Telefono"].ToString();
                        empresa.Direccion = row["Direccion"].ToString();
                        empresa.email = row["Email"].ToString();
                        empresa.Categoria = int.Parse(row["Categoria"].ToString());
                        Sesion.ObtenerInstancia.EsteUsuario.empresa = empresa;
                    }

                    if (row["TipoEmpresa"].ToString() == "Proveedor")
                    {
                        Proveedor empresa = new Proveedor();
                        empresa.CodigoProveedor = int.Parse(row["id"].ToString());
                        empresa.Nombre = row["Nombre"].ToString();
                        empresa.CUIT = Int64.Parse(row["CUIT"].ToString());
                        empresa.Telefono = row["Telefono"].ToString();
                        empresa.Direccion = row["Direccion"].ToString();
                        empresa.email = row["Email"].ToString();
                        switch (row["TipoProveedor"].ToString())
                        {
                            case "Fabricante":
                                empresa.tipoProveedor = Proveedor.TipoProveedor.Fabricante;
                                break;
                            case "Mayorista":
                                empresa.tipoProveedor = Proveedor.TipoProveedor.Mayorista;
                                break;
                            case "Minorista":
                                empresa.tipoProveedor = Proveedor.TipoProveedor.Minorista;
                                break;
                        }
                        Sesion.ObtenerInstancia.EsteUsuario.empresa = empresa;


                    }
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DAO.Cerrar();
            }






        }


    }





}
