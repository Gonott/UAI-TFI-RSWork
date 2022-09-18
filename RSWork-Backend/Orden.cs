using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Orden
    {


        public List<Elemento> elementos { get; set; }


        public List<Empleado> empleados { get; set; }

        public int Numero{ get; set; }

        public string Razón { get; set; }


        public string Tipo { get; set; }

        public enum Estado
        {
            Aceptado,EnProceso,Ejecutado
        }

    }

}


namespace BLL
{

    public class OrdenBLL
    {
        public void EnviarOrden(BE.Contrato uncontrato)
        {

        }

        public List<BE.Orden> VerMisOrdenes(BE.Cliente uncliente)
        {
            List<BE.Orden> ordenes = new List<BE.Orden>();
            return ordenes;
        }



    }

}
