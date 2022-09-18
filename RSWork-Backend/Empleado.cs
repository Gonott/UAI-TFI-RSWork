using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Empleado
    {

        public string Dirección { get; set; }

        public int DNI { get; set; }


        public string Email { get; set; }

        public string Nombre { get; set; }



        public List<Elemento> Elementos { get; set; }


    }
}


namespace BLL
{

    public class EmpleadoBLL
    {

        public List<BE.Empleado> ListarEmpleados(BE.Cliente cliente)
        {
            List<BE.Empleado> empleados = new List<BE.Empleado>();
            return empleados;
        }



        public bool ValidarElementos(List<BE.Empleado> empleados)
        {
            return true;
        }



        public bool ValidarEmpleados()
        {
            return true;
        }


    }
}
