using System;

using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic

{
    class Logic
    {
        Object parent;
        public Logic(Object parent)
        {
            this.parent = parent;
        }
        HashTable hashTable = new HashTable();

        public void PushItem(PhanTu pt)
        {
            //int heSo = (int)hashTable.Get(pt.getSoMu());

            int heSo = pt.getHeSo();
            if (hashTable.IsExist(pt.getSoMu()))
            {
                heSo += ((PhanTu)hashTable.Get(pt.getSoMu())).getHeSo();
                pt.setHeSo(heSo);
            }

            hashTable.Add(pt.getSoMu(), pt);
        }

        public String result()
        {
            String s = "";
            for (int i = 0; i < hashTable.keys.Count; i++)
            {
                PhanTu phanTu = (PhanTu)hashTable.Get(hashTable.keys[i]);
                if(i > 0 && phanTu.getHeSo() >= 0)
                {
                    s += "+";
                }
                s += phanTu.getHeSo() + "x^" + phanTu.getSoMu();
                if (parent is ILog)
                {
                    ((ILog)parent).log("HashItem: " + phanTu);
                }
            }
            return s;
        }

        public void clearHashTable()
        {
            hashTable = new HashTable();
        }
    }
}
