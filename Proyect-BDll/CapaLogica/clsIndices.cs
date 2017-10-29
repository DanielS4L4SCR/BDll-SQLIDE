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

        public DataTable RegistroInices(String strTable, String strInstanceName, String strDataBase = "master")
        {
            return new CapaAccesoBD.clsIndices().Indices(strTable, strDataBase);
        }


    }
}
