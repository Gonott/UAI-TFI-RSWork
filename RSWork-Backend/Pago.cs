using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Pago
    {

        public int nroPago { get; set; }

        public DateTime fecha { get; set; }

        public string hora { get; set; }


        public bool pagado { get; set; }


        public float monto { get; set; }


    }


}

namespace BLL
{
    using BE;
    using DAL;

    public class PagoBLL
    {
        PagoDAL mapper = new PagoDAL();
    
        public void AltaPagoContrato(Pago pago, Contrato contrato)
        {
            try
            {
                mapper.AltaPagoContrato(pago, contrato);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void ListarPagosContrato(int idcontrato)
        {
            try
            {
                mapper.ListarPagosContrato(idcontrato);
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
    using System.Data.SqlClient;
    public class PagoDAL
    {

        public void AltaPagoContrato(Pago pago, Contrato contrato)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(DAO.CrearParametro("@idContrato", contrato.NumeroContrato));
            parameters.Add(DAO.CrearParametro("@fecha", pago.fecha));
            parameters.Add(DAO.CrearParametro("@hora", pago.hora));
            parameters.Add(DAO.CrearParametro("@pagado", pago.pagado));
            parameters.Add(DAO.CrearParametro("@monto", pago.monto));
            DAO.Escribir("AltaContratoPagos", parameters);

            DAO.Cerrar();
        }


        public List<Pago> ListarPagosContrato(int idcontrato)
        {
            List<Pago> pagos = new List<Pago>();
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@idContrato", idcontrato));
            DataTable tabla = DAO.LeerConParametros("ListarPagosContrato", parameters);

            foreach (DataRow registro in tabla.Rows)
            {
                Pago pago = new Pago();
                pago.nroPago = int.Parse(registro["NroPago"].ToString());
                pago.fecha = DateTime.Parse(registro["Fecha"].ToString());
                pago.hora = registro["hora"].ToString();
                pago.pagado = bool.Parse(registro["pagado"].ToString());
                pago.monto = float.Parse(registro["monto"].ToString());
                pagos.Add(pago);

            }

            return pagos;


        }


    }


}
