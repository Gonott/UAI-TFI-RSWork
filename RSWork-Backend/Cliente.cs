using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente : Empresa
    {

        public int Categoria { get; set; }


        public int CodigoCliente { get; set; }

        public List<Empleado> Empleados { get; set; }




    }
}


namespace BLL
{

    public class ClienteBLL
    {


        public BE.Cliente EncontrarEmpCliente(BE.Usuario usu)
        {
            BE.Cliente cliente = new BE.Cliente();
            return cliente;
        }

    }


}