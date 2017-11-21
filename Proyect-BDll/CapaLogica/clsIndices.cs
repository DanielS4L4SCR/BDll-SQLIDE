using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class clsIndices
    {

        public bool EsquemaIndices(String strTable, String instanceName, String strDataBase = "master")
        {
            return new CapaAccesoBD.clsIndices().registroIndice(strTable, instanceName, strDataBase).Rows.Count > 0;
        }

        CapaAccesoBD.clsIndices TotalIn = new CapaAccesoBD.clsIndices();
        public DataTable TotalIndices(String InstanceName, String strDataBase = "master")
        {
            return TotalIn.TotalIndices(InstanceName, strDataBase);
        }
        public DataTable TotalIndicesPorTB(String strTable, String instanceName, String strDatabase = "master")
        {
            return TotalIn.TotalIndicesPorTB(strTable, instanceName, strDatabase);
        }
    }
}
