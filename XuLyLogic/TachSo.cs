using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic
{
    public class TachSo
    {
        Object parent;

        public TachSo(Object parent)
        {
            this.parent = parent;
        }

        public List<PhanTu> createPhanTus(string str)
        {
            str = str.Replace(" ", "");
            String[] s = { "+" };
            String[] subEx = str.Split(s, str.Length,
                   StringSplitOptions.None);
            var text = "";
            foreach (var item in subEx)
            {
                text += NoiChuoi(item) + ",";
            }

            String[] dauphay = { "," };

            //using the method
            String[] strlistdauphay = text.Split(dauphay, text.Length,
                   StringSplitOptions.RemoveEmptyEntries);

            String[] spearator = { "x", "^" };
            List<PhanTu> result = new List<PhanTu>();
            for(int i = 0; i < strlistdauphay.Length; i++)
            {
                // using the method
                String[] strlist = strlistdauphay[i].Split(spearator, strlistdauphay.Length,
                       StringSplitOptions.RemoveEmptyEntries);

                if (strlist.Length == 2)
                {
                    ((ILog)parent).log("Sub string: He so: " + strlist[0] + " - So Mu: " + strlist[1]);
                    result.Add(new PhanTu(float.Parse(strlist[0]), float.Parse(strlist[1])));
                }
                if (strlist.Length == 1)
                {
                    ((ILog)parent).log("Sub string: He so: " + strlist[0] + " - So Mu: " + 0);
                    result.Add(new PhanTu(float.Parse(strlist[0]), 0));
                }
            }
            
            
            return result;
        }
        public string NoiChuoi(string str)
        {
            //var text = "";

            //for (int i = 0; i < str.Length; i++)
            //{
            //    text += str[i];

            //    if (Convert.ToString(str[0]) == "-")
            //    {

            //    }
            //    if (Convert.ToString(str[i]) == "-" && i != 0)
            //    {
            //        if (text != "")
            //        {
            //            text = text.Remove(text.Length - 1);
            //            text += ",-";
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine(text);
            //    }
            //}
            str = str.Replace("-", ",-");
            if (str[0].Equals(","))
            {
                str.Remove(0);
            }
            str = str.Replace("^,", "^");
            return str;
        }

    }
}
