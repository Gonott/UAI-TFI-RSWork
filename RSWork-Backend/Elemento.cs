using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Elemento
    {
        public string Caracteristicas { get; set; }

        public string Condición { get; set; }

        public string Descripción { get; set; }

        public string Nombre { get; set; }

        public int Código { get; set; }

        public float Precio { get; set; }


        public enum TipoElemento
        {
            Notebook,
            Desktop,
            Monitor,
            Periferico,
            Escritorio,
            Silla
        }





    }

}


namespace BLL
{

    public class BLLElemento
    {
        
        
        public List<BE.Elemento> FiltrarElementos(string a,BE.Elemento.TipoElemento unelemento, string b)
        {
        List<BE.Elemento> elementos = new List<BE.Elemento>();
        return elementos;
        }


        public List<BE.Elemento> ListarElementos()
        {
            List < BE.Elemento > elementos = new List<BE.Elemento>();
            return elementos;
        }





    }


  

}