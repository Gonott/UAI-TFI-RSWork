using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    internal class DAO
    {

        private SqlTransaction tx;
        private static SqlConnection cn;

        public static void Abrir()
        {
            cn = new SqlConnection("Data Source=(local);Initial Catalog=RSWork;Integrated Security=True");
            cn.Open();
        }

        public static void Cerrar()
        {
            cn.Close();
            cn = null;
            GC.Collect();
        }

        public void iniciarTransaccion()
        {
            tx = cn.BeginTransaction();
        }


        private static SqlCommand CrearComando(string Sql, List<IDbDataParameter> parametros = null, CommandType tipo = CommandType.StoredProcedure)
        {
            SqlCommand comando = new SqlCommand(Sql, cn);
            comando.CommandType = tipo;
            if (parametros != null && parametros.Count > 0)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            return comando;
        }

        public static int Escribir(string Sql, List<IDbDataParameter> parametros = null)
        {
            SqlCommand cmd = CrearComando(Sql, parametros);
            int resultado;
            try
            {
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                //resultado = -1;
            }

            return resultado;
        }

        #region Leer
   public static DataTable LeerConParametros(string Sql, List<IDbDataParameter> parametros)
        {

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = CrearComando(Sql, parametros);
            DataTable tabla = new DataTable();
            ad.Fill(tabla);

            return tabla;

        }



        public static DataTable Leer(string Sql, List<IDbDataParameter> parametros = null)
        {
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = CrearComando(Sql, parametros);
            DataTable tabla = new DataTable();
            ad.Fill(tabla);

            return tabla;
        }



        #endregion

     

        #region Creacion de Parametros



        public static IDbDataParameter CrearParametro(string nom, string valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.String;
            return par;
        }

        public static IDbDataParameter CrearParametro(string nom, decimal valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.Decimal;
            return par;
        }

        public static IDbDataParameter CrearParametro(string nom, int valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.Int32;
            return par;
        }

        public static IDbDataParameter CrearParametro(string nom, DateTime valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.DateTime;
            return par;
        }


        public static IDbDataParameter CrearParametro(string nom, float valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.Double;
            return par;
        }

        #endregion



    }
}
