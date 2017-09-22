using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoBD
{
    public class clsTabla
    {
        public DataTable Registros(String strTable, String instanceName, String database = "master")
        {
            SqlCommand oCM = new SqlCommand(String.Format("SELECT * FROM {0}", strTable));
            oCM.CommandType = CommandType.Text;
            return new clsConexion(instanceName: instanceName, database: database).Select(oCM);
            
        }

        public DataTable Tablas(String instanceName, String var = "master")
        {
            SqlCommand objSQL = new SqlCommand();
            objSQL.CommandType = CommandType.Text;
            objSQL.CommandText = "sp_Tables";
            return new clsConexion(instanceName, var).Select(objSQL);
        }
    }
}
