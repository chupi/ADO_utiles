using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flavonoides
{
    class Link
    {
        private string sid;
        private string scountry;
        private string soccuseq;
        private string sfdclass;
        private string sgrpname;
        private string sfdcode;
        private string sfdcode2;
        private string sengnam;
        private string sctynam;
        private string sfacetdesc;
        private string sfreq;
        private string sflag;
        private string slengnam;
        private string slctynam;
        private string sdesc1;
        private string sdesc2;
        private string sdesc3;
        private string sdesc4;
        private string sdesc5;
        private string sdesc6;
        private string sdesc7;
        private string sdesc8;
        private string sdesc9;
        private string sdesc10;
        private string sfat;
        private string sidfla;
        private string slegacy_id;
        private string sname;
        private string sfood_group;
        private string sfood_subgroup;
        private string sfood_source_french;
        private string sfood_source_scientific_name;
        private string food_source_botanical_family;
        private string ssubfamily_1;
        private string ssubfamily_2;
        private string sfamily;
        private string sfood_source;
        private string snotes;
        private double dprop;
        public Link(string sident, string spais, string soccu, string sdfclase, string snombre_grupo, string scodigo1, string scodigo2, string seng, string scty, string sdes_facet, string sfrecuencia, string sf, string sleng, string slcty, string sd1, string sd2, string sd3, string sd4, string sd5, string sd6, string sd7, string sd8, string sd9, string sd10, string sgrasa, string sid_fla, string slegalid,string nom_fla,string sgrupo,string ssubgrupo,string snom_fran,string snom_sci,string snom_bot,string ssubfamilia1,string ssubfamilia2,string sfamilia,string sorigen,string snotas, double dproporcion)
        {
            sid = sident;
            scountry = spais;
            soccuseq = soccu;
            sfdclass = sdfclase;
            sgrpname = snombre_grupo;
            sfdcode = scodigo1;
            sfdcode2 = scodigo2;
            sengnam = seng;
            sctynam = scty;
            sfacetdesc = sdes_facet;
            sfreq = sfrecuencia;
            sflag = sf;
            slengnam = sleng;
            slctynam = slcty;
            sdesc1 = sd1;
            sdesc2 = sd2;
            sdesc3 = sd3;
            sdesc4 = sd4;
            sdesc5 = sd5;
            sdesc6 = sd6;
            sdesc7 = sd7;
            sdesc8 = sd8;
            sdesc9 = sd9;
            sdesc10 = sd10;
            sfat = sgrasa;
            sidfla = sid_fla;
            slegacy_id = slegalid;
            sname = nom_fla;
            sfood_group=sgrupo;
            sfood_subgroup=ssubgrupo;
            sfood_source_french=snom_fran;
            sfood_source_scientific_name = snom_sci;
            food_source_botanical_family=snom_bot;
            ssubfamily_1 = ssubfamilia1;
            ssubfamily_2 = ssubfamilia2;
            sfamily = sfamilia;
            sfood_source = sorigen;
            snotes = snotas;
            dprop = dproporcion;
        }
        public void agregar_a_datatable(System.Data.DataTable dtlinks)
        {
            System.Data.DataRow dtlink = dtlinks.NewRow();
            dtlink["ID"] = sid;
            dtlink["COUNTRY"] = scountry;
            dtlink["OCCUSEQ"] = soccuseq;
            dtlink["FDCLASS"] = sfdclass;
            dtlink["GRPNAME"] = sgrpname;
            dtlink["FDCODE"] = sfdcode;
            dtlink["FDCODE2"] = sfdcode2;
            dtlink["ENGNAM"] = sengnam;
            dtlink["CTYNAM"] = sctynam;
            dtlink["FACETDESC"] = sfacetdesc;
            dtlink["FREQ"] = sfreq;
            dtlink["FLAG"] = sflag;
            dtlink["LENGNAM"] = slengnam;
            dtlink["LCTYNAM"] = slctynam;
            dtlink["DESC1"] = sdesc1;
            dtlink["DESC2"] = sdesc2;
            dtlink["DESC3"] = sdesc3;
            dtlink["DESC4"] = sdesc4;
            dtlink["DESC5"] = sdesc5;
            dtlink["DESC6"] = sdesc6;
            dtlink["DESC7"] = sdesc7;
            dtlink["DESC8"] = sdesc8;
            dtlink["DESC9"] = sdesc9;
            dtlink["DESC10"] = sdesc10;
            dtlink["FATATTACHED"] = sfat;
            dtlink["Yid_phenol"] = sidfla;
            dtlink["Ylegacy_id"] = slegacy_id;
            dtlink["Yname"] = sname;
            dtlink["Yfood_group"]=sfood_group;
            dtlink["Yfood_subgroup"] = sfood_subgroup;
            dtlink["Yfood_source_french"]=sfood_source_french;
            dtlink["Yfood_source_scientific_name"] = sfood_source_scientific_name;
            dtlink["Yfood_source_botanical_family"]=food_source_botanical_family;
            dtlink["Ysubfamily_1"] = ssubfamily_1;
            dtlink["Ysubfamily_2"] = ssubfamily_2;
            dtlink["Yfamily"] = sfamily;
            dtlink["Yfood_source"] = sfood_source;
            dtlink["Ynotes"] = snotes;
            dtlink["Yprop"] = dprop;
            dtlink["Ycomment"] = " ";
            dtlink["YEstimation"] = 1;
            dtlink["YCookmethod"] = "";
            dtlinks.Rows.Add(dtlink);
        }
    }
}
