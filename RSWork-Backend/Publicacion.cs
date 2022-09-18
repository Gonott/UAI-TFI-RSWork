using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Publicacion
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public string Nombre{ get; set; }

        public string Imagen { get; set; }


        public string Resumen { get; set; }

        public BE.Elemento elemento{ get; set; }

        public Proveedor proveedor { get; set; }





    }



 }


