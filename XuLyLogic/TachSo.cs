using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic
{
    public class TachSo
    {
        public PhanTu HeSo(string str)
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

            String[] spearator = { "x", "^" };
            Int32 count = 2;
            // using the method
            String[] strlist = str.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);
            
            if(strlist.Length == 2)
            {
                return new PhanTu(Int32.Parse(strlist[0]), Int32.Parse(strlist[1]));
            }
            if (strlist.Length == 1)
            {
                return new PhanTu(Int32.Parse(strlist[0]), 0);
            }
            return new PhanTu(0, 0);
        }
    }
}
