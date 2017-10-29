using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoBD
{
    public class clsIndices
    {
        public DataTable Indices(String instanceName, String var = "master")
        {
            SqlCommand objSQL = new SqlCommand();
            objSQL.CommandType = CommandType.Text;
            objSQL.CommandText = "exec sp_helpindex";
            return new clsConexion(instanceName, var).Select(objSQL);
        }
    }
}
