using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Empresa
    {

        public Int64 CUIT { get; set; }

        public string Direccion { get; set; }

        public string email { get; set; }

        public string Nombre { get; set; }


        public string Telefono { get; set; }


        public List<Contrato> Contratos { get; set; }


    }
}
