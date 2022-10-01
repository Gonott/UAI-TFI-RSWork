using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Proveedor
    {

        public int CodigoProveedor { get; set; }

        public enum TipoProveedor
        {
            Fabricante,
            Mayorista,
            Minorista
        }

        public List<Orden> Ordenes { get; set; }






    }
}
