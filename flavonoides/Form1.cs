using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace flavonoides
{
    public partial class Form1 : Form
    {
        System.Data.DataTable dtgrup;
        DataTable dtr24h;
        System.Data.DataTable dtfla;
        System.Data.DataTable dtlinks;
        string filter="";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MySql.Data.MySqlClient.MySqlConnection msc = new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.conexion.ToString());
            MySql.Data.MySqlClient.MySqlDataAdapter mdar24h = new MySql.Data.MySqlClient.MySqlDataAdapter("select visited,OCCUSEQ,ENGNAM,FACETDESC,COUNTRY,FREQ,FATATTACHED,LENGNAM,CTYNAM,LCTYNAM,DESC1,DESC2,DESC3,DESC4,DESC5,DESC6,DESC7,FDCLASS,GRPNAME,FDCODE,FDCODE2,FLAG,ID,ENGNAM_sc from r24h", msc);
            dtr24h = new DataTable();
            mdar24h.Fill(dtr24h);            
            DAO d = new DAO();
            /*dtr24h = d.pasar_consulta_datatable("select visited,ENGNAM,FACETDESC,COUNTRY,FREQ,FATATTACHED,LENGNAM,CTYNAM,LCTYNAM,OCCUSEQ,DESC1,DESC2,DESC3,DESC4,FDCLASS,GRPNAME,FDCODE,FDCODE2,FLAG,ID,ENGNAM_sc from r24h");*/
            dgvr24h.DataSource = dtr24h;
            MySql.Data.MySqlClient.MySqlDataAdapter mdagrup = new MySql.Data.MySqlClient.MySqlDataAdapter("select distinct GRPNAME from r24h", msc);
            dtgrup = new DataTable();
            mdagrup.Fill(dtgrup);
            int i = 0;
            while (i < dtgrup.Rows.Count)
            {
                cbgrup.Items.Add(dtgrup.Rows[i][0]);
                

                i++;
            }
           

            MySql.Data.MySqlClient.MySqlDataAdapter mdafla = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from foods_phenol_explorer", msc);
            dtfla = new DataTable();
            mdafla.Fill(dtfla);
            dgvfla.DataSource = dtfla;

            

            MySql.Data.MySqlClient.MySqlDataAdapter mdagrupfla = new MySql.Data.MySqlClient.MySqlDataAdapter("select distinct food_group from foods_phenol_explorer", msc);
            System.Data.DataTable dtgfla = new DataTable();
            mdagrupfla.Fill(dtgfla);
            i = 0;
            while (i < dtgfla.Rows.Count)
            {
                cbgrupfla.Items.Add(dtgfla.Rows[i][0]);

                i++;
            }
            msc.Close();
            string sid = dgvr24h.SelectedRows[0].Cells["ID"].Value.ToString();
            System.Data.DataTable dttemp = Links.encontrar_links(sid);
            dtlinks = dttemp;
            dgvlink.DataSource = dtlinks;
            
            System.Data.DataTable dtcook_met = d.pasar_consulta_datatable("select method from cook_method");
            int k = 0;
            while (k < dtcook_met.Rows.Count)
            {
                cbcook_met.Items.Add(dtcook_met.Rows[k][0]);

                k++;
            }
            
            System.Data.DataTable dtestimation = d.pasar_consulta_datatable("select estimation from estimation");
            k = 0;
            string sest = "estimation codes:";
            while (k < dtestimation.Rows.Count)
            {
                sest = sest + "   " + dtestimation.Rows[k]["estimation"];
                k++;
            }
            lestimation.Text = sest;
            lnumber.Text = "number of lines:" + dgvr24h.RowCount.ToString();
            k = 0;
            while (k < dtr24h.Columns.Count)
            {
                cbname.Items.Add(dtr24h.Columns[k].ColumnName);
                k++;
            }

            
        }

        private void cbgrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbgrup.SelectedIndex > -1)
            {
                string slselectgroup = cbgrup.SelectedItem.ToString();
                DAO d = new DAO();
                MySql.Data.MySqlClient.MySqlConnection msc = new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.conexion.ToString());
                /*DataTable dtcodigroup = d.pasar_consulta_datatable("select distinct FDCLASS from r24h where GRPNAME='"+slselectgroup+"'");
                string sselectgroup = dtcodigroup.Rows[0][0].ToString();*/
                MySql.Data.MySqlClient.MySqlDataAdapter mdaaliment = new MySql.Data.MySqlClient.MySqlDataAdapter("select distinct ENGNAM_sc from r24h where GRPNAME='" + slselectgroup + "'", msc);
                System.Data.DataTable dtaliment = new DataTable();
                mdaaliment.Fill(dtaliment);
                cbaliment.Items.Clear();
                int i = 0;
                while (i < dtaliment.Rows.Count)
                {
                    cbaliment.Items.Add(dtaliment.Rows[i][0].ToString());

                    i++;
                }

                msc.Close();
                filter = "GRPNAME='" + slselectgroup + "'";
                System.Data.DataRow[] dtrsfiltre = dtr24h.Select(filter);
                System.Data.DataTable temp = dtr24h.Clone();

                foreach (DataRow dr in dtrsfiltre)
                {

                    temp.ImportRow(dr);
                }

                dgvr24h.DataSource = temp;
                lnumber.Text = "number of lines:" + dgvr24h.RowCount.ToString();
            }

        }

        private void cbaliment_SelectedIndexChanged(object sender, EventArgs e)
        {
            hacer_filtro_r24h();
            lnumber.Text = "number of lines:" + dgvr24h.RowCount.ToString();

        }

        private void cbgrupfla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbgrupfla.SelectedIndex > -1)
            {
                string slselectgfla = cbgrupfla.SelectedItem.ToString();
                DAO d = new DAO();
                /*DataTable dtcodifla = d.pasar_consulta_datatable("select FdGrp_Cd from Food_groups where FdGrp_Desc='" + slselectgfla + "'");
                string sselectgfla = dtcodifla.Rows[0][0].ToString();*/
                System.Data.DataRow[] dtrsfiltre = dtfla.Select("food_group='" + slselectgfla + "'");
                System.Data.DataTable temp = dtfla.Clone();

                foreach (DataRow dr in dtrsfiltre)
                {

                    temp.ImportRow(dr);
                }

                dgvfla.DataSource = temp;
                System.Data.DataTable dtsubgroup = d.pasar_consulta_datatable("select distinct food_subgroup from foods_phenol_explorer where food_group='" + slselectgfla + "'");
                cbsubgroup.Items.Clear();
                int i = 0;
                while (i < dtsubgroup.Rows.Count)
                {
                    cbsubgroup.Items.Add(dtsubgroup.Rows[i][0].ToString());

                    i++;
                }
            }
        }

        private void bqfiltror24h_Click(object sender, EventArgs e)
        {
            filter = "";            
            dgvr24h.DataSource = dtr24h;
            lnumber.Text = "number of lines:" + dgvr24h.RowCount.ToString();
            cbgrup.SelectedIndex = -1;
            cbaliment.SelectedIndex = -1;
            cbvariable.SelectedIndex = -1;
            cbname.SelectedIndex = -1;
            tbbuscar.Text = "";
        }

        private void bqfiltrofla_Click(object sender, EventArgs e)
        {
            dgvfla.DataSource = dtfla;
            cbgrupfla.SelectedIndex = -1;
            cbsubgroup.SelectedIndex = -1;
            tbbuscarfla.Text = "";
        }

        private void dgvr24h_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j = 0;
            while (j < dgvr24h.SelectedRows.Count)
            {
                DataGridViewRow dgvr24hsol = dgvr24h.SelectedRows[j];
                int i = 0;
                DAO d = new DAO();
                while (i < dgvfla.SelectedRows.Count)
                {
                    DataGridViewRow dgvrfla = dgvfla.SelectedRows[i];
                    string sid = dgvr24hsol.Cells["ID"].Value.ToString();
                    string scountry = dgvr24hsol.Cells["COUNTRY"].Value.ToString();
                    string soccuseq = dgvr24hsol.Cells["OCCUSEQ"].Value.ToString();
                    string sfdclass = dgvr24hsol.Cells["FDCLASS"].Value.ToString();
                    string sgrpname = dgvr24hsol.Cells["GRPNAME"].Value.ToString();
                    string sfdcode = dgvr24hsol.Cells["FDCODE"].Value.ToString();
                    string sfdcode2 = dgvr24hsol.Cells["FDCODE2"].Value.ToString();
                    string sengnam = dgvr24hsol.Cells["ENGNAM"].Value.ToString();
                    string sctynam = dgvr24hsol.Cells["CTYNAM"].Value.ToString();
                    string sfacetdesc = dgvr24hsol.Cells["FACETDESC"].Value.ToString();
                    string sfreq = dgvr24hsol.Cells["FREQ"].Value.ToString();
                    string sflag = dgvr24hsol.Cells["FLAG"].Value.ToString();
                    string slengnam = dgvr24hsol.Cells["LENGNAM"].Value.ToString();
                    string slctynam = dgvr24hsol.Cells["LCTYNAM"].Value.ToString();
                    string sdesc1 = dgvr24hsol.Cells["DESC1"].Value.ToString();
                    string sdesc2 = dgvr24hsol.Cells["DESC2"].Value.ToString();
                    string sdesc3 = dgvr24hsol.Cells["DESC3"].Value.ToString();
                    string sdesc4 = dgvr24hsol.Cells["DESC4"].Value.ToString();
                    string sdesc5 = dgvr24hsol.Cells["DESC5"].Value.ToString();
                    string sdesc6 = dgvr24hsol.Cells["DESC6"].Value.ToString();
                    string sdesc7 = dgvr24hsol.Cells["DESC7"].Value.ToString();
                    string sdesc8 = d.pasar_consulta_datatable("Select DESC8 from r24h where ID =" + sid).Rows[0][0].ToString();
                    string sdesc9 = d.pasar_consulta_datatable("Select DESC9 from r24h where ID =" + sid).Rows[0][0].ToString();
                    string sdesc10 = d.pasar_consulta_datatable("Select DESC10 from r24h where ID =" + sid).Rows[0][0].ToString();
                    string sfat = dgvr24hsol.Cells["FATATTACHED"].Value.ToString();
                    string sid_fla = dgvrfla.Cells["id"].Value.ToString();
                    string slegacy_id = dgvrfla.Cells["legacy_id"].Value.ToString();
                    string sname = dgvrfla.Cells["name"].Value.ToString();
                    string sfood_group = dgvrfla.Cells["food_group"].Value.ToString();
                    string sfood_subgroup = dgvrfla.Cells["food_subgroup"].Value.ToString();
                    string sfood_source_french = dgvrfla.Cells["food_source_french"].Value.ToString();
                    string sfood_source_scientific_name = dgvrfla.Cells["food_source_scientific_name"].Value.ToString();
                    string sfood_source_botanical_family = dgvrfla.Cells["food_source_botanical_family"].Value.ToString();
                    string ssubfamily_1 = dgvrfla.Cells["subfamily_1"].Value.ToString();
                    string ssubfamily_2 = dgvrfla.Cells["subfamily_2"].Value.ToString();
                    string sfamily = dgvrfla.Cells["family"].Value.ToString();
                    string sfood_source = dgvrfla.Cells["food_source"].Value.ToString();
                    string snotes = dgvrfla.Cells["notes"].Value.ToString();
                    double dprop = 1;
                    Link l = new Link(sid, scountry, soccuseq, sfdclass, sgrpname, sfdcode, sfdcode2, sengnam, sctynam, sfacetdesc, sfreq, sflag, slengnam, slctynam, sdesc1, sdesc2, sdesc3, sdesc4, sdesc5, sdesc6, sdesc7, sdesc8, sdesc9, sdesc10, sfat, sid_fla, slegacy_id, sname,sfood_group,sfood_subgroup,sfood_source_french,sfood_source_scientific_name,sfood_source_botanical_family,ssubfamily_1,ssubfamily_2,sfamily,sfood_source,snotes, dprop);
                    l.agregar_a_datatable(dtlinks);
                    i++;
                }
                j++;
            }
            dgvlink.DataSource = dtlinks;
           
            
            

        }

        private void dgvlink_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvr24h_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           try
            {
                dtlinks = (DataTable)dgvlink.DataSource;
                bool bcomp_prop = Links.proporciones_correctas(dtlinks);
                if (!bcomp_prop)
                {
                    MessageBox.Show("The proportions are incorrect", "Error in the proportions", MessageBoxButtons.OK);
                }
                else
                {
                    DAO d = new DAO();
                    d.hacer_links(dtlinks);
                    dtlinks.Rows.Clear();
                    recargar_r24h();
                    MessageBox.Show("Los links have been introduced correctly");
                }
           }
            catch (LinkException le)
            {
                MessageBox.Show(le.mensaje);
            }
            
            
            
            

        }

        private void recargar_r24h()
        {
            MySql.Data.MySqlClient.MySqlConnection msc = new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.conexion.ToString());
            MySql.Data.MySqlClient.MySqlDataAdapter mdar24h = new MySql.Data.MySqlClient.MySqlDataAdapter("select visited,ENGNAM,FACETDESC,COUNTRY,FREQ,FATATTACHED,LENGNAM,CTYNAM,LCTYNAM,OCCUSEQ,DESC1,DESC2,DESC3,DESC4,DESC5,DESC6,DESC7,FDCLASS,GRPNAME,FDCODE,FDCODE2,FLAG,ID,ENGNAM_sc from r24h", msc);
            dtr24h = new DataTable();
            mdar24h.Fill(dtr24h);
            if (cbaliment.SelectedItem != null)
            {
                hacer_filtro_r24h();
            }
            else
            {
                dgvr24h.DataSource = dtr24h;
            }
            
        }
        private void hacer_filtro_r24h()
        {
            if (cbaliment.SelectedIndex > -1)
            {
                string slselectgroup = cbgrup.SelectedItem.ToString();
                string slselectaliment = cbaliment.SelectedItem.ToString();
                DAO d = new DAO();
                /*DataTable dtcodiselectgroup = d.pasar_consulta_datatable("select distinct FDCLASS from r24h where GRPNAME='" + slselectgroup + "'");
                string sselectgroup = dtcodiselectgroup.Rows[0][0].ToString();*/
                filter = "ENGNAM_sc='" + slselectaliment + "' AND GRPNAME='" + slselectgroup + "'";
                System.Data.DataRow[] dtrsfiltre = dtr24h.Select(filter);

                System.Data.DataTable temp = dtr24h.Clone();

                foreach (DataRow dr in dtrsfiltre)
                {

                    temp.ImportRow(dr);
                }

                dgvr24h.DataSource = temp;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbbuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string slike = tbbuscar.Text;
                DAO d = new DAO();
                dtr24h.CaseSensitive = false;
                System.Data.DataTable dttemp;
                System.Data.DataRow[] drasel = dtr24h.Select("ENGNAM LIKE '%" + slike + "%'");
                if (drasel.Length == 0)
                {
                    dttemp = dtr24h.Clone();
                }
                else
                {
                    dttemp = d.pasar_datarow_datatable(drasel);
                }
                dgvr24h.DataSource = dttemp;
                lnumber.Text = "number of lines:" + dgvr24h.RowCount.ToString();
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("don't introduce rare character only a-z character");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string slike = tbbuscarfla.Text;
                DAO d = new DAO();
                dtfla.CaseSensitive = false;
                System.Data.DataTable dttemp;
                System.Data.DataRow[] drasel = dtfla.Select("name LIKE '%" + slike + "%'");
                if (drasel.Length == 0)
                {
                    dttemp = dtfla.Clone();
                }
                else
                {
                    dttemp = d.pasar_datarow_datatable(drasel);
                }
                dgvfla.DataSource = dttemp;
            }
            catch(SyntaxErrorException){
                MessageBox.Show("don't introduce rare character only a-z character");
            }
        }

        private void dgvr24h_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtlinks != null)
            {
                dtlinks.Clear();
            }
            int i = 0;
            while (i < dgvr24h.SelectedRows.Count)
            {
                string sid = dgvr24h.SelectedRows[i].Cells["ID"].Value.ToString();
                System.Data.DataTable dttemp = Links.encontrar_links(sid);

                if (dtlinks != null)
                {
                    dtlinks = Links.juntar_datatable(dtlinks, dttemp);
                }
                else
                {
                    dtlinks = dttemp;
                }
                i++;
            }
            dgvlink.DataSource = dtlinks;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            recargar_r24h();
        }

        private void dgvr24h_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                dtlinks = (DataTable)dgvlink.DataSource;
                bool bcomp_prop = Links.proporciones_correctas(dtlinks);
                if (!bcomp_prop)
                {
                    MessageBox.Show("The proportions are incorrect", "Error in the proportions", MessageBoxButtons.OK);
                }
                else
                {
                    DAO d = new DAO();
                    d.hacer_links(dtlinks);
                    dtlinks.Rows.Clear();
                    recargar_r24h();
                    MessageBox.Show("The links have been introduced correctly");
                    lnumber.Text = "numbers of lines:" + dgvr24h.RowCount;
                    
                    cbvariable.SelectedIndex = -1;
                    cbname.SelectedIndex = -1;
                    tbbuscar.Text = "";
                }
                
            }
            catch (LinkException le)
            {
                MessageBox.Show(le.mensaje);
            }
            
        }

        private void cbsubgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbsubgroup.SelectedIndex > -1)
            {
                string slselectgfla = cbgrupfla.SelectedItem.ToString();
                string slselectsubgroup = cbsubgroup.SelectedItem.ToString();
                System.Data.DataRow[] dtrsfiltre = dtfla.Select("food_subgroup='" + slselectsubgroup + "'");
                DAO d = new DAO();
                System.Data.DataTable dtfiltre = d.pasar_datarow_datatable(dtrsfiltre);
                dgvfla.DataSource = dtfiltre;
            }
        }

        private void dgvlink_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvlink_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("introduce the values in the correct format");
        }

        private void dgvlink_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("introduce the values in the correct format");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DAO d = new DAO();
            System.Data.DataTable dtbuck_up = d.pasar_consulta_datatable("select * from link");
            d.ToCSV(dtbuck_up, Properties.Settings.Default.path);
            MessageBox.Show("Back-up Done");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DAO d = new DAO();
            d.ejecutar_sql("Select * into OUTFILE '" + Properties.Settings.Default.path + "' from link");
            MessageBox.Show("Back-up Done");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbcook_met_SelectedIndexChanged(object sender, EventArgs e)
        {
            DAO d = new DAO();
            string smethod = cbcook_met.SelectedItem.ToString();
            System.Data.DataTable dtmethod = d.pasar_consulta_datatable("Select code from cook_method where method='" + smethod +"'");
            string scode = dtmethod.Rows[0][0].ToString();
            if (dgvlink.RowCount == 1)
            {
                dgvlink.Rows[0].Cells["YCookmethod"].Value = scode;
            }
            int i = 0;
            while (i < dgvlink.SelectedRows.Count)
            {
                dgvlink.SelectedRows[i].Cells["YCookmethod"].Value = scode;
                i++;
            }
            
        }

        private void cbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbname.SelectedIndex > -1)
            {
                cbvariable.Items.Clear();
                DAO d = new DAO();
                System.Data.DataTable dtvariable = d.pasar_consulta_datatable("select distinct " + cbname.SelectedItem.ToString() + " from r24h");
                int i = 0;
                while (i < dtvariable.Rows.Count)
                {
                    cbvariable.Items.Add(dtvariable.Rows[i][0].ToString());
                    i++;
                }
            }
        }

        private void cbvariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbvariable.SelectedIndex > -1)
            {
                string svariablefilter = cbname.SelectedItem.ToString() + "='" + cbvariable.SelectedItem.ToString() + "'";
                if (filter.Length > 0)
                {
                    filter = filter + " AND " + svariablefilter;
                }
                else
                {
                    filter = svariablefilter;
                }
                System.Data.DataRow[] dtrsfiltre = dtr24h.Select(filter);
                DAO d = new DAO();
                System.Data.DataTable dtfiltre = d.pasar_datarow_datatable(dtrsfiltre);
                dgvr24h.DataSource = dtfiltre;
                lnumber.Text = "number of lines:" + dgvr24h.RowCount.ToString();
            }
            

        }

        

        
        
    }
}
