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
    public partial class frmIndices : MetroFramework.Forms.MetroForm
    {
        public frmIndices()
        {
            InitializeComponent();
        }

        private void frmIndices_Load(object sender, EventArgs e)
        {

        }
        public String indice="hola";
        private void metroButton1_Click(object sender, EventArgs e)
        {
            indice = "cluster";
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            indice = "no cluster";
        }
    }
}
