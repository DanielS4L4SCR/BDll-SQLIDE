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
        public DataTable registroIndice(String strTable, String instanceName, String strDatabase = "master")
        {
            SqlCommand objSQL = new SqlCommand();
            objSQL.CommandType = CommandType.Text;
            objSQL.CommandText = String.Format("SELECT i.name AS index_name" +
                                                " ,COL_NAME(ic.object_id, ic.column_id) AS column_name" +
                                                " FROM sys.indexes AS i" +
                                                " INNER JOIN sys.index_columns AS ic" +
                                                " ON i.object_id = ic.object_id AND i.index_id = ic.index_id" +
                                                " WHERE i.object_id = OBJECT_ID(@value)");
            objSQL.Parameters.AddWithValue("@value",strTable);
            return new clsConexion(instanceName, strDatabase).Select(objSQL);
        }


    }
}
