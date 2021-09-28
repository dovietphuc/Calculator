using System;

using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic

{
    class Logic
    {
        Object parent;
        HashTable hashTable;
        CustomLinkedList<PhanTu> linkedList;

        public Logic(Object parent)
        {
            this.parent = parent;
        }

        public string usingHashTable(List<PhanTu> phanTus)
        {
            hashTable = new HashTable();
            foreach (PhanTu pt in phanTus)
            {
                float heSo = pt.getHeSo();
                if (hashTable.IsExist(pt.getSoMu()))
                {
                    heSo += ((PhanTu)hashTable.Get(pt.getSoMu())).getHeSo();
                    pt.setHeSo(heSo);
                }

                hashTable.Add(pt.getSoMu(), pt);
            }
            return resultHashTable();
        }

        public string usingLinkList(List<PhanTu> phanTus)
        {
            linkedList = new CustomLinkedList<PhanTu>();
            foreach (PhanTu pt in phanTus)
            {
                bool isExist = false;
                linkedList.Traverse(s => 
                    { 
                        if (pt.getSoMu() == s.getSoMu()) {
                            isExist = true;
                            s.setHeSo(s.getHeSo() + pt.getHeSo());
                        }
                    });
                if (!isExist)
                {
                    linkedList.Add(pt);
                }
            }
            return resultLinkList();
        }

        public String resultHashTable()
        {
            String s = "";
            for (int i = 0; i < hashTable.keys.Count; i++)
            {
                PhanTu phanTu = (PhanTu)hashTable.Get(hashTable.keys[i]);
                if(i > 0 && phanTu.getHeSo() >= 0)
                {
                    s += "+";
                }
                if(phanTu.getSoMu() != 0)
                {
                    s += phanTu.getHeSo() + "x^" + phanTu.getSoMu();
                }
                else
                {
                    s += phanTu.getHeSo();
                }
                if (parent is ILog)
                {
                    ((ILog)parent).log("HashItem: " + phanTu);
                }
            }
            return s;
        }

        public String resultLinkList()
        {
            String s = "";
            int i = 0;
            linkedList.Traverse(phanTu =>
            {
                if (i > 0 && phanTu.getHeSo() >= 0)
                {
                    s += "+";
                }
                if (phanTu.getSoMu() != 0)
                {
                    s += phanTu.getHeSo() + "x^" + phanTu.getSoMu();
                }
                else
                {
                    s += phanTu.getHeSo();
                }
                if (parent is ILog)
                {
                    ((ILog)parent).log("Linklist note: " + phanTu);
                }
                i++;
            });
            return s;
        }
    }
}
