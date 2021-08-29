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
            //String[] spearator = { "x", "(", "^", "*", ")" };
            //Int32 count = 4;
            //var coSo = 0;
            //var soMu = 0;
            //// using the method
            //String[] strlist = str.Split(spearator, count,
            //       StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < strlist.Length; i++)
            //{
            //    if (i == 0)
            //        coSo = Int32.Parse(strlist[i]);
            //    else
            //        soMu = Int32.Parse(strlist[i]);
            //}

            //var so = new PhanTu(coSo, soMu);
            //return so;
            //var str = "2x^6";

            String[] s = { "+", "-" };
            String[] subEx = str.Split(s, str.Length,
                   StringSplitOptions.None);

            String[] spearator = { "x", "^" };
            List<PhanTu> result = new List<PhanTu>();
            for(int i = 0; i < subEx.Length; i++)
            {
                // using the method
                String[] strlist = subEx[i].Split(spearator, subEx.Length,
                       StringSplitOptions.RemoveEmptyEntries);

                if (strlist.Length == 2)
                {
                    ((ILog)parent).log("Sub string: He so: " + strlist[0] + " - So Mu: " + strlist[1]);
                    result.Add(new PhanTu(Int32.Parse(strlist[0]), Int32.Parse(strlist[1])));
                }
                if (strlist.Length == 1)
                {
                    ((ILog)parent).log("Sub string: He so: " + strlist[0] + " - So Mu: " + 0);
                    result.Add(new PhanTu(Int32.Parse(strlist[0]), 0));
                }
            }
            
            
            return result;
        }
    }
}
