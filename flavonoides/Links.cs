using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flavonoides
{
    class Links
    {
        //MySql.Data.MySqlClient.MySqlConnection msc = new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.conexion.ToString());



        public static System.Data.DataTable encontrar_links(string sid)
        {
            DAO d = new DAO();
            System.Data.DataTable dtlinks = d.pasar_consulta_datatable("select * from link where ID=" + sid);
            return dtlinks;
        }
        public static System.Data.DataTable juntar_datatable(System.Data.DataTable dt1, System.Data.DataTable dt2)
        {
            int i = 0;
            while (i < dt2.Rows.Count)
            {
                dt1.ImportRow(dt2.Rows[i]);
                i++;
            }
            return dt1;
        }
        public static bool proporciones_correctas(System.Data.DataTable dtlink)
        {
            DAO d = new DAO();
            System.Collections.ArrayList alids = d.sacar_val_posibles(dtlink, "ID");
            int i = 0;
            

            bool bprop_cor = true;
            while (i < alids.Count)
            {
                string sid = alids[i].ToString();
                Decimal dprop = (Decimal)dtlink.Compute("sum(Yprop)", "ID=" + sid);
                
                if (dprop != 1)
                {
                    bprop_cor = false;
                }
                i++;
            }
            return bprop_cor;
        }
        
        
                




    }
}
