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


    }
}
