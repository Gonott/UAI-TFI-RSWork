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
        PagoBLL pagobll = new PagoBLL();

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

        public List<Contrato> ListarContratosProveedor(Proveedor proveedor)
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


        public float CalcularValorElementoTiempo(Contrato contrato, string periodo, float precioElemento)
        {
            float precioPeriodo = 0;
            TimeSpan ts = contrato.FechaFinal - contrato.FechaInicio;
            switch (periodo)
            {
                case "Días": //calcula el precio de un elemento por la cantidad de días.
                    precioPeriodo = (precioElemento / 30) * ts.Days;
                    break;
                case "Meses": // calcula el precio de un elemento por la cantidad de meses.
                    precioPeriodo = precioElemento * (ts.Days / 30);
                    break;
                case "Años": // calcula el precio de un elemento por la cantidad de años.
                    precioPeriodo = (precioElemento * 12) * (ts.Days / 365);
                    break;
                default:
                    break;
            }
            return precioPeriodo; 

        }


        public List<Pago> CalcularPlanPagos(Contrato contrato, string periodo)
        {
            List<Pago> pagos = new List<Pago>();
            TimeSpan ts = contrato.FechaFinal - contrato.FechaInicio;
            switch (periodo)
            {
                case "Días": //calcula las cuotas para un periodo de días..
                    if (ts.Days <= 30) // si es dias posta, listo un solo pago, devuelvo uno solo.
                    {
                        Pago pago = new Pago();
                        pago.fecha = contrato.FechaFinal;
                        pago.monto = contrato.Monto;
                        pago.pagado = false;
                        pago.hora = "00:00:00";
                        pagos.Add(pago);
                    }
                    break;
                case "Meses": // calcula los pagos para periodos mensuales.
                    int cantMeses = (ts.Days / 30);
                    DateTime fechapago = contrato.FechaInicio.AddDays(30);
                    for (int i = 0; i < cantMeses; i++)
                    {
                        Pago pago = new Pago();
                        pago.monto = contrato.Monto / cantMeses;
                        pago.fecha = fechapago;
                        fechapago = fechapago.AddDays(30);
                        pago.hora = "00:00:00";
                        pago.pagado = false;
                        pagos.Add(pago);

                    }
                    break;
                case "Años": // calcula el los pagos para periodos anuales.
                    int cantAños = (ts.Days / 365);
                    DateTime fechapagoanual = contrato.FechaInicio.AddDays(365);
                    for (int i = 0; i < cantAños; i++)
                    {
                        Pago pago = new Pago();
                        pago.monto = contrato.Monto / cantAños;
                        pago.fecha = fechapagoanual;
                        if (fechapagoanual.AddDays(365)> contrato.FechaFinal)
                        {
                            fechapagoanual = contrato.FechaFinal;
                        }
                        else
                        {
                            fechapagoanual = fechapagoanual.AddDays(365);
                        }
                        pago.hora = "00:00:00";
                        pago.pagado = false;
                        pagos.Add(pago);
                    }
                    break;
                default:
                    break;
            }
            return pagos;

        }


        public void AltaContrato(Contrato contrato) 
        ///aca se da de alta la cabecera, y una instancia en la tabla intermedia
        ///ContratoDetalle donde esta la cantidad de elementos de la relación.
        {
            try
            {
                mapper.AltaContratoCabecera(contrato);//damos de alta la cabecera
                //luego por cada item damos de alta el item.
                foreach (Elemento item in contrato.Elementos)
                {
                    mapper.AltaContratoDetalle(contrato,item);
                }
                //por cada pago, damos de alta el pago.
                foreach (Pago pago in contrato.pagos)
                {
                    pagobll.AltaPagoContrato(pago, contrato);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void ConstruirContrato()
        {

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
                contrato.codProveedor = int.Parse(registro["CodProveedor"].ToString());
                contrato.FechaInicio = DateTime.Parse(registro["FechaInicio"].ToString());
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


        public void AltaContratoDetalle(Contrato contrato, Elemento elemento)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@nroContrato", contrato.NumeroContrato));
            parameters.Add(DAO.CrearParametro("@nroElemento", elemento.Código));
            parameters.Add(DAO.CrearParametro("@cantidad", elemento.cantidad));
            DAO.Escribir("AltaContratoDetalle", parameters);
            DAO.Cerrar();

        }



        public Contrato LlenarContrato(Contrato contrato)
        {

            //llenar los elementos del contrato.
            PagoDAL pagodal = new PagoDAL();
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
                elemento.Precio = float.Parse(registro["Precio"].ToString());
                elemento.stockProveedor = int.Parse(registro["Cantidad"].ToString());
                contrato.Elementos.Add(elemento);

            }

            contrato.pagos = pagodal.ListarPagosContrato(contrato.NumeroContrato);
            ////ahora listar los pagos del contrato.

            //List<Pago> pagos = new List<Pago>();
            //DAO.Abrir();
            //List<IDbDataParameter> parameterspay = new List<IDbDataParameter>();
            //parameterspay.Add(DAO.CrearParametro("@idcontrato", contrato.NumeroContrato));
            //DataTable tablacontratos = DAO.LeerConParametros("ListarPagosContrato", parameterspay);

            //foreach (DataRow registro in tablacontratos.Rows)
            //{
            //    Pago pago = new Pago();
            //    pago.nroPago = int.Parse(registro["NroPago"].ToString());
            //    pago.fecha = DateTime.Parse(registro["Fecha"].ToString()); ;
            //    pago.hora = registro["hora"].ToString();
            //    pago.pagado= bool.Parse(registro["pagado"].ToString());
            //    contrato.pagos.Add(pago);

            //}

            return contrato;







        }





  

    }

}