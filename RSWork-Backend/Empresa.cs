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


namespace BLL
{
    using BE;
    using DAL;

    public class EmpresaBLL
    {
        EmpresaDAL mapper = new EmpresaDAL();

        public Empresa CargarEmpresa(int idempresa)
        {
            return mapper.CargarEmpresa(idempresa);
        }


    }

}


namespace DAL
{
    using System;
    using BE;
    using System.Data;
    using System.Data.SqlClient;


    public class EmpresaDAL
    {


        public Empresa CargarEmpresa(int idempresa)
        {

          
                DAO.Abrir();
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
               
                parameters.Add( DAO.CrearParametro("@idempresa", idempresa));
                DataTable tabla = DAO.LeerConParametros("EncontrarEmpresa", parameters);
                DAO.Cerrar();

                //se verifica el campo tipoEmpresa

            Empresa emp = null;

               if (tabla.Rows[0]["TipoEmpresa"].ToString() == "Cliente")
               {
                   Cliente empresa = new Cliente();
                   empresa.CodigoCliente = int.Parse(tabla.Rows[0]["id"].ToString());
                   empresa.Nombre = tabla.Rows[0]["Nombre"].ToString();
                   empresa.CUIT = Int64.Parse(tabla.Rows[0]["CUIT"].ToString());
                   empresa.Telefono = tabla.Rows[0]["Telefono"].ToString();
                   empresa.Direccion = tabla.Rows[0]["Direccion"].ToString();
                   empresa.email = tabla.Rows[0]["Email"].ToString();
                   empresa.Categoria = int.Parse(tabla.Rows[0]["Categoria"].ToString());
                   emp = empresa;
               }

            if (tabla.Rows[0]["TipoEmpresa"].ToString() == "Proveedor")
            {
                Proveedor empresa = new Proveedor();
                empresa.CodigoProveedor = int.Parse(tabla.Rows[0]["id"].ToString());
                empresa.Nombre = tabla.Rows[0]["Nombre"].ToString();
                empresa.CUIT = Int64.Parse(tabla.Rows[0]["CUIT"].ToString());
                empresa.Telefono = tabla.Rows[0]["Telefono"].ToString();
                empresa.Direccion = tabla.Rows[0]["Direccion"].ToString();
                empresa.email = tabla.Rows[0]["Email"].ToString();
                switch (tabla.Rows[0]["TipoProveedor"].ToString())
                {
                    case "Fabricante":
                        empresa.tipoProveedor = Proveedor.TipoProveedor.Fabricante;
                        break;
                    case "Mayorista":
                        empresa.tipoProveedor = Proveedor.TipoProveedor.Mayorista;
                        break;
                    case "Minorista":
                        empresa.tipoProveedor = Proveedor.TipoProveedor.Minorista;
                        break;
                }
                emp = empresa;
            }
            
            return emp;

          
        }


    }

}
