namespace CapaVista
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboBD = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // cboBD
            // 
            this.cboBD.FormattingEnabled = true;
            this.cboBD.ItemHeight = 23;
            this.cboBD.Location = new System.Drawing.Point(61, 161);
            this.cboBD.Name = "cboBD";
            this.cboBD.Size = new System.Drawing.Size(129, 29);
            this.cboBD.TabIndex = 1;
            this.cboBD.UseSelectable = true;
            this.cboBD.SelectedIndexChanged += new System.EventHandler(this.cboBD_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 595);
            this.Controls.Add(this.cboBD);
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox cboBD;
    }
}