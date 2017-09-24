using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoBD
{
    public class clsBaseDatos
    {
        public DataTable Instancias()
        {
            return SqlDataSourceEnumerator.Instance.GetDataSources();
        }

        public DataTable BaseDatos(String instanceName)
        {
            SqlCommand objSQL = new SqlCommand();
            objSQL.CommandType = CommandType.StoredProcedure;
            objSQL.CommandText = "sp_databases";
            return new clsConexion(instanceName).Select(objSQL);
        }
          }
}
