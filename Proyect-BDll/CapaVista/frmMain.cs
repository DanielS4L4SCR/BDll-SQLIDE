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
        
         //aqui creas lod emas controles y los asignas al page
        TextBox txtQuery1 = new TextBox();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            /*tabQuery1.Visible = true;
            btnExecute.Visible = true;
            btnClose.Visible = true;
            txtQuery1.Location = new Point(2,2);
            txtQuery1.Size = new Size(755,496);
            txtQuery1.Multiline = true;
            if (tabQuery1.TabCount < 5)
            {
                cont = cont + 1;
                string title = "Query " + (tabQuery1.TabCount + 1).ToString();
                //TabPage myTabPage = new TabPage(title);
                //tabQuery1.TabPages.Add(myTabPage);
                TabPage page = new TabPage(title);
                tabQuery1.TabPages.Add(page);
                page.Controls.Add(txtQuery1);
            }
            else
            {
                MessageBox.Show("Máximo de pestañas superado");
            }*/
            txtConsulta.Visible = true;
            btnClose.Visible = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El texto seleccionado es: " + txtQuery1.SelectedText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbReloj.Text = DateTime.Now.ToLongTimeString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtConsulta.Visible = false;
            btnClose.Visible = false;
            
            //tabQuery1.TabPages.RemoveAt(tabQuery1.TabCount-1);
        }
    }
}

