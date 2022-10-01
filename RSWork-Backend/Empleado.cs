using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BE
{
    public class Empleado
    {

        public string Dirección { get; set; }

        public int DNI { get; set; }


        public string Email { get; set; }

        public string Nombre { get; set; }

        

        public List<Elemento> Elementos { get; set; }


    }
}


namespace BLL
{
    using DAL;
    using BE;
    public class EmpleadoBLL
    {

        EmpleadoDAL mapper = new EmpleadoDAL();


        public List<BE.Empleado> ListarEmpleados(BE.Cliente cliente)
        {
            List<BE.Empleado> empleados = new List<BE.Empleado>();

            try
            {
                empleados = mapper.listar(cliente);
            }
            catch (Exception)
            {

                throw;
            }

            return empleados;
        }


        public void alta(Empleado empleado, Cliente empleador)
        {

            try
            {
                mapper.alta(empleado, empleador);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void baja(Empleado empleado, Cliente empleador)
        {

            try
            {
                mapper.baja(empleado, empleador);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void modificar(Empleado empleado)
        {

            try
            {
                mapper.modificar(empleado);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool ValidarElementos(List<BE.Empleado> empleados)
        {
            return true;
        }



        public bool ValidarEmpleados()
        {
            return true;
        }


    }
}


namespace DAL
{
    using BE;
    using System.Data;
    using System.Data.SqlClient;

    public class EmpleadoDAL
    {
        public List<Empleado> listar(Cliente uncliente)
        {
           

            List<Empleado> empleados = new List<Empleado>();

            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@idcliente", uncliente.CodigoCliente));
            DataTable tabla = DAO.LeerConParametros("ListarEmpleados",parameters);
            DAO.Cerrar();

            foreach (DataRow registro in tabla.Rows)
            {
                Empleado empleado = new Empleado();
                empleado.DNI = int.Parse(registro["DNI"].ToString());
                empleado.Nombre = registro["Nombre"].ToString();
                empleado.Dirección = registro["Direccion"].ToString();
                empleado.Email = registro["Email"].ToString();
                           
                empleados.Add(empleado);
            }

            return empleados;
           


        }


        public void alta(Empleado empleado, Cliente empleador)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(DAO.CrearParametro("@DNI",empleado.DNI));
            parameters.Add(DAO.CrearParametro("@Nombre",empleado.Nombre));
            parameters.Add(DAO.CrearParametro("@Direccion",empleado.Dirección));
            parameters.Add(DAO.CrearParametro("@Email",empleado.Email));
            parameters.Add(DAO.CrearParametro("@idempleador", empleador.CodigoCliente));
            DAO.Escribir("AltaEmpleado", parameters);

            DAO.Cerrar();
        }


        public void baja(Empleado empleado, Cliente empleador)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@DNI", empleado.DNI));
            parameters.Add(DAO.CrearParametro("@idempleador", empleador.CodigoCliente));
            DAO.Escribir("BajaEmpleado", parameters);

            DAO.Cerrar();
        }


        public void modificar(Empleado empleado)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(DAO.CrearParametro("@DNI", empleado.DNI));
            parameters.Add(DAO.CrearParametro("@Nombre", empleado.Nombre));
            parameters.Add(DAO.CrearParametro("@Direccion", empleado.Dirección));
            parameters.Add(DAO.CrearParametro("@Email", empleado.Email));
            DAO.Escribir("ModificarEmpleado", parameters);

            DAO.Cerrar();
        }

    }


}
