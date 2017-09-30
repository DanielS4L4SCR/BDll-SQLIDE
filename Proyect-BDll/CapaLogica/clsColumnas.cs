using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class clsColumnas

    {
        public DataTable EsquemeInfo(String strColumn, String strTable, String instanceName, String strDataBase = "master")
        {
            return new CapaAccesoBD.clsColumnas().EsquemeInfo(strColumn, strTable, instanceName, strDataBase);
        }

        public DataTable DATATYPE(String strColumn, String strTable, String instanceName, String strDataBase = "master")
        {
            return new CapaAccesoBD.clsColumnas().EsquemeInfo(strColumn, strTable, instanceName, strDataBase);
        }

        public DataTable getColumns(string strTable, String instance, String database = "master")
        {
           return new CapaAccesoBD.clsColumnas().getColumns(strTable, instance, database);           
        }
    }
}
