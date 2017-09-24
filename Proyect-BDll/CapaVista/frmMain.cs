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
        List<TabPage> AllTabPages = new List<TabPage>();
        int cont = 0;

        public lbTabñas(String instanceName, Form login)
        {
            InitializeComponent();
            this.instanceName = instanceName;
            this.login = login;
            HideTabPage(Tab1);
            HideTabPage(tab2);
            HideTabPage(tab3);
            HideTabPage(tab4);
            HideTabPage(tab5);

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
            #region ifTab
            if (cont < 5)
            {
                if (cont == 0)
                {
                    ShowTabPage(Tab1);
                    Tab1.Show();
                    cont = cont + 1;
                }
                else if (cont == 1)
                {
                    ShowTabPage(tab2);
                    tab2.Show();
                    cont = cont + 1;
                }
                else if (cont == 2)
                {
                    ShowTabPage(tab3);
                    tab3.Show();
                    cont = cont + 1;
                }
                else if (cont == 3)
                {
                    ShowTabPage(tab4);
                    tab4.Show();
                    cont = cont + 1;
                }
                else if (cont == 4)
                {
                    ShowTabPage(tab5);
                    tab5.Show();
                    cont = cont + 1;
                }
              }
#endregion
            else
            {
                MessageBox.Show("Máximo de pestañas superado");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El texto seleccionado es: " + txtQuery1.SelectedText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbReloj.Text = DateTime.Now.ToLongTimeString();

        }


        #region TabControl
        public void HideTabPage(TabPage tb)
        {

            if (tabContQuery.TabPages.Contains(tb))
            {
                foreach (TabPage t in tabContQuery.TabPages)
                {
                    if (!AllTabPages.Contains(t))
                        AllTabPages.Add(t);
                }
                this.tabContQuery.TabPages.Remove(tb);
            }
        }

        public void ShowTabPage(TabPage tb)
        {
            if ((AllTabPages.Contains(tb)) && (!tabContQuery.TabPages.Contains(tb)))
                this.tabContQuery.TabPages.Add(tb);

        }
        #endregion

        #region Boton Cerrar
        private void button1_Click_1(object sender, EventArgs e)
        {
            tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
            cont = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
            cont = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
            cont = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
            cont = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
            cont = 0;
        }
        #endregion
    }
}


