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
    public class ContratoBLL
    {


    }


}