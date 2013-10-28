using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;

namespace flavonoides
{
    public class DAO
    {
        /*funcion que lee del excel la primera columna y lo pasa a un datatable*/
        public System.Data.DataTable pasar_excel_datatable(string sexcel)
        {
            /*System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; " + "data source=" + sexcel + "; " + "Extended Properties=Excel 8.0;");
            MyConnection.Open();
            System.Data.OleDb.OleDbDataAdapter odda = new System.Data.OleDb.OleDbDataAdapter("select * from [listado$]", MyConnection);
            System.Data.DataTable dt = new System.Data.DataTable();
            odda.Fill(dt);
            MyConnection.Close();
            return dt;*/
            string[] snpajuelas = System.IO.File.ReadAllLines(sexcel);
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add(snpajuelas[0]);
            int i = 1;
            
            while (i < snpajuelas.Length)
            {
                dt.Rows.Add(snpajuelas[i]);
                i++;
               
            }
            return dt;
            
        }
        public System.Data.DataTable pasar_consulta_datatable(string consulta)
        {
            MySql.Data.MySqlClient.MySqlConnection mscon = new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.conexion);
            
            MySql.Data.MySqlClient.MySqlDataAdapter mda = new MySql.Data.MySqlClient.MySqlDataAdapter(consulta, mscon);
            
            mda.SelectCommand.CommandTimeout = 0;
            System.Data.DataTable dt = new System.Data.DataTable();
            mda.Fill(dt);
            
            mscon.Close();
            return dt;
            
        }
        /*filtra la tabla origen con los elementos de la columa clave de la tabla filtro*/
        public System.Data.DataTable Filter(System.Data.DataTable filtro, System.Data.DataTable origen, string clave)
        {
            int i = 0;
            System.Data.DataTable dtfiltrado = origen.Clone();
            while (i < filtro.Rows.Count)
            {
                string svalor = filtro.Rows[i][0].ToString();
                System.Data.DataRow[] drseleccionados = origen.Select(clave + "='" + svalor + "'");
                /*if (drseleccionados.Length == 0)
                {
                    System.Data.DataRow drmissing = dtfiltrado.NewRow();
                    drmissing["id_mostra"] = svalor;
                    dtfiltrado.Rows.Add(drmissing);
                }*/
                foreach (System.Data.DataRow dr in drseleccionados)
                {
                    dtfiltrado.ImportRow(dr);
                }
                i++;
            }
            return dtfiltrado;
        }
        public void Quitar_vacios(System.Data.DataTable dt)
        {
            int k = 1;
            while (k < dt.Columns.Count)
            {
                int contador;
                string nombrecol = dt.Columns[k].ColumnName;

                contador = (int)dt.Compute("count(" + nombrecol + ")", "");
                if (contador == 0)
                {
                    dt.Columns.Remove(dt.Columns[k]);
                }
                else
                {
                    
                    if (variable_vacia(dt,nombrecol))
                    {
                        dt.Columns.Remove(dt.Columns[k]);
                    }
                    else
                    {
                        k++;
                    }
                }
            }
        }
        public bool variable_vacia(System.Data.DataTable dt, string snombrecol)
        {
            int i = 0;
            bool llena = false;
            while (i < dt.Rows.Count && llena == false)
            {
                llena = dt.Rows[i][snombrecol].ToString() != "";
                i++;
            }
            return !llena;
        }

        public void ejecutar_sql(string sql)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlConnection mscon = new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.conexion);
                mscon.Open();

                MySql.Data.MySqlClient.MySqlCommand mscom = new MySql.Data.MySqlClient.MySqlCommand(sql, mscon);
                mscom.ExecuteNonQuery();
                mscon.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                LinkException le = new LinkException(e.Message);
                throw le;
            }
            
        }
        public System.Collections.ArrayList nombres_columnas(System.Data.DataTable dt)
        {
            int i = 0;
            System.Collections.ArrayList alnom_col = new System.Collections.ArrayList();
            
            while (i < dt.Columns.Count)
            {
                alnom_col.Add(dt.Columns[i].Caption);
                i++;
            }
            return alnom_col;
        }
        
        public System.Data.DataTable pasar_datarow_datatable(System.Data.DataRow[] adr)
        {
            System.Data.DataTable dtfiltrado = new System.Data.DataTable();
            if (adr.Length != 0)
            {
                dtfiltrado = adr[0].Table.Clone();
                foreach (System.Data.DataRow dr in adr)
                {
                    dtfiltrado.ImportRow(dr);
                }
            }
            return dtfiltrado;
        }
        public void ToCSV( System.Data.DataTable dt,string path)  
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder();  
     
            for (int x = 0; x < dt.Columns.Count; x++)  
            {
                if (x != 0)
                {
                    sb.Append(";");
                }
                sb.Append(dt.Columns[x].ColumnName);  
             }  
            sb.AppendLine();  
            foreach (DataRow row in dt.Rows)  
            {  
                for (int x = 0; x < dt.Columns.Count; x++)  
                {
                    if (x != 0)
                    {
                        sb.Append(";");
                    }
                    sb.Append(row[dt.Columns[x]].ToString());  
                }  
     
                sb.AppendLine();  
            }  
            
            System.IO.File.WriteAllText(path, sb.ToString());
       }
        public bool autentificar(string suser, string spassword)
        {
            System.Data.DataTable dteval = pasar_consulta_datatable("select * from persona where user='" + suser + "' and password='" + spassword + "'");
            
            bool baut = dteval.Rows.Count > 0;
            return baut;
        }
        public System.Data.DataTable report(string sidestudio, string sidmaterial)
        {
            System.Data.DataTable dtreportini = pasar_consulta_datatable("call report_ini(" + sidestudio + "," + sidmaterial + ")");
            System.Data.DataTable dtreportfin = pasar_consulta_datatable("call report_fin(" + sidestudio + "," + sidmaterial + ")");
            ejecutar_sql("commit");
            System.Data.DataTable dtmerge = encontrar_padres(dtreportfin, dtreportini);
            ejecutar_sql("create temporary table merge_tmp(hijo INTEGER,padre INTEGER,PRIMARY KEY(hijo))");
            int i = 0;
            while (i<dtmerge.Rows.Count){
                ejecutar_sql("insert into merge_tmp values("+dtmerge.Rows[i]["hijo"]+","+dtmerge.Rows[i]["padre"]+")");
                i++;
            }
            System.Data.DataTable dtreport = pasar_consulta_datatable("select ri.*,rf.* from report_init ri left outer join merge_tmp mt on (ri.IdMuestraEsp=mt.padre) left outer join report_final rf on (mt.hijo = rf.IdMuestraEsp)");
            dtreport.Columns.RemoveAt(0);
            dtreport.Columns.RemoveAt(11);
            ejecutar_sql("drop table if exists merge_tmp");
            
            return dtreport;

        }
        

        public System.Data.DataTable encontrar_padres(System.Data.DataTable dtfinal, System.Data.DataTable dtorigen)
        {
            System.Data.DataTable dtmerge = new System.Data.DataTable();
            System.Data.DataColumn dchijo = new System.Data.DataColumn("hijo");
            System.Data.DataColumn dcpadre = new System.Data.DataColumn("padre");
            //System.Data.DataColumn dcanalisis = new System.Data.DataColumn("analisis");
            dtmerge.Columns.Add(dchijo);
            dtmerge.Columns.Add(dcpadre);
            //dtmerge.Columns.Add(dcanalisis);

            int i = 0;
            while (i < dtfinal.Rows.Count)
            {
                string shijo = dtfinal.Rows[i]["IdMuestraEsp"].ToString();
                //Console.WriteLine("hijo:" + shijo);
                encontrar_padre(dtmerge, shijo, dtorigen);
                i++;
            }
            return dtmerge;

        }
        public void encontrar_padre(System.Data.DataTable dtresult, string shijo, System.Data.DataTable dtpadres)
        {
            string spos_padre;
            //string sanalisis = "";
            spos_padre = shijo;
            /*System.Data.DataTable dtanalisis = pasar_consulta_datatable("SELECT GROUP_CONCAT(distinct nombre) AS analisis FROM origen LEFT OUTER JOIN analisis ON (origen.IdMuestraesp = analisis.IdMuestraesp) LEFT OUTER JOIN uso_esp ON (analisis.Id_Uso_General = uso_esp.Id_Uso_General) AND (analisis.Id_Uso = uso_esp.Id_Uso) where origen.IdMuestraesp2=" + spos_padre+" group by IdMuestraesp2");
            if (dtanalisis.Rows.Count > 0)
            {
                sanalisis = dtanalisis.Rows[0][0].ToString();
            }
            Console.WriteLine("entro en despues de los analisis");*/
            System.Data.DataRow[] mdrsel = dtpadres.Select("IdMuestraEsp=" + spos_padre);
            while (mdrsel.Length == 0)
            {
                
                DataTable dtpos_padre = pasar_consulta_datatable("SELECT IdMuestraesp2 from origen where IdMuestraesp=" + spos_padre);
                spos_padre = dtpos_padre.Rows[0][0].ToString();
                /*dtanalisis = pasar_consulta_datatable("SELECT GROUP_CONCAT( distinct nombre) AS analisis FROM origen LEFT OUTER JOIN analisis ON (origen.IdMuestraesp = analisis.IdMuestraesp) LEFT OUTER JOIN uso_esp ON (analisis.Id_Uso_General = uso_esp.Id_Uso_General) AND (analisis.Id_Uso = uso_esp.Id_Uso) where origen.IdMuestraesp2=" + spos_padre+" group by IdMuestraesp2");
                Console.WriteLine("entro en antes de los analisis2");
                if (dtanalisis.Rows.Count > 0 & dtanalisis.Rows[0][0].ToString().Length>0)
                {
                    if (sanalisis.Length > 0)
                    {
                        sanalisis = sanalisis + "," + dtanalisis.Rows[0][0].ToString();
                    }
                    else
                    {
                        sanalisis = dtanalisis.Rows[0][0].ToString();
                    }
                }
                Console.WriteLine("entro en despues de los analisis2");*/
                mdrsel = dtpadres.Select("IdMuestraEsp=" + spos_padre);
            }
            /*dtanalisis = pasar_consulta_datatable("SELECT GROUP_CONCAT( distinct nombre) AS analisis FROM analisis LEFT OUTER JOIN uso_esp ON (analisis.Id_Uso_General = uso_esp.Id_Uso_General) AND (analisis.Id_Uso = uso_esp.Id_Uso) where analisis.IdMuestraesp=" + spos_padre + " group by IdMuestraesp");
            if (dtanalisis.Rows.Count > 0)
            {
                if (sanalisis.Length > 0)
                {
                    sanalisis = sanalisis + "," + dtanalisis.Rows[0][0].ToString();
                }
                else
                {
                    sanalisis = dtanalisis.Rows[0][0].ToString();
                }
            }*/
            System.Data.DataRow drmerge = dtresult.NewRow();
            drmerge["hijo"] = shijo;
            drmerge["padre"] = spos_padre;
            //drmerge["analisis"] = sanalisis;
            dtresult.Rows.Add(drmerge);
        }
        public System.Collections.ArrayList sacar_val_posibles(System.Data.DataTable dt, string svariable)
        {
            System.Collections.ArrayList alval_pos = new ArrayList();
            if (svariable != null)
            {
                ArraySet asval_pos = new ArraySet();
                int i = 0;

                while (i < dt.Rows.Count)
                {
                    if (dt.Rows[i].RowState != DataRowState.Deleted)
                    {
                        asval_pos.add(dt.Rows[i][svariable].ToString());
                    }
                    i++;
                }

                alval_pos = asval_pos.Source;
            }
            return alval_pos;
        }
        public void hacer_links(System.Data.DataTable dtlinks)
        {

            MySql.Data.MySqlClient.MySqlConnection mscon = new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.conexion);
            mscon.Open();
            MySql.Data.MySqlClient.MySqlTransaction mst = mscon.BeginTransaction();
           try
            {              

                
                System.Collections.ArrayList alids = this.sacar_val_posibles(dtlinks, "ID");
                int i = 0;
                string swhere = "(";
                while (i < alids.Count)
                {
                    string sid = alids[i].ToString();
                    swhere = swhere + sid + ",";
                    i++;
                }
                swhere = swhere.Remove(swhere.Length - 1);
                swhere = swhere + ")";
                MySql.Data.MySqlClient.MySqlCommand mscom = new MySql.Data.MySqlClient.MySqlCommand("delete from link where ID IN " + swhere, mscon,mst);
                mscom.ExecuteNonQuery();
                mscom = new MySql.Data.MySqlClient.MySqlCommand("update r24h set visited=TRUE where ID IN " + swhere, mscon, mst);
                mscom.ExecuteNonQuery();

                string sinsert = "insert into link(COUNTRY,OCCUSEQ,FDCLASS,GRPNAME,FDCODE,FDCODE2,ENGNAM,CTYNAM,FACETDESC,FREQ,FLAG,LENGNAM,LCTYNAM,DESC1,DESC2,DESC3,DESC4,DESC5,DESC6,DESC7,DESC8,DESC9,DESC10,FATATTACHED,ID,Yid_phenol,Ylegacy_id,Yname,Yfood_source_french,Yfood_source_scientific_name,Yfood_source_botanical_family,Yfood_subgroup,Yfood_group,YProp,Ysubfamily_1,Ysubfamily_2,Yfamily,Yfood_source,Ynotes,YEstimation,YCookmethod,Ycomment) values";
                i = 0;
                while (i < dtlinks.Rows.Count)
                {
                    if (dtlinks.Rows[i].RowState != System.Data.DataRowState.Deleted)
                    {
                        sinsert = sinsert + "(";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["COUNTRY"].ToString() + "',";
                        sinsert = sinsert + dtlinks.Rows[i]["OCCUSEQ"].ToString() + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["FDCLASS"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["GRPNAME"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["FDCODE"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["FDCODE2"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["ENGNAM"].ToString().Replace("'","\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["CTYNAM"].ToString().Replace("'","\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["FACETDESC"].ToString().Replace("'", "\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["FREQ"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["FLAG"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["LENGNAM"].ToString().Replace("'", "\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["LCTYNAM"].ToString().Replace("'", "\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC1"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC2"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC3"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC4"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC5"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC6"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC7"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC8"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC9"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["DESC10"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["FATATTACHED"].ToString() + "',";
                        sinsert = sinsert + dtlinks.Rows[i]["ID"].ToString() + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yid_phenol"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Ylegacy_id"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yname"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yfood_source_french"].ToString().Replace("'", "\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yfood_source_scientific_name"].ToString().Replace("'", "\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yfood_source_botanical_family"].ToString().Replace("'", "\\'") + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yfood_subgroup"].ToString() + "',";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yfood_group"].ToString() + "',";
                        sinsert = sinsert + dtlinks.Rows[i]["YProp"].ToString() + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Ysubfamily_1"].ToString() + "'" + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Ysubfamily_2"].ToString() + "'" + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yfamily"].ToString() + "'" + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Yfood_source"].ToString() + "'" + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Ynotes"].ToString() + "'" + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["YEstimation"].ToString() + "'" + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["YCookmethod"].ToString() + "'" + ",";
                        sinsert = sinsert + "'" + dtlinks.Rows[i]["Ycomment"].ToString().Replace("'", "\\'") + "'),";

                    }
                    i++;
                }
                sinsert = sinsert.Remove(sinsert.Length - 1);
                mscom = new MySql.Data.MySqlClient.MySqlCommand(sinsert, mscon, mst);
                mscom.ExecuteNonQuery();
                mst.Commit();
                mscon.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException le)
            {
                LinkException len;
                if (le.Number == 1062)
                {
                    len = new LinkException("It's not posible to have the same link two times");
                }
                else
                {
                    len = new LinkException("The Estimation and cook method code must be correct codes");
                }

                mst.Rollback();
                mscon.Close();
                throw len;
            }
        }
       


    }
}
