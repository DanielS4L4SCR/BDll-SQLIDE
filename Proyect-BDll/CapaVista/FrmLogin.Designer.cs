namespace CapaVista
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnInicio = new MetroFramework.Controls.MetroButton();
            this.cboInstancias = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Load2 = new System.Windows.Forms.Panel();
            this.Load1 = new System.Windows.Forms.Panel();
            this.load = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.White;
            this.btnInicio.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnInicio.Location = new System.Drawing.Point(372, 171);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(76, 29);
            this.btnInicio.TabIndex = 3;
            this.btnInicio.Text = "Conectar";
            this.btnInicio.UseSelectable = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // cboInstancias
            // 
            this.cboInstancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInstancias.FormattingEnabled = true;
            this.cboInstancias.Location = new System.Drawing.Point(157, 115);
            this.cboInstancias.Name = "cboInstancias";
            this.cboInstancias.Size = new System.Drawing.Size(319, 28);
            this.cboInstancias.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel2.Location = new System.Drawing.Point(1, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 10);
            this.panel2.TabIndex = 9;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(25, 93);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(139, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nombre del Servidor:";
            // 
            // Load2
            // 
            this.Load2.BackColor = System.Drawing.Color.Black;
            this.Load2.Location = new System.Drawing.Point(-1, 209);
            this.Load2.Name = "Load2";
            this.Load2.Size = new System.Drawing.Size(499, 12);
            this.Load2.TabIndex = 12;
            // 
            // Load1
            // 
            this.Load1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Load1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Load1.Location = new System.Drawing.Point(-2, 209);
            this.Load1.Name = "Load1";
            this.Load1.Size = new System.Drawing.Size(18, 12);
            this.Load1.TabIndex = 13;
            // 
            // load
            // 
            this.load.Enabled = true;
            this.load.Interval = 25;
            this.load.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CapaVista.Properties.Resources.login1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(450, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(31, 27);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaVista.Properties.Resources.if_032_95930;
            this.pictureBox1.Location = new System.Drawing.Point(186, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 220);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Load1);
            this.Controls.Add(this.Load2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboInstancias);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Green;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "SQL MANAGER";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnInicio;
        private System.Windows.Forms.ComboBox cboInstancias;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel Load2;
        private System.Windows.Forms.Panel Load1;
        private System.Windows.Forms.Timer load;
        private System.Windows.Forms.Panel panel1;
    }
}