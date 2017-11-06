using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class clsBaseDatos
    {
        public DataTable BaseDatos(String instanceName)
        {
            return new CapaAccesoBD.clsBaseDatos().BaseDatos(instanceName: instanceName);
        }

        public List<String> Intancias()
        {
            DataTable oDT = new CapaAccesoBD.clsBaseDatos().Instancias();
            List<String> instance = new List<String>();
            foreach (DataRow source in oDT.Rows)
            {
                string servername;
                string instanceName = source["InstanceName"].ToString();

                if (!string.IsNullOrEmpty(instanceName))
                {
                    servername = source["ServerName"] + "\\" + source["InstanceName"];
                }
                else
                {
                    servername = source["ServerName"].ToString();
                }
                instance.Add(servername);
            }
            return instance;

        }

        public bool Conexion(String instanceName)
        {
            
           return new CapaAccesoBD.clsConexion(instanceName: instanceName).abrirConexion();
           
        }

        public DataTable Ejectar(String consulta, SqlConnection instance, String instances)
        {
            return new CapaAccesoBD.clsConexion(instanceName:instances).ejecutar(consulta, instance);
        }

        
    }
}

