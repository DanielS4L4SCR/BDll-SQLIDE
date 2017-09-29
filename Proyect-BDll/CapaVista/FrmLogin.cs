using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        String Instancia;
        public Login()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (cboInstancias.Text.ToString().Trim() != String.Empty)
            {
                if (new CapaLogica.clsBaseDatos().Conexion(cboInstancias.Text.ToString().Trim()))
                {
                    new lbTabñas(cboInstancias.Text.ToString(), this).Show();
                    Instancia = cboInstancias.Text.ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Conexión erronea, verifique el nombre de la instancia");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese o seleccione una instancia");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cboInstancias.DataSource = new CapaLogica.clsBaseDatos().Intancias();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Load1.Width += 3;
            if (Load1.Width >= 499)
            {
                cboInstancias.DataSource = new CapaLogica.clsBaseDatos().Intancias();
                load.Stop();
            }

        }

    }
}
