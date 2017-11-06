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
        static frmIndices newMessageBox;
        public Timer msgTimer;
        static string Button_id;
        int disposeFormTimer;
        public frmIndices()
        {
            InitializeComponent();
        }

        public static string ShowBox(string txtMessage)
        {
            newMessageBox = new frmIndices();
            newMessageBox.lblmessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        public static string ShowBox(string txtMessage, string txtTitle)
        {
            newMessageBox = new frmIndices();
            newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.lblmessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }
        public void frmIndices_Load(object sender, EventArgs e)
        {
            disposeFormTimer = 30;
            newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            msgTimer = new Timer();
            msgTimer.Interval = 1000;
            msgTimer.Enabled = true;
            msgTimer.Start();
            msgTimer.Tick += new System.EventHandler(this.timer_tick);
        }

        private void timer_tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            }
            else
            {
                newMessageBox.msgTimer.Stop();
                newMessageBox.msgTimer.Dispose();
                newMessageBox.Dispose();
            }
        }

        public void metroButton1_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "1";
            newMessageBox.Dispose();
        }

        public void metroButton2_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "2";
            newMessageBox.Dispose();
        }

       
    }
}
