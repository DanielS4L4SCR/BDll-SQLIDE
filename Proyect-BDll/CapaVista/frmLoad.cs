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
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
        }

        private void frmLoad_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rectangleShape2.Width += 5;
            if (rectangleShape2.Width >= 459)
            {
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }
    }
}
