using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ScintillaNET;
using MetroFramework;
using Microsoft.VisualBasic;

namespace CapaVista
{
    public partial class lbTabñas : MetroFramework.Forms.MetroForm
    {
        public String instanceName { get; set; }
        public Form login { get; set; }
        List<TabPage> AllTabPages = new List<TabPage>();
        int cont = 0;
        int contSelect = 0;
        int contInsert = 0;
        int contUpdate = 0;
        int contDelete = 0;
        int contDrop = 0;
        int contCreate = 0;
        int contAlter = 0;
        

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
                        MetroMessageBox.Show(this,"Error","SQL MANAGER 2017",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                    }

                    MetroMessageBox.Show(this,"La base de datos selecciona no contiene tablas","SQL MANAGER 2017",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);

                    lbTabla.Items.Clear();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbClock.Text = DateTime.Now.ToLongTimeString();

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
            DialogResult msj = MessageBox.Show("¿Seguro de que desea cerrar la pestaña?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
                cont = 0;
            }
            else if (msj == DialogResult.No)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult msj = MetroMessageBox.Show(this,"¿Seguro de que desea cerrar la pestaña?", "SQL MANAGER 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
                cont = 0;
                lbConsulta.Text = "";
            }
            else if (msj == DialogResult.No)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult msj = MetroMessageBox.Show(this,"¿Seguro de que desea cerrar la pestaña?", "SQL MANAGER 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
                cont = 0;
            }
            else if (msj == DialogResult.No)
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult msj = MetroMessageBox.Show(this,"¿Seguro de que desea cerrar la pestaña?", "SQL MANAGER 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
                cont = 0;
            }
            else if (msj == DialogResult.No)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult msj = MetroMessageBox.Show(this,"¿Seguro de que desea cerrar la pestaña?", "SQL MANAGER 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                tabContQuery.Controls.Remove(tabContQuery.SelectedTab);
                cont = 0;
            }
            else if (msj == DialogResult.No)
            { }
        }



        #endregion

        private void nuevoQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                this.txtQuery1.Lexer = Lexer.Sql;
                this.txtQuery1.Styles[ScintillaNET.Style.LineNumber].BackColor = Color.MediumSeaGreen;
                this.txtQuery1.Styles[ScintillaNET.Style.LineNumber].ForeColor = Color.White;
                this.txtQuery1.Margins[0].Width = 20;
                this.txtQuery1.Dock = DockStyle.None;
                this.txtQuery1.Styles[ScintillaNET.Style.Sql.Comment].ForeColor = Color.MediumSeaGreen;
                this.txtQuery1.Styles[ScintillaNET.Style.Sql.CommentLine].ForeColor = Color.MediumSeaGreen;
                this.txtQuery1.Styles[ScintillaNET.Style.Sql.String].ForeColor = Color.Red;
                this.txtQuery1.Styles[ScintillaNET.Style.Sql.Word].ForeColor = Color.Blue;
                this.txtQuery1.SetKeywords(0, "add alter go as asc authorization backup begin break browse bulk by cascade case check checkpoint close clustered column commit compute constraint containstable continue create current current_date cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if index insert intersect into key kill lineno load merge national nocheck nonclustered of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select semantickeyphrasetable semanticsimilaritydetailstable semanticsimilaritytable set setuser shutdown statistics table tablesample textsize then to top tran transaction trigger truncate union unique updatetext use user values varying view waitfor when where while with within group writetext all and any between cross exists in inner is join left like not null or outer pivot right some unpivot coalesce collate contains convert current_time current_timestamp current_user nullif session_user system_user try_convert tsequal update");         
                ShowTabPage(Tab1);
                Tab1.Show();
                cont = cont + 1;
            }
            else if (cont == 1)
            {
                this.txtQuery2.Lexer = Lexer.Sql;
                this.txtQuery2.Styles[ScintillaNET.Style.LineNumber].BackColor = Color.MediumSeaGreen;
                this.txtQuery2.Styles[ScintillaNET.Style.LineNumber].ForeColor = Color.White;
                this.txtQuery2.Margins[0].Width = 20;
                this.txtQuery2.Dock = DockStyle.None;
                this.txtQuery2.Styles[ScintillaNET.Style.Sql.Comment].ForeColor = Color.Green;
                this.txtQuery2.Styles[ScintillaNET.Style.Sql.CommentLine].ForeColor = Color.Green;
                this.txtQuery2.Styles[ScintillaNET.Style.Sql.String].ForeColor = Color.Red;         
                this.txtQuery2.Styles[ScintillaNET.Style.Sql.Word].ForeColor = Color.Blue;
                this.txtQuery2.SetKeywords(0, "add alter go as asc authorization backup begin break browse bulk by cascade case check checkpoint close clustered column commit compute constraint containstable continue create current current_date cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if index insert intersect into key kill lineno load merge national nocheck nonclustered of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select semantickeyphrasetable semanticsimilaritydetailstable semanticsimilaritytable set setuser shutdown statistics table tablesample textsize then to top tran transaction trigger truncate union unique updatetext use user values varying view waitfor when where while with within group writetext all and any between cross exists in inner is join left like not null or outer pivot right some unpivot coalesce collate contains convert current_time current_timestamp current_user nullif session_user system_user try_convert tsequal update");
                ShowTabPage(tab2);
                tab2.Show();
                cont = cont + 1;
            }
            else if (cont == 2)
            {
                this.txtQuery3.Lexer = Lexer.Sql;
                this.txtQuery3.Styles[ScintillaNET.Style.LineNumber].BackColor = Color.MediumSeaGreen;
                this.txtQuery3.Styles[ScintillaNET.Style.LineNumber].ForeColor = Color.White;
                this.txtQuery3.Margins[0].Width = 20;
                this.txtQuery3.Dock = DockStyle.None;
                this.txtQuery3.Styles[ScintillaNET.Style.Sql.Comment].ForeColor = Color.Green;
                this.txtQuery3.Styles[ScintillaNET.Style.Sql.CommentLine].ForeColor = Color.Green;
                this.txtQuery3.Styles[ScintillaNET.Style.Sql.String].ForeColor = Color.Red;
                this.txtQuery3.Styles[ScintillaNET.Style.Sql.Word].ForeColor = Color.Blue;
                this.txtQuery3.SetKeywords(0, "add alter go as asc authorization backup begin break browse bulk by cascade case check checkpoint close clustered column commit compute constraint containstable continue create current current_date cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if index insert intersect into key kill lineno load merge national nocheck nonclustered of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select semantickeyphrasetable semanticsimilaritydetailstable semanticsimilaritytable set setuser shutdown statistics table tablesample textsize then to top tran transaction trigger truncate union unique updatetext use user values varying view waitfor when where while with within group writetext all and any between cross exists in inner is join left like not null or outer pivot right some unpivot coalesce collate contains convert current_time current_timestamp current_user nullif session_user system_user try_convert tsequal update");
                ShowTabPage(tab3);
                tab3.Show();
                cont = cont + 1;
            }
            else if (cont == 3)
            {
                this.txtQuery4.Lexer = Lexer.Sql;
                this.txtQuery4.Styles[ScintillaNET.Style.LineNumber].BackColor = Color.MediumSeaGreen;
                this.txtQuery4.Styles[ScintillaNET.Style.LineNumber].ForeColor = Color.White;
                this.txtQuery4.Margins[0].Width = 20;
                this.txtQuery4.Dock = DockStyle.None;
                this.txtQuery4.Styles[ScintillaNET.Style.Sql.Comment].ForeColor = Color.Green;
                this.txtQuery4.Styles[ScintillaNET.Style.Sql.CommentLine].ForeColor = Color.Green;
                this.txtQuery4.Styles[ScintillaNET.Style.Sql.String].ForeColor = Color.Red;
                this.txtQuery4.Styles[ScintillaNET.Style.Sql.Word].ForeColor = Color.Blue;
                this.txtQuery4.SetKeywords(0, "add alter go as asc authorization backup begin break browse bulk by cascade case check checkpoint close clustered column commit compute constraint containstable continue create current current_date cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if index insert intersect into key kill lineno load merge national nocheck nonclustered of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select semantickeyphrasetable semanticsimilaritydetailstable semanticsimilaritytable set setuser shutdown statistics table tablesample textsize then to top tran transaction trigger truncate union unique updatetext use user values varying view waitfor when where while with within group writetext all and any between cross exists in inner is join left like not null or outer pivot right some unpivot coalesce collate contains convert current_time current_timestamp current_user nullif session_user system_user try_convert tsequal update");
                ShowTabPage(tab4);
                tab4.Show();
                cont = cont + 1;
            }
            else if (cont == 4)
            {
                this.txtQuery5.Lexer = Lexer.Sql;
                this.txtQuery5.Styles[ScintillaNET.Style.LineNumber].BackColor = Color.MediumSeaGreen;
                this.txtQuery5.Styles[ScintillaNET.Style.LineNumber].ForeColor = Color.White;
                this.txtQuery5.Margins[0].Width = 20;
                this.txtQuery5.Dock = DockStyle.None;
                this.txtQuery5.Styles[ScintillaNET.Style.Sql.Comment].ForeColor = Color.Green;
                this.txtQuery5.Styles[ScintillaNET.Style.Sql.CommentLine].ForeColor = Color.Green;
                this.txtQuery5.Styles[ScintillaNET.Style.Sql.String].ForeColor = Color.Red;
                this.txtQuery5.Styles[ScintillaNET.Style.Sql.Word].ForeColor = Color.Blue;
                this.txtQuery5.SetKeywords(0, "add alter go as asc authorization backup begin break browse bulk by cascade case check checkpoint close clustered column commit compute constraint containstable continue create current current_date cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if index insert intersect into key kill lineno load merge national nocheck nonclustered of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select semantickeyphrasetable semanticsimilaritydetailstable semanticsimilaritytable set setuser shutdown statistics table tablesample textsize then to top tran transaction trigger truncate union unique updatetext use user values varying view waitfor when where while with within group writetext all and any between cross exists in inner is join left like not null or outer pivot right some unpivot coalesce collate contains convert current_time current_timestamp current_user nullif session_user system_user try_convert tsequal update");
                ShowTabPage(tab5);
                tab5.Show();
                cont = cont + 1;
            }
            else
            {
                MetroMessageBox.Show(this,"Máximo de pestañas superado","SQL MANAGER 2017",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Variables
            DateTime tiempo1 = DateTime.Now;
            CapaLogica.clsBaseDatos Conect = new CapaLogica.clsBaseDatos();
            SqlConnection objConexion = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", instanceName, cboBD.Text));
            
          
            #endregion

            if (cboBD.SelectedItem != null)
            {
                if (tabContQuery.SelectedTab == Tab1)
                {
                    if (txtQuery1.SelectedText.Contains("Select") || txtQuery1.SelectedText.Contains("SELECT") || txtQuery1.SelectedText.Contains("select"))
                    {
                        if (new CapaLogica.clsIndices().EsquemaIndices(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString()))
                        {
                            dgvInfo.DataSource = Conect.Ejectar(txtQuery1.SelectedText, objConexion, instanceName);
                            btnCerrarGrid.Visible = true;
                            dgvInfo.Visible = true;
                            if (txtQuery1.SelectedText.Contains("Select") || txtQuery1.SelectedText.Contains("SELECT") || txtQuery1.SelectedText.Contains("select") && txtQuery1.SelectedText.Contains("["))
                            {
                                contSelect += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Insert") || txtQuery1.SelectedText.Contains("INSERT") || txtQuery1.SelectedText.Contains("insert") && txtQuery1.SelectedText.Contains("["))
                            {
                                contInsert += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Update") || txtQuery1.SelectedText.Contains("UPDATE") || txtQuery1.SelectedText.Contains("update") && txtQuery1.SelectedText.Contains("["))
                            {
                                contUpdate += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Delete") || txtQuery1.SelectedText.Contains("DELETE") || txtQuery1.SelectedText.Contains("delete") && txtQuery1.SelectedText.Contains("["))
                            {
                                contDelete += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                            {
                                contCreate += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                            {
                                contDrop += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                            {
                                contAlter += 1;
                            }

                        }
                        else
                        {
                            DialogResult msj = MetroMessageBox.Show(this,"SQL MANAGER 2017","No es posible ejecutar esta sentencia tipo select debido a que la tabla seleccionada: " +"'"+ lbTabla.SelectedValue +"'"+ " No contiene índices."+" Presione " + "'"+ "OK" +"'" + " si desea que el sistema le ayude a crear un nuevo indice", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                           
                            if (msj == DialogResult.OK)
                            {   
                                string result = frmIndices.ShowBox("Seleccione el tipo de indice que desea", "Asistente de creación de índices");
                                string text1 = " ";
                                string result1 = " ";

                                foreach (DataRowView item in lbColumnas.Items)
                                {
                                    DataRow var = item.Row;
                                    text1 += var[3].ToString() + ", ";
                                }

                                result1 = text1.TrimEnd(',', ' ');
                                if (result.Equals("1"))
                                {
                                    txtQuery1.Text = "CREATE CLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON "+ lbTabla.Text + "" + "("+result1+")";      
                                    //this.WindowState = FormWindowState.Normal;
                                }

                                if (result.Equals("2"))
                                {
                                    txtQuery1.Text = "CREATE NONCLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";                                  
                                    //this.WindowState = FormWindowState.Normal;
                                }
                            }
                         
                        }
                    }
                    else
                    {
                        dgvInfo.DataSource = Conect.Ejectar(txtQuery1.SelectedText, objConexion, instanceName);
                        btnCerrarGrid.Visible = true;
                        dgvInfo.Visible = true;
                        if (txtQuery1.SelectedText.Contains("Select") || txtQuery1.SelectedText.Contains("SELECT") || txtQuery1.SelectedText.Contains("select") && txtQuery1.SelectedText.Contains("["))
                        {
                            contSelect += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Insert") || txtQuery1.SelectedText.Contains("INSERT") || txtQuery1.SelectedText.Contains("insert") && txtQuery1.SelectedText.Contains("["))
                        {
                            contInsert += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Update") || txtQuery1.SelectedText.Contains("UPDATE") || txtQuery1.SelectedText.Contains("update") && txtQuery1.SelectedText.Contains("["))
                        {
                            contUpdate += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Delete") || txtQuery1.SelectedText.Contains("DELETE") || txtQuery1.SelectedText.Contains("delete") && txtQuery1.SelectedText.Contains("["))
                        {
                            contDelete += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                        {
                            contCreate += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                        {
                            contDrop += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                        {
                            contAlter += 1;
                        }
                    }
                }
                else if (tabContQuery.SelectedTab == tab2)
                {
                    if (txtQuery2.SelectedText.Contains("Select") || txtQuery2.SelectedText.Contains("SELECT") || txtQuery2.SelectedText.Contains("select"))
                    {
                        if (new CapaLogica.clsIndices().EsquemaIndices(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString()))
                        {
                            dgvInfo.DataSource = Conect.Ejectar(txtQuery2.SelectedText, objConexion, instanceName);
                            btnCerrarGrid.Visible = true;
                            dgvInfo.Visible = true;
                            if (txtQuery2.SelectedText.Contains("Select") || txtQuery2.SelectedText.Contains("SELECT") || txtQuery2.SelectedText.Contains("select") && txtQuery2.SelectedText.Contains("["))
                            {
                                contSelect += 1;
                            }
                            if (txtQuery2.SelectedText.Contains("Insert") || txtQuery2.SelectedText.Contains("INSERT") || txtQuery2.SelectedText.Contains("insert") && txtQuery2.SelectedText.Contains("["))
                            {
                                contInsert += 1;
                            }
                            if (txtQuery2.SelectedText.Contains("Update") || txtQuery2.SelectedText.Contains("UPDATE") || txtQuery2.SelectedText.Contains("update") && txtQuery2.SelectedText.Contains("["))
                            {
                                contUpdate += 1;
                            }
                            if (txtQuery2.SelectedText.Contains("Delete") || txtQuery2.SelectedText.Contains("DELETE") || txtQuery2.SelectedText.Contains("delete") && txtQuery2.SelectedText.Contains("["))
                            {
                                contDelete += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                            {
                                contCreate += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                            {
                                contDrop += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                            {
                                contAlter += 1;
                            }
                        }
                        else
                        {
                            DialogResult msj = MetroMessageBox.Show(this, "No es posible ejecutar esta sentencia tipo select debido a que la tabla seleccionada: " + "'" + lbTabla.SelectedValue + "'" + " No contiene índices." + " Presione " + "'" + "OK" + "'" + " si desea que el sistema le ayude a crear un nuevo indice", "SQL MANAGER 2017", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                            if (msj == DialogResult.OK)
                            {
                                string result = frmIndices.ShowBox("Seleccione el tipo de indice que desea", "Asistente de creación de índices");
                                string text1 = " ";
                                string result1 = " ";

                                foreach (DataRowView item in lbColumnas.Items)
                                {
                                    DataRow var = item.Row;
                                    text1 += var[3].ToString() + ", ";
                                }

                                result1 = text1.TrimEnd(',', ' ');
                                if (result.Equals("1"))
                                {
                                    txtQuery2.Text = "CREATE CLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";
                                }

                                if (result.Equals("2"))
                                {
                                    txtQuery2.Text = "CREATE NONCLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";
                                }
                            }
                        }
                    }
                    else
                    {
                        dgvInfo.DataSource = Conect.Ejectar(txtQuery2.SelectedText, objConexion, instanceName);
                        btnCerrarGrid.Visible = true;
                        dgvInfo.Visible = true;
                        if (txtQuery2.SelectedText.Contains("Select") || txtQuery2.SelectedText.Contains("SELECT") || txtQuery2.SelectedText.Contains("select") && txtQuery2.SelectedText.Contains("["))
                        {
                            contSelect += 1;
                        }    
                        if (txtQuery2.SelectedText.Contains("Insert") || txtQuery2.SelectedText.Contains("INSERT") || txtQuery2.SelectedText.Contains("insert") && txtQuery2.SelectedText.Contains("["))
                        {
                            contInsert += 1;
                        }
                        if (txtQuery2.SelectedText.Contains("Update") || txtQuery2.SelectedText.Contains("UPDATE") || txtQuery2.SelectedText.Contains("update") && txtQuery2.SelectedText.Contains("["))
                        {
                            contUpdate += 1;
                        }
                        if (txtQuery2.SelectedText.Contains("Delete") || txtQuery2.SelectedText.Contains("DELETE") || txtQuery2.SelectedText.Contains("delete") && txtQuery2.SelectedText.Contains("["))
                        {
                            contDelete += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                        {
                            contCreate += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                        {
                            contDrop += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                        {
                            contAlter += 1;
                        }
                    }
                }
                else if (tabContQuery.SelectedTab == tab3)
                {
                    if (txtQuery3.SelectedText.Contains("Select") || txtQuery3.SelectedText.Contains("SELECT") || txtQuery3.SelectedText.Contains("select"))
                    {
                        if (new CapaLogica.clsIndices().EsquemaIndices(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString()))
                        {
                              dgvInfo.DataSource = Conect.Ejectar(txtQuery3.SelectedText, objConexion, instanceName);
                              btnCerrarGrid.Visible = true;
                              dgvInfo.Visible = true;
                            if (txtQuery3.SelectedText.Contains("Select") || txtQuery3.SelectedText.Contains("SELECT") || txtQuery3.SelectedText.Contains("select") && txtQuery3.SelectedText.Contains("["))
                            {
                                contSelect += 1;
                            }
                            if (txtQuery3.SelectedText.Contains("Insert") || txtQuery3.SelectedText.Contains("INSERT") || txtQuery3.SelectedText.Contains("insert") && txtQuery3.SelectedText.Contains("["))
                            {
                                contInsert += 1;
                            }
                            if (txtQuery3.SelectedText.Contains("Update") || txtQuery3.SelectedText.Contains("UPDATE") || txtQuery3.SelectedText.Contains("update") && txtQuery3.SelectedText.Contains("["))
                            {
                                contUpdate += 1;
                            }
                            if (txtQuery3.SelectedText.Contains("Delete") || txtQuery3.SelectedText.Contains("DELETE") || txtQuery3.SelectedText.Contains("delete") && txtQuery3.SelectedText.Contains("["))
                            {
                                contDelete += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                            {
                                contCreate += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                            {
                                contDrop += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                            {
                                contAlter += 1;
                            }

                        }
                        else
                        {
                            DialogResult msj = MetroMessageBox.Show(this, "No es posible ejecutar esta sentencia tipo select debido a que la tabla seleccionada: " + "'" + lbTabla.SelectedValue + "'" + " No contiene índices." + " Presione " + "'" + "OK" + "'" + " si desea que el sistema le ayude a crear un nuevo indice", "SQL MANAGER 2017", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                            if (msj == DialogResult.OK)
                            {
                                string result = frmIndices.ShowBox("Seleccione el tipo de indice que desea", "Asistente de creación de índices");
                                string text1 = " ";
                                string result1 = " ";

                                foreach (DataRowView item in lbColumnas.Items)
                                {
                                    DataRow var = item.Row;
                                    text1 += var[3].ToString() + ", ";
                                }

                                result1 = text1.TrimEnd(',', ' ');
                                if (result.Equals("1"))
                                {
                                    txtQuery3.Text = "CREATE CLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";
                                }

                                if (result.Equals("2"))
                                {
                                    txtQuery3.Text = "CREATE NONCLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";
                                }
                            }
                        }
                    }
                    else
                    {
                        dgvInfo.DataSource = Conect.Ejectar(txtQuery3.SelectedText, objConexion, instanceName);
                        btnCerrarGrid.Visible = true;
                        dgvInfo.Visible = true;
                        if (txtQuery3.SelectedText.Contains("Select") || txtQuery3.SelectedText.Contains("SELECT") || txtQuery3.SelectedText.Contains("select") && txtQuery3.SelectedText.Contains("["))
                        {
                            contSelect += 1;
                        }
                        if (txtQuery3.SelectedText.Contains("Insert") || txtQuery3.SelectedText.Contains("INSERT") || txtQuery3.SelectedText.Contains("insert") && txtQuery3.SelectedText.Contains("["))
                        {
                            contInsert += 1;
                        }
                        if (txtQuery3.SelectedText.Contains("Update") || txtQuery3.SelectedText.Contains("UPDATE") || txtQuery3.SelectedText.Contains("update") && txtQuery3.SelectedText.Contains("["))
                        {
                            contUpdate += 1;
                        }
                        if (txtQuery3.SelectedText.Contains("Delete") || txtQuery3.SelectedText.Contains("DELETE") || txtQuery3.SelectedText.Contains("delete") && txtQuery3.SelectedText.Contains("["))
                        {
                            contDelete += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                        {
                            contCreate += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                        {
                            contDrop += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                        {
                            contAlter += 1;
                        }
                    }
                }
                else if (tabContQuery.SelectedTab == tab4)
                {
                    if (txtQuery4.SelectedText.Contains("Select") || txtQuery4.SelectedText.Contains("SELECT") || txtQuery4.SelectedText.Contains("select"))
                    {
                        if (new CapaLogica.clsIndices().EsquemaIndices(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString()))
                        {
                            dgvInfo.DataSource = Conect.Ejectar(txtQuery4.SelectedText, objConexion, instanceName);
                            btnCerrarGrid.Visible = true;
                            dgvInfo.Visible = true;

                            if (txtQuery4.SelectedText.Contains("Select") || txtQuery4.SelectedText.Contains("SELECT") || txtQuery4.SelectedText.Contains("select") && txtQuery4.SelectedText.Contains("["))
                            {
                                contSelect += 1;
                            }
                            if (txtQuery4.SelectedText.Contains("Insert") || txtQuery4.SelectedText.Contains("INSERT") || txtQuery4.SelectedText.Contains("insert") && txtQuery4.SelectedText.Contains("["))
                            {
                                contInsert += 1;
                            }
                            if (txtQuery4.SelectedText.Contains("Update") || txtQuery4.SelectedText.Contains("UPDATE") || txtQuery4.SelectedText.Contains("update") && txtQuery4.SelectedText.Contains("["))
                            {
                                contUpdate += 1;
                            }
                            if (txtQuery4.SelectedText.Contains("Delete") || txtQuery4.SelectedText.Contains("DELETE") || txtQuery4.SelectedText.Contains("delete") && txtQuery4.SelectedText.Contains("["))
                            {
                                contDelete += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                            {
                                contCreate += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                            {
                                contDrop += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                            {
                                contAlter += 1;
                            }

                        }
                        else
                        {
                            DialogResult msj = MetroMessageBox.Show(this, "No es posible ejecutar esta sentencia tipo select debido a que la tabla seleccionada: " + "'" + lbTabla.SelectedValue + "'" + " No contiene índices." + " Presione " + "'" + "OK" + "'" + " si desea que el sistema le ayude a crear un nuevo indice", "SQL MANAGER 2017", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                            if (msj == DialogResult.OK)
                            {
                                string result = frmIndices.ShowBox("Seleccione el tipo de indice que desea", "Asistente de creación de índices");
                                string text1 = " ";
                                string result1 = " ";

                                foreach (DataRowView item in lbColumnas.Items)
                                {
                                    DataRow var = item.Row;
                                    text1 += var[3].ToString() + ", ";
                                }

                                result1 = text1.TrimEnd(',', ' ');
                                if (result.Equals("1"))
                                {
                                    txtQuery4.Text = "CREATE CLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";
                                }

                                if (result.Equals("2"))
                                {
                                    txtQuery4.Text = "CREATE NONCLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";
                                }
                            }
                        }
                    }
                    else
                    {
                        dgvInfo.DataSource = Conect.Ejectar(txtQuery4.SelectedText, objConexion, instanceName);
                        btnCerrarGrid.Visible = true;
                        dgvInfo.Visible = true;
                        if (txtQuery4.SelectedText.Contains("Select") || txtQuery4.SelectedText.Contains("SELECT") || txtQuery4.SelectedText.Contains("select") && txtQuery4.SelectedText.Contains("["))
                        {
                            contSelect += 1;
                        }
                        if (txtQuery4.SelectedText.Contains("Insert") || txtQuery4.SelectedText.Contains("INSERT") || txtQuery4.SelectedText.Contains("insert") && txtQuery4.SelectedText.Contains("["))
                        {
                            contInsert += 1;
                        }
                        if (txtQuery4.SelectedText.Contains("Update") || txtQuery4.SelectedText.Contains("UPDATE") || txtQuery4.SelectedText.Contains("update") && txtQuery4.SelectedText.Contains("["))
                        {
                            contUpdate += 1;
                        }
                        if (txtQuery4.SelectedText.Contains("Delete") || txtQuery4.SelectedText.Contains("DELETE") || txtQuery4.SelectedText.Contains("delete") && txtQuery4.SelectedText.Contains("["))
                        {
                            contDelete += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                        {
                            contCreate += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                        {
                            contDrop += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                        {
                            contAlter += 1;
                        }
                    }
                }
                else if (tabContQuery.SelectedTab == tab5)
                {
                    if (txtQuery5.SelectedText.Contains("Select") || txtQuery5.SelectedText.Contains("SELECT") || txtQuery5.SelectedText.Contains("select"))
                    {
                        if (new CapaLogica.clsIndices().EsquemaIndices(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString()))
                        {
                            dgvInfo.DataSource = Conect.Ejectar(txtQuery5.SelectedText, objConexion, instanceName);
                            btnCerrarGrid.Visible = true;
                            dgvInfo.Visible = true;
                            if (txtQuery5.SelectedText.Contains("Select") || txtQuery5.SelectedText.Contains("SELECT") || txtQuery5.SelectedText.Contains("select") && txtQuery5.SelectedText.Contains("["))
                            {
                                contSelect += 1;
                            }
                            if (txtQuery5.SelectedText.Contains("Insert") || txtQuery5.SelectedText.Contains("INSERT") || txtQuery5.SelectedText.Contains("insert") && txtQuery5.SelectedText.Contains("["))
                            {
                                contInsert += 1;
                            }
                            if (txtQuery5.SelectedText.Contains("Update") || txtQuery5.SelectedText.Contains("UPDATE") || txtQuery5.SelectedText.Contains("update") && txtQuery5.SelectedText.Contains("["))
                            {
                                contUpdate += 1;
                            }
                            if (txtQuery5.SelectedText.Contains("Delete") || txtQuery5.SelectedText.Contains("DELETE") || txtQuery5.SelectedText.Contains("delete") && txtQuery5.SelectedText.Contains("["))
                            {
                                contDelete += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                            {
                                contCreate += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                            {
                                contDrop += 1;
                            }
                            if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                            {
                                contAlter += 1;
                            }

                        }
                        else
                        {
                            DialogResult msj = MetroMessageBox.Show(this, "No es posible ejecutar esta sentencia tipo select debido a que la tabla seleccionada: " + "'" + lbTabla.SelectedValue + "'" + " No contiene índices." + " Presione " + "'" + "OK" + "'" + " si desea que el sistema le ayude a crear un nuevo indice", "SQL MANAGER 2017", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                            if (msj == DialogResult.OK)
                            {
                                string result = frmIndices.ShowBox("Seleccione el tipo de indice que desea", "Asistente de creación de índices");
                                string text1 = " ";
                                string result1 = " ";

                                foreach (DataRowView item in lbColumnas.Items)
                                {
                                    DataRow var = item.Row;
                                    text1 += var[3].ToString() + ", ";
                                }

                                result1 = text1.TrimEnd(',', ' ');
                                if (result.Equals("1"))
                                {
                                    txtQuery5.Text = "CREATE CLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "("+ result1 +")";
                                }

                                if (result.Equals("2"))
                                {
                                    txtQuery5.Text = "CREATE NONCLUSTERED INDEX index_name" + Environment.NewLine +
                                                      "ON " + lbTabla.Text + "" + "(" + result1 + ")";
                                }
                            }
                        }
                    }
                    else
                    {
                        dgvInfo.DataSource = Conect.Ejectar(txtQuery5.SelectedText, objConexion, instanceName);
                        btnCerrarGrid.Visible = true;
                        dgvInfo.Visible = true;
                        if (txtQuery5.SelectedText.Contains("Select") || txtQuery5.SelectedText.Contains("SELECT") || txtQuery5.SelectedText.Contains("select") && txtQuery5.SelectedText.Contains("["))
                        {
                            contSelect += 1;
                        }
                        if (txtQuery5.SelectedText.Contains("Insert") || txtQuery5.SelectedText.Contains("INSERT") || txtQuery5.SelectedText.Contains("insert") && txtQuery5.SelectedText.Contains("["))
                        {
                            contInsert += 1;
                        }
                        if (txtQuery5.SelectedText.Contains("Update") || txtQuery5.SelectedText.Contains("UPDATE") || txtQuery5.SelectedText.Contains("update") && txtQuery5.SelectedText.Contains("["))
                        {
                            contUpdate += 1;
                        }
                        if (txtQuery5.SelectedText.Contains("Delete") || txtQuery5.SelectedText.Contains("DELETE") || txtQuery5.SelectedText.Contains("delete") && txtQuery5.SelectedText.Contains("["))
                        {
                            contDelete += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Create") || txtQuery1.SelectedText.Contains("CREATE") || txtQuery1.SelectedText.Contains("create") && txtQuery1.SelectedText.Contains("["))
                        {
                            contCreate += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Drop") || txtQuery1.SelectedText.Contains("DROP") || txtQuery1.SelectedText.Contains("drop") && txtQuery1.SelectedText.Contains("["))
                        {
                            contDrop += 1;
                        }
                        if (txtQuery1.SelectedText.Contains("Alter") || txtQuery1.SelectedText.Contains("ALTER") || txtQuery1.SelectedText.Contains("alter") && txtQuery1.SelectedText.Contains("["))
                        {
                            contAlter += 1;
                        }
                    }
                }
                DateTime tiempo2 = DateTime.Now;
                TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
                lbConsulta.Text = "Tiempo de consulta: " + total.ToString();
            }

            else
            {
                MetroMessageBox.Show(this, "No ha cargado ninguna base de datos", "SQL MANAGER 2017", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private void lbTabla_DoubleClick(object sender, EventArgs e)
        {
            if (cboBD.SelectedItem != null && lbTabla.SelectedValue != null)
            {
                DataTable objDT = new CapaLogica.clsColumnas().getColumns(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString());

                if (objDT is null)
                {
                    MetroMessageBox.Show(this,"Error al cargar las columnas", "SQL MANAGER 2017", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }
                if (lbTabla.Enabled)
                {
                    if (objDT.Rows.Count > 0)
                    {
                        lbColumnas.Text = "Columnas:";
                        lbColumnas.ClearSelected();
                        lbColumnas.Enabled = true;
                        lbColumnas.DisplayMember = "COLUMN_NAME";
                        lbColumnas.ValueMember = "COLUMN_NAME";
                        lbColumnas.DataSource = objDT;

                        //DataTable Dt = new CapaLogica.clsTablas().Registro(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString());
                        //dgvInfo.DataSource = Dt;
                    }
                    else
                    {
                        lbTabla.DataSource = objDT;
                        lbColumnas.Enabled = false;
                        lbColumnas.DataSource = null;
                    }
                }
                else
                {
                    MetroMessageBox.Show(this,"Seleccione una base de datos", "SQL MANAGER 2017", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cboBD.SelectedItem != null && lbTabla.SelectedValue != null)
            {
                DataTable objDT = new CapaLogica.clsColumnas().getColumns(lbTabla.SelectedValue.ToString(), instanceName, cboBD.SelectedValue.ToString());

                if (objDT is null)
                {
                    MetroMessageBox.Show(this,"Error al cargar las columnas", "SQL MANAGER 2017", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }
                if (lbTabla.Enabled)
                {
                    if (objDT.Rows.Count > 0)
                    {
                        lbColumnas.ClearSelected();
                        lbColumnas.Enabled = true;
                        lbColumnas.DisplayMember = "COLUMN_NAME";
                        lbColumnas.ValueMember = "COLUMN_NAME";
                        lbColumnas.DataSource = objDT;
                    }
                    else
                    {
                        lbTabla.DataSource = objDT;
                        lbColumnas.Enabled = false;
                        lbColumnas.DataSource = null;
                    }

                }
            }
            else
            {
                MetroMessageBox.Show(this,"Seleccione una base de datos", "SQL MANAGER 2017", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            cboBD.DataSource = new CapaLogica.clsBaseDatos().BaseDatos(instanceName);
            cboBD.ValueMember = "DATABASE_NAME";
            cboBD.DisplayMember = "DATABASE_NAME";
        }

        private void cboBD_DropDown(object sender, EventArgs e)
        {
            cboBD.DataSource = new CapaLogica.clsBaseDatos().BaseDatos(instanceName);
            cboBD.ValueMember = "DATABASE_NAME";
            cboBD.DisplayMember = "DATABASE_NAME";
        }

        private void sELECTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string text = " ";
            string result = " ";

            foreach (DataRowView item in lbColumnas.Items)
            {
                DataRow var = item.Row;
                text += var[3].ToString() + ", ";
            }

            result = text.TrimEnd(',', ' ');

            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "use" + "[" + cboBD.Text + "]" + Environment.NewLine +
                "SELECT " + result + Environment.NewLine +
                "FROM " + "[" + lbTabla.Text + "]";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "use" + "[" + cboBD.Text + "]" + Environment.NewLine +
                "SELECT " + result + Environment.NewLine +
                 "FROM " + "[" + lbTabla.Text + "]";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "use" + "[" + cboBD.Text + "]" + Environment.NewLine +
                "SELECT " + result + Environment.NewLine +
                "FROM " + "[" + lbTabla.Text + "]";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "use" + "[" + cboBD.Text + "]" + Environment.NewLine +
                "SELECT " + result + Environment.NewLine +
                "FROM " + "[" + lbTabla.Text + "]";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "use" + "[" + cboBD.Text + "]" + Environment.NewLine +
                "SELECT " + result + Environment.NewLine +
                "FROM " + "[" + lbTabla.Text + "]";
            }
        }

        private void iNSERTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string text = " ";
            string result = " ";

            foreach (DataRowView item in lbColumnas.Items)
            {
                DataRow var = item.Row;
                text += var[3].ToString() + ", ";
            }

            result = text.TrimEnd(',', ' ');

            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                 "Insert Into [dbo].[" + lbTabla.Text + "] " + "(" + result + ") " + Environment.NewLine +
                 "Values " + Environment.NewLine + "() ";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                "Insert Into [dbo].[" + lbTabla.Text + "] " + "(" + result + ") " + Environment.NewLine +
                "Values " + Environment.NewLine + "() ";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                  "Insert Into [dbo].[" + lbTabla.Text + "] " + "(" + result + ") " + Environment.NewLine +
                 "Values " + Environment.NewLine + "() ";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                "Insert Into [dbo].[" + lbTabla.Text + "] " + "(" + result + ") " + Environment.NewLine +
                "Values " + Environment.NewLine + "() ";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                "Insert Into [dbo].[" + lbTabla.Text + "] " + "(" + result + ") " + Environment.NewLine +
                "Values " + Environment.NewLine + "() ";
            }
        }

        private void uPDATEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string text = " ";
            string result = " ";

            foreach (DataRowView item in lbColumnas.Items)
            {
                DataRow var = item.Row;
                text += var[3].ToString() + ", ";
            }

            result = text.TrimEnd(',', ' ');
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                   "Update [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Set "  + result  + " = " + Environment.NewLine +
                  "Where " + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                  "Update [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Set "  + result + " = " + Environment.NewLine +
                  "Where " + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                 "Update [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Set " + result + " = " + Environment.NewLine +
                  "Where " + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                  "Update [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Set " + result + " = " + Environment.NewLine +
                  "Where " + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                  "Update [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Set " + result + " = " + Environment.NewLine +
                  "Where " + Environment.NewLine;
            }
        }

        private void dELETEToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                   "Delete From [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Where <ingrese condiciones>" + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                   "Delete From [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Where <ingrese condiciones>" + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                   "Delete From [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Where <ingrese condiciones>" + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                   "Delete From [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Where <ingrese condiciones>" + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "use " + "[" + cboBD.Text + "]" + Environment.NewLine +
                   "Delete From [dbo].[" + lbTabla.Text + "] " + Environment.NewLine +
                  "Where <ingrese condiciones>" + Environment.NewLine;
            }
        }

        private void dATABASEToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "CREATE DATABASE [databasename]";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "CREATE DATABASE [databasename]";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "CREATE DATABASE [databasename]";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "CREATE DATABASE [databasename]";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "CREATE DATABASE [databasename]";
            }
        }

        private void tABLEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "CREATE TABLE [table_name]" + "(" + Environment.NewLine +
                "column1 datatype," + Environment.NewLine +
                "column2 datatype," + Environment.NewLine +
                "column3 datatype" + Environment.NewLine +
                 "...." + Environment.NewLine +
                ")" + Environment.NewLine;

            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "CREATE TABLE [table_name]" + "(" + Environment.NewLine +
                "column1 datatype," + Environment.NewLine +
                "column2 datatype," + Environment.NewLine +
                "column3 datatype" + Environment.NewLine +
                 "...." + Environment.NewLine +
                ")" + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "CREATE TABLE [table_name]" + "(" + Environment.NewLine +
                "column1 datatype," + Environment.NewLine +
                "column2 datatype," + Environment.NewLine +
                "column3 datatype" + Environment.NewLine +
                 "...." + Environment.NewLine +
                ")" + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "CREATE TABLE [table_name]" + "(" + Environment.NewLine +
                "column1 datatype," + Environment.NewLine +
                "column2 datatype," + Environment.NewLine +
                "column3 datatype" + Environment.NewLine +
                 "...." + Environment.NewLine +
                ")" + Environment.NewLine;
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "CREATE TABLE [table_name]" + "(" + Environment.NewLine +
                "column1 datatype," + Environment.NewLine +
                "column2 datatype," + Environment.NewLine +
                "column3 datatype" + Environment.NewLine +
                 "...." + Environment.NewLine +
                ")" + Environment.NewLine;
            }
        }

        private void dATABASEToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "Drop Database " + "["+"databasename"+"]";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "Drop Database " + "[" + "databasename" + "]";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "Drop Database " + "[" + "databasename" + "]";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "Drop Database " + "[" + "databasename" + "]";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "Drop Database " + "[" + "databasename" + "]";
            }
        }

        private void tABLEToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "Drop Table " + "[table_name]";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "Drop Table " + "[table_name]";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "Drop Table " + "[table_name]";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "Drop Table " + "[table_name]";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "Drop Table " + "[table_name]";
            }
        }

        private void dATABASEToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "Modify Name = " + cboBD.Text;
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "Modify Name = " + cboBD.Text;
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "Modify Name = " + cboBD.Text;
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "Modify Name = " + cboBD.Text;
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "Modify Name = " + cboBD.Text;
            }
        }

        private void aDDCOLUMNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "Alter Table " + "["+lbTabla.Text +"]"+ Environment.NewLine +
                "Add [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "Alter Table " + "["+lbTabla.Text +"]"+ Environment.NewLine +
                "Add [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "Alter Table " + "["+lbTabla.Text + "]"+Environment.NewLine +
                "Add [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "Alter Table " + "["+lbTabla.Text +"]"+ Environment.NewLine +
                "Add [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "Alter Table " + "["+lbTabla.Text +"]" +Environment.NewLine +
                "Add [column_name] datatype;";
            }
        }

        private void dROPCOLUMNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Drop Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Drop Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Drop Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Drop Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Drop Column [column_name] datatype;";
            }
        }

        private void aLTERCOLUMNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabContQuery.SelectedTab == Tab1)
            {
                txtQuery1.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Alter Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab2)
            {
                txtQuery2.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Alter Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab3)
            {
                txtQuery3.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Alter Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab4)
            {
                txtQuery4.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Alter Column [column_name] datatype;";
            }
            else if (tabContQuery.SelectedTab == tab5)
            {
                txtQuery5.Text = "Alter Table " + "[" + lbTabla.Text + "]" + Environment.NewLine +
                "Alter Column [column_name] datatype;";
            }
        }

        private void plantillasUtilizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String result = "";

            List<String> oList = new List<string>();
            oList.Add(contSelect + "--> Plantilla Select");
            oList.Add(contInsert + "--> Plantilla Insert");
            oList.Add(contDelete + "--> Plantilla Delete");
            oList.Add(contUpdate + "--> Plantilla Update");
            oList.Add(contCreate + "--> Plantilla Create");
            oList.Add(contDrop + "--> Plantilla Drop");
            oList.Add(contAlter + "--> Plantilla Alter");
            oList.Sort();
            for (int i = oList.Count - 1; i >= 0; i--)
            {
                result += oList[i] + "\n";
            }
            //MetroMessageBox.Show(this,"Plantilla Select: " + contSelect +Environment.NewLine+"Plantilla Insert: "+contInsert + Environment.NewLine + "Plantilla Update: " + contUpdate + Environment.NewLine + "Plantilla Delete: " + contDelete, "SQL MANAGER",MessageBoxButtons.OK, MessageBoxIcon.Information);
            MetroMessageBox.Show(this, result, "SQL MANAGER REPORTES", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void indicesGeneradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cantIndix = 0;
            CapaLogica.clsIndices TotalIn = new CapaLogica.clsIndices();
            DataTable dtIndices;
            dtIndices = TotalIn.TotalIndices(instanceName, cboBD.Text);
            dgvInfo.DataSource = dtIndices;
            cantIndix = dtIndices.Rows.Count;
            MetroMessageBox.Show(this,"El total de indices generados hasta el momento es de: "+ cantIndix,"SQL MANAGER REPORTES",MessageBoxButtons.OK,MessageBoxIcon.Information);
            dgvInfo.Visible = true;
            btnCerrarGrid.Visible = true;
        }

        private void btnCerrarGrid_Click(object sender, EventArgs e)
        {
            if (dgvInfo.Visible == true){
                dgvInfo.Visible = false;
                btnCerrarGrid.Visible = false;
            }
        }
        string RtablaIndex = "";
        private void buscarLosIndicesDeUnaTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RtablaIndex = Microsoft.VisualBasic.Interaction.InputBox(
              "Ingrese el nombre de la tabla a la cual desea consultar los índices",
              "Índices por tabla",
              "");
            CapaLogica.clsIndices TotalIn = new CapaLogica.clsIndices();
            DataTable dtIndices;
            dtIndices = TotalIn.TotalIndicesPorTB(RtablaIndex, instanceName, cboBD.Text);
            dgvInfo.DataSource = dtIndices;
            dgvInfo.Visible = true;
            btnCerrarGrid.Visible = true;
        }  
    }
}


