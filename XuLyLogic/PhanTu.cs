using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic
{
    public class PhanTu : IComparable
    {

        private float heSo;
        private float soMu;

        public PhanTu(float heSo, float soMu)
        {
            this.heSo = heSo;
            this.soMu = soMu;
        }

        public float getHeSo()
        {
            return this.heSo;
        }

        public void setHeSo(float heSo)
        {
            this.heSo = heSo;
        }

        public float getSoMu()
        {
            return this.soMu;
        }

        public void setSoMu(float soMu)
        {
            this.soMu = soMu;
        }

        override
        public String ToString()
        {
            return "He so: " + heSo + " - So mu: " + soMu;
        }

        public int CompareTo(object obj)
        {
            int soMuCompare = (int)(soMu - ((PhanTu)obj).soMu);
            int heSoCompare = (int)(heSo - ((PhanTu)obj).heSo);
            return (soMuCompare == 0) ? heSoCompare : soMuCompare;
        }
    }
}
