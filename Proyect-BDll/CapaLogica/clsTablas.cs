using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class clsTablas
    {
        public DataTable Registro(String strTable, String strInstanceName, String strDataBase = "master")
        {
            return new CapaAccesoBD.clsTabla().Registros(strTable, strInstanceName, strDataBase);
        }

 
        public DataTable Tablas(String strInstanceName, String strDatabase = "master")
        {
            DataTable oDT = new CapaAccesoBD.clsTabla().Tablas(strInstanceName, strDatabase);

            List<DataRow> deleteRows = new List<DataRow>();
            foreach (DataRow item in oDT.Rows)
            {
                if (item["TABLE_OWNER"].ToString() != "dbo")
                {
                    deleteRows.Add(item);
                }
            }

            foreach (var item in deleteRows)
            {
                oDT.Rows.Remove(item);
            }
            return oDT;
        }
    }
}
