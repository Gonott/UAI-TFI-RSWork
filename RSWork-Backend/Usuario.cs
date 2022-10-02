using System;
using System.Collections.Generic;

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
    using DAL;

    public class UsuarioBLL
    {

        UsuarioDAL mapper = new UsuarioDAL();

        public bool ComprobarUsuario(Usuario UnUsuario)
        {

            bool rta = false;

            if (mapper.ValidarUsuario(UnUsuario)== true)
            {
                rta = true;
            }
            return rta;
       
        }


        public Usuario LlenarUsuario(Usuario usu)
        {
            try
            {
                return mapper.LlenarUsuario(usu);
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
    using BE;
    using System.Data;


    public class UsuarioDAL
    {
        public bool ValidarUsuario(Usuario usu)
        {

            try
            {
                

                DAO.Abrir();
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(DAO.CrearParametro("@usu", usu.Nombre));
                parameters.Add(DAO.CrearParametro("@pwd", usu.Contraseña));
                DataTable tabla = DAO.LeerConParametros("ValidarUsuario", parameters);
                DAO.Cerrar();

                            
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




        }

        public Usuario LlenarUsuario(Usuario usu)
        {
            try
            {

                DAO.Abrir();
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(DAO.CrearParametro("@usu", usu.Nombre));
                parameters.Add(DAO.CrearParametro("@pwd", usu.Contraseña));
                DataTable tabla = DAO.LeerConParametros("ValidarUsuario", parameters);
                DAO.Cerrar();

                foreach (DataRow row in tabla.Rows)
                {
                    usu.IdUsuario = int.Parse(row["IdUsuario"].ToString());
                    usu.Nombre = row["Nombre"].ToString();
                    usu.idempresa = int.Parse(row["IdEmpresa"].ToString());

                }

                return usu;
            }
            catch (Exception)
            {

                throw;
            }
        }





    }





}
