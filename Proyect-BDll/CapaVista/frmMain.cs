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
    public partial class lbTabñas : MetroFramework.Forms.MetroForm
    {
        public String instanceName { get; set; }
        public Form login { get; set; }



        public lbTabñas(String instanceName, Form login)
        {
            InitializeComponent();
            this.instanceName = instanceName;
            this.login = login;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            cboBD.DataSource = new CapaLogica.clsBaseDatos().BaseDatos(instanceName);
            cboBD.ValueMember = "DATABASE_NAME";
            cboBD.DisplayMember = "DATABASE_NAME";
            gbBD.Text = "";
            timer1.Start();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gbBD.Text = "Tablas de: " + cboBD.SelectedValue.ToString();
            DataTable objDT = new CapaLogica.clsTablas().Tablas(instanceName, cboBD.SelectedValue.ToString());
            lbTabla.DataSource = null;
            if (cboBD.Enabled)
            {
                if (objDT.Rows.Count > 0)
                {
                    lbTabla.DataSource = objDT;
                    lbTabla.DisplayMember = "TABLE_NAME";
                    lbTabla.ValueMember = "TABLE_NAME";

                }
                else
                {
                    if (objDT == null)
                    {
                        MessageBox.Show("Error");
                    }

                    MessageBox.Show("La base de datos selecciona no contiene tablas");
                    lbTabla.Items.Clear();

                }

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            tabQuery.Visible = true;
            btnExecute.Visible = true;
            btnClose.Visible = true;
            int cont = 0;

            if (tabQuery.TabCount < 5)
            {
                cont = cont + 1;
                string title = "Query " + (tabQuery.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                tabQuery.TabPages.Add(myTabPage);


            }
            else
            {
                MessageBox.Show("Máximo de pestañas superado");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El texto seleccionado es: " + txtQuery.SelectedText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbReloj.Text = DateTime.Now.ToLongTimeString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtQuery.Visible = false;
            btnClose.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

