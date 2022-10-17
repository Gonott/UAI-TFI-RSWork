using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contrato
    {

        public Cliente cliente { get; set; }

        public int codCliente;

        public int codProveedor;

        public DateTime FechaContrato { get; set; }

        public List<Elemento> Elementos { get; set; }

        public DateTime FechaFinal { get; set; }

        public DateTime FechaInicio { get; set; }

        public float Monto { get; set; }

        public int NumeroContrato { get; set; }

        public Proveedor proveedor { get; set; }

    }
}


namespace BLL
{
    using BE;
    using DAL;

    public class ContratoBLL
    {
        ContratoDAL mapper = new ContratoDAL();

        public  List<Contrato> ContratosCliente(Cliente cliente)
        {
            try
            {
                return mapper.ListarContratosCliente(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Contrato> ContratosProveedor(Proveedor proveedor)
        {
            try
            {
                return mapper.ListarContratosProveedor(proveedor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }


}


namespace DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using BE;


    public class ContratoDAL
    {


        //Listar los contratos desde el punto de vista del cliente.
        
        public List<Contrato> ListarContratosProveedor(Proveedor proveedor)
        {
            List<Contrato> contratos = new List<Contrato>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codproveedor", proveedor.CodigoProveedor));
            DataTable tabla = DAO.LeerConParametros("ListarContratosProveedor", parameters);

            foreach (DataRow registro in tabla.Rows)
            {
                Contrato contrato = new Contrato();
                contrato.NumeroContrato = int.Parse(registro["NroContrato"].ToString());
                contrato.proveedor = proveedor;
                contrato.codCliente = int.Parse(registro["CodCliente"].ToString()); ;
                contrato.FechaInicio = DateTime.Parse(registro["FechaIncio"].ToString())  ;
                contrato.FechaFinal = DateTime.Parse(registro["FechaFinal"].ToString())  ;
                contrato.Monto= float.Parse(registro["Monto"].ToString());
                contrato.FechaContrato = DateTime.Parse(registro["FechaContrato"].ToString());
                contratos.Add(contrato);

            }

            return contratos;
        }


        //Listar contratos desde el punto de vista del proveedor.
        public List<Contrato> ListarContratosCliente(Cliente cliente)
        {
            List<Contrato> contratos = new List<Contrato>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codCliente", cliente.CodigoCliente));
            DataTable tabla = DAO.LeerConParametros("ListarContratosCliente", parameters);

            foreach (DataRow registro in tabla.Rows)
            {
                Contrato contrato = new Contrato();
                contrato.NumeroContrato = int.Parse(registro["NroContrato"].ToString());
                contrato.cliente = cliente;
                contrato.codProveedor= int.Parse(registro["CodProveedor"].ToString()); ;
                contrato.FechaInicio = DateTime.Parse(registro["FechaIncio"].ToString());
                contrato.FechaFinal = DateTime.Parse(registro["FechaFinal"].ToString());
                contrato.Monto = float.Parse(registro["Monto"].ToString());
                contrato.FechaContrato = DateTime.Parse(registro["FechaContrato"].ToString());
                contratos.Add(contrato);

            }

            return contratos;
        }


        //Crear Contratos.
        public void AltaContrato(Contrato contrato)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            //parameters.Add(DAO.CrearParametro("@DNI", empleado.DNI));
            //parameters.Add(DAO.CrearParametro("@Nombre", empleado.Nombre));
            //parameters.Add(DAO.CrearParametro("@Direccion", empleado.Dirección));
            //parameters.Add(DAO.CrearParametro("@Email", empleado.Email));
            //parameters.Add(DAO.CrearParametro("@idempleador", empleador.CodigoCliente));
            //DAO.Escribir("AltaContrato", parameters);

            DAO.Cerrar();

        }



        //Ver el detalle de un contrato - Cargar contrato full.
  

    }

}