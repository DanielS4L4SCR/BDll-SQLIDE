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
        public DataTable TotalIndices(String instanceName, String strDatabase = "master")
        {
            SqlCommand objSQL = new SqlCommand();
            objSQL.CommandType = CommandType.Text;
            objSQL.CommandText = String.Format("SELECT i.name AS Nombre_Índice" + Environment.NewLine +
                                                ",object_name(i.object_id) As Nombre_Tabla" + Environment.NewLine +
                                                 ",COL_NAME(ic.object_id, ic.column_id) AS Nombre_Columna" + Environment.NewLine +
                                                "FROM sys.indexes AS i" + Environment.NewLine +
                                                "INNER JOIN sys.index_columns AS ic" + Environment.NewLine +
                                                 "ON i.object_id = ic.object_id AND i.index_id = ic.index_id");
            return new clsConexion(instanceName, strDatabase).Select(objSQL);
        }

        public DataTable TotalIndicesPorTB(String strTable, String instanceName, String strDatabase = "master")
        {
            SqlCommand objSQL = new SqlCommand();
            objSQL.CommandType = CommandType.Text;
            objSQL.CommandText = String.Format("SELECT i.name AS Nombre_Índice" + Environment.NewLine +
                                                ", object_name(i.object_id) As Nombre_Tabla" + Environment.NewLine +
                                                 " , COL_NAME(ic.object_id, ic.column_id) AS column_name" + Environment.NewLine +
                                                "FROM sys.indexes AS i" + Environment.NewLine +
                                                "INNER JOIN sys.index_columns AS ic" + Environment.NewLine +
                                                 " ON i.object_id = ic.object_id AND i.index_id = ic.index_id" + Environment.NewLine +
                                                 "WHERE i.object_id = OBJECT_ID(@value)");
            objSQL.Parameters.AddWithValue("@value", strTable);
            return new clsConexion(instanceName, strDatabase).Select(objSQL);
        }
    }
}
