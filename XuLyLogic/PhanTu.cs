using System;

public class PhanTu
{
	public PhanTu()
	{
        private int heSo;
        private int soMu;

        public PhanTu(int heSo, int soMu)
        {
            this.heSo = heSo;
            this.soMu = soMu;
        }

        public int getHeSo()
        {
            return this.heSo;
        }

        public void setHeSo(int heSo)
        {
            this.heSo = heSo;
        }

        public int getSoMu()
        {
            return this.soMu;
        }

        public void setSoMu(int soMu)
        {
            this.soMu = soMu;
        }
    }

}
