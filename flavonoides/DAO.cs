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
        /*Devolvemos un datatable con el resultado de la consulta que esta como paramatro en la bd cuyo string de conexion esta el parametro conexion del fichero de confi
        guracon*/
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
        /*quita de un DataTable aquellas columnas que no tienen ningun valor*/
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
        /*mira si la la columna con nombre snombrecol del Datatable tiene valores*/
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
    /*ejecuta la consulta que se pasa como parametro cogiendo la base de datos cuyo string de conexion esta en el parametro
    conexion del fichero de configuracion*/
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
        /*devuelve los nombres de las columnas de un Datatable*/
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
        /*pasamos un array de DataRow a un DataTable*/
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
        /*extraemos un Datatable a un CSV con el path pasado como parametro*/
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
        
        

        
        /* hacer un select distinct de un columna pero con DataTable*/
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
    }
}
