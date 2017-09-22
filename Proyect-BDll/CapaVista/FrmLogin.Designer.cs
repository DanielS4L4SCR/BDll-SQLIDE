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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnInicio = new MetroFramework.Controls.MetroButton();
            this.cboInstancias = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(36, 74);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(148, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nombre de la Instancia:";
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(297, 193);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(62, 23);
            this.btnInicio.TabIndex = 3;
            this.btnInicio.Text = "Conectar";
            this.btnInicio.UseSelectable = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // cboInstancias
            // 
            this.cboInstancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInstancias.FormattingEnabled = true;
            this.cboInstancias.Location = new System.Drawing.Point(144, 115);
            this.cboInstancias.Name = "cboInstancias";
            this.cboInstancias.Size = new System.Drawing.Size(215, 28);
            this.cboInstancias.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CapaVista.Properties.Resources.if_Enter_728934;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(362, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(27, 23);
            this.panel1.TabIndex = 7;
            // 
            // btnLoad
            // 
            this.btnLoad.BackgroundImage = global::CapaVista.Properties.Resources.if_icon_111_search_314478;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.Transparent;
            this.btnLoad.Location = new System.Drawing.Point(362, 120);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(27, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 239);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboInstancias);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.metroLabel1);
            this.ForeColor = System.Drawing.Color.Green;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "SQL MANAGER";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnInicio;
        private System.Windows.Forms.ComboBox cboInstancias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
    }
}