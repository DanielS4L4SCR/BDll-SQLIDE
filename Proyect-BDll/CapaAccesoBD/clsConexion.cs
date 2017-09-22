using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoBD
{
    public class clsConexion
    {
        SqlConnection objConexion;


        public clsConexion(String instanceName, String database = "master")
        {
            objConexion = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", instanceName, database));
        }

        public bool abrirConexion()
        {
            try
            {
                objConexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool cerrarConexion()
        {
            try
            {
                if (objConexion.State == ConnectionState.Closed)
                {
                    return true;
                }
                objConexion.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.Close();
            }
        }

        public DataTable Select(SqlCommand oSQLC)
        {

            try
            {
                oSQLC.Connection = objConexion;
                DataTable oDT = new DataTable();
                SqlDataAdapter oSQLDA = new SqlDataAdapter(oSQLC);

                if (abrirConexion())
                {
                    oSQLDA.Fill(oDT);
                }
                cerrarConexion();

                return oDT;

            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
                return null;
            }
        }

        public bool Comando(SqlCommand oSQLC)
        {
            try
            {
                oSQLC.Connection = objConexion;
                if (abrirConexion())
                {
                    oSQLC.ExecuteNonQuery();
                    cerrarConexion();
                    return true;
                }
                cerrarConexion();
                return false;
            }
            catch
            {
                cerrarConexion();
                return false;
            }
        }

    }
}
