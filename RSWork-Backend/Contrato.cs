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

        public List<Pago> pagos { get; set; }

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

    ////asignar los elementos al pago
    ///luego toca calcular el plan de pagos.
    ///luego asignar los pagos.
    ///luego pegarle a dal. 
    


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
        public void AltaContratoCabecera(Contrato contrato)
        {
            ///sirve para dar de alta la cabecera del contrato.
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(DAO.CrearParametro("@nroContrato", contrato.NumeroContrato));
            parameters.Add(DAO.CrearParametro("@codProveedor", contrato.codProveedor));
            parameters.Add(DAO.CrearParametro("@codCliente", contrato.codCliente));
            parameters.Add(DAO.CrearParametro("@fechaContrato", contrato.FechaContrato));
            parameters.Add(DAO.CrearParametro("@fechaInicio", contrato.FechaInicio));
            parameters.Add(DAO.CrearParametro("@fechaFin", contrato.FechaFinal));
            parameters.Add(DAO.CrearParametro("@monto", contrato.Monto));
            DAO.Escribir("AltaCabeceraContrato", parameters);

            DAO.Cerrar();

        }


        public void AltaContratoDetalle(Contrato contrato)
        {
            DAO.Abrir();
            foreach (Elemento item in contrato.Elementos)
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(DAO.CrearParametro("@nroContrato", contrato.NumeroContrato));
                parameters.Add(DAO.CrearParametro("@nroElemento", item.Código));
                DAO.Escribir("AltaContratoDetalle", parameters);
            }
            DAO.Cerrar();

        }



        public void AltaContratoPagos(Contrato contrato)
        {

            DAO.Abrir();
            foreach (Pago item in contrato.pagos)
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(DAO.CrearParametro("@idContrato", contrato.NumeroContrato));
                parameters.Add(DAO.CrearParametro("@fecha", item.fecha));
                parameters.Add(DAO.CrearParametro("@hora", item.hora));
                parameters.Add(DAO.CrearParametro("@pagado", item.pagado.ToString()));
                DAO.Escribir("AltaContratoPagos", parameters);
            }
            DAO.Cerrar();

        }



        public Contrato LlenarContrato(Contrato contrato)
        {

            //llenar los elementos del contrato.

            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@nroContrato", contrato.NumeroContrato));
            DataTable tabla = DAO.LeerConParametros("ListarElementosContrato", parameters); //lista haciendo inner join con la tabla intermedia de ContratoDetalle.

            DAO.Cerrar();

            foreach (DataRow registro in tabla.Rows)
            {
                Elemento elemento = new Elemento();
                elemento.Código = int.Parse(registro["Codigo"].ToString());
                elemento.Caracteristicas = registro["Caracteristicas"].ToString();
                elemento.Condición = registro["Condicion"].ToString();
                elemento.Descripción = registro["Descripcion"].ToString();
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
                contrato.Elementos.Add(elemento);

            }


            ////ahora listar los pagos del contrato.

            List<Pago> pagos = new List<Pago>();
            DAO.Abrir();
            List<IDbDataParameter> parameterspay = new List<IDbDataParameter>();
            parameterspay.Add(DAO.CrearParametro("@idcontrato", contrato.NumeroContrato));
            DataTable tablacontratos = DAO.LeerConParametros("ListarPagosContrato", parameterspay);

            foreach (DataRow registro in tablacontratos.Rows)
            {
                Pago pago = new Pago();
                pago.nroPago = int.Parse(registro["NroPago"].ToString());
                pago.fecha = DateTime.Parse(registro["Fecha"].ToString()); ;
                pago.hora = registro["hora"].ToString();
                pago.pagado= bool.Parse(registro["pagado"].ToString());
                contrato.pagos.Add(pago);

            }

            return contrato;







        }




        //Ver el detalle de un contrato - Cargar contrato full.


  

    }

}