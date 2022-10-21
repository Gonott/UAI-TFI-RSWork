using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Proveedor : Empresa
    {

        public int CodigoProveedor { get; set; }

        public TipoProveedor tipoProveedor { get; set; }

        public enum TipoProveedor
        {
            Fabricante,
            Mayorista,
            Minorista
        }

        public List<Orden> Ordenes { get; set; }






    }
}

namespace BLL
{
    using DAL;
    using BE;
    public class ProveedorBLL
    {
        ProveedorDAL mapper = new ProveedorDAL();
        
        public void Modificar(Proveedor proveedor)
        {
            try
            {
                mapper.Modificar(proveedor);
            }
            catch (Exception exx)
            {

                throw exx;
            }
        }
    }

}


namespace DAL
{
    using BE;
    using System.Data;

    public class ProveedorDAL
    {


        public void Modificar(Proveedor proveedor)
        {
            DAO.Abrir();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DAO.CrearParametro("@codproveedor", proveedor.CodigoProveedor));
            parameters.Add(DAO.CrearParametro("@telefono", proveedor.Telefono));
            parameters.Add(DAO.CrearParametro("@direccion", proveedor.Direccion));
            parameters.Add(DAO.CrearParametro("@email", proveedor.email));
            DAO.Escribir("ModificarProveedor", parameters);
            DAO.Cerrar();

        }


    }



}
