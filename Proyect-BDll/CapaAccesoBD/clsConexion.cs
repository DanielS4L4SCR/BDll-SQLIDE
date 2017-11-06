using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
namespace CapaAccesoBD
{
    public class clsConexion
    {
        SqlConnection objConexion;

        public clsConexion(String instanceName, String database = "master")
        {
            objConexion = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", instanceName, database));
        }

        
        public bool abrirConexion()
        {
            try
            {
                objConexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
       /* public SqlConnectionStringBuilder ObtenerServidor(String DataSourse, String BD)
        {
            SqlConnectionStringBuilder localBuilder = new SqlConnectionStringBuilder();
            localBuilder.DataSource = DataSourse;
            localBuilder.InitialCatalog = BD;
            localBuilder.IntegratedSecurity = true;
            return localBuilder;
        }*/
        public bool cerrarConexion()
        {
            try
            {
                if (objConexion.State == ConnectionState.Closed)
                {
                    return true;
                }
                objConexion.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.Close();
            }
        }

        public DataTable Select(SqlCommand oSQLC)
        {

            try
            {
                oSQLC.Connection = objConexion;
                DataTable oDT = new DataTable();
                SqlDataAdapter oSQLDA = new SqlDataAdapter(oSQLC);

                if (abrirConexion())
                {
                    oSQLDA.Fill(oDT);
                }
                cerrarConexion();

                return oDT;

            }
            catch (SqlException e)
            {
                //throw e;
                Console.Write(e.Message);
                return null;
            }
        }

        public bool Comando(SqlCommand oSQLC)
        {
            try
            {
                oSQLC.Connection = objConexion;
                if (abrirConexion())
                {
                    oSQLC.ExecuteNonQuery();
                    cerrarConexion();
                    return true;
                }
                cerrarConexion();
                return false;
            }
            catch
            {
                cerrarConexion();
                return false;
            }
        }
       

        public bool ejecutarInsert(String txtInsert,SqlConnection oCN)
        {
            SqlCommand cInsert = new SqlCommand(txtInsert);
            try
            {
                cInsert.Connection = oCN;
                cInsert.CommandType = CommandType.Text;
                if (abrirConexion())
                {
                    cInsert.ExecuteNonQuery();
                }
                cerrarConexion();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable ejecutar(String txtSelect, SqlConnection oCN)
        {
            SqlCommand cSelect = new SqlCommand();
            DataTable oDT = new DataTable();
            SqlDataAdapter oSQLDA = new SqlDataAdapter(cSelect);
            try
            {
                cSelect.CommandText = txtSelect;
                cSelect.Connection = oCN;
            }
            catch (Exception ex)
            {
                throw ex;  
            }
            try
            {
                if (abrirConexion())
                {
                    oSQLDA.Fill(oDT);
                    //MessageBox.Show("Comando ejecutado correctamente: ", "SQL MANAGER 2017", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Console.WriteLine("Comando ejecutado correctamente");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Comando con errores: " + ex.Message, "SQL MANAGER 2017", MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                
            }
            cerrarConexion();
            return oDT;
        }
    }
}
