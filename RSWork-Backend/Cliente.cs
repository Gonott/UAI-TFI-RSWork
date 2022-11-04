using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente : Empresa
    {

        public int Categoria { get; set; }


        public int CodigoCliente { get; set; }

        public List<Empleado> Empleados { get; set; }




    }
}


namespace BLL
{
    using BE;
    using DAL;
    public class ClienteBLL
    {
        ClienteDAL mapper = new ClienteDAL();


    

        public void ModificarCliente(Cliente uncliente)
        {
            try
            {
                mapper.Modificar(uncliente);

            }
            catch (Exception exx)
            {

                throw exx;
            }
        }

    }


}

namespace DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using BE;

    public class ClienteDAL
    {

        public void Modificar(Cliente cliente)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codcliente", cliente.CodigoCliente));
            parameters.Add(DAO.CrearParametro("@telefono", cliente.Telefono));
            parameters.Add(DAO.CrearParametro("@direccion", cliente.Direccion));
            parameters.Add(DAO.CrearParametro("@email", cliente.email));
            parameters.Add(DAO.CrearParametro("@cuit", cliente.CUIT.ToString()));
            DAO.Escribir("ModificarCliente", parameters);
            DAO.Cerrar();

        }

        

    }




}