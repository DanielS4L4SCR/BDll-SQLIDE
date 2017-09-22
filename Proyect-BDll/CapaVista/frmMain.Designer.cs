namespace CapaVista
{
    partial class lbTabñas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBD = new System.Windows.Forms.GroupBox();
            this.lbTabla = new System.Windows.Forms.ListBox();
            this.cboBD = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCargar = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            this.gbBD.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbBD);
            this.groupBox1.Location = new System.Drawing.Point(3, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 459);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // gbBD
            // 
            this.gbBD.Controls.Add(this.lbTabla);
            this.gbBD.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBD.Location = new System.Drawing.Point(6, 19);
            this.gbBD.Name = "gbBD";
            this.gbBD.Size = new System.Drawing.Size(167, 241);
            this.gbBD.TabIndex = 0;
            this.gbBD.TabStop = false;
            // 
            // lbTabla
            // 
            this.lbTabla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTabla.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbTabla.FormattingEnabled = true;
            this.lbTabla.ItemHeight = 15;
            this.lbTabla.Location = new System.Drawing.Point(6, 19);
            this.lbTabla.Name = "lbTabla";
            this.lbTabla.Size = new System.Drawing.Size(152, 195);
            this.lbTabla.TabIndex = 0;
            // 
            // cboBD
            // 
            this.cboBD.FormattingEnabled = true;
            this.cboBD.ItemHeight = 23;
            this.cboBD.Location = new System.Drawing.Point(28, 35);
            this.cboBD.Name = "cboBD";
            this.cboBD.Size = new System.Drawing.Size(145, 29);
            this.cboBD.TabIndex = 1;
            this.cboBD.UseSelectable = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCargar);
            this.groupBox2.Controls.Add(this.cboBD);
            this.groupBox2.Location = new System.Drawing.Point(3, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 97);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(179, 41);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(50, 23);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseSelectable = true;
            this.btnCargar.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // lbTabñas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 595);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "lbTabñas";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 20, 20);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbBD.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroComboBox cboBD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbBD;
        private System.Windows.Forms.ListBox lbTabla;
        private MetroFramework.Controls.MetroButton btnCargar;
    }
}