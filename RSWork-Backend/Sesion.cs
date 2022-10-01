using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace SERVICIOS
{
    public sealed class Sesion
    {
        public Usuario EsteUsuario;

        private Sesion()
        {

        }


        private static Sesion instancia = null;

        public static Sesion ObtenerInstancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sesion();
                }
                return instancia;
            }

        }


        public void CerrarSesion()
        {
            if (EsteUsuario != null)
            {
                //EsteUsuario.Autorizaciones = null;
                EsteUsuario = null;


            }
            else
            {
                return; 
            }
        }




    }
}
