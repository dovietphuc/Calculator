using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic
{
    public class PhanTu
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
    }
}
