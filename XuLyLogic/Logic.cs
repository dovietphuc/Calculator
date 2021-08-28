using System;

using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic

{
    class Logic
    {

        HashTable hashTable = new HashTable();

        public void PushItem(PhanTu pt)
        {
            //int heSo = (int)hashTable.Get(pt.getSoMu());

            int heSo = pt.getHeSo();

            if (hashTable.IsExist(pt.getSoMu()))
            {
                heSo += (int)hashTable.Get(pt.getSoMu());
            }

            hashTable.Add(pt.getSoMu(), heSo);
        }

        public void ShowHashTable()
        {
            for (int i = 0; i < hashTable.keys.Count; i++)
            {
                Console.WriteLine(hashTable.Get(hashTable.keys[i]) + " " + hashTable.keys[i]);
            }
        }
    }
}
