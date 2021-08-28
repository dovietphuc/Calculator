using System;
using System.Collections.Generic;
using System.Text;

public class HashTable
{
    class HashTable
    {
        const int ARR_SIZE = 20;

        private static LinkedList<HashItem>[] array1 = new LinkedList<HashItem>[ARR_SIZE];

        public List<Object> keys = new List<Object>();

        class HashItem
        {
            public Object value;
            public Object key;

            public Object Value
            {
                get
                {
                    return value;
                }
                set
                {
                    this.value = value;
                }
            }

            public Object Key
            {
                get
                {
                    return key;
                }
                set
                {
                    this.key = value;
                }
            }
        }

        public static long Hash(Object value)
        {
            return ConvertStringToInt(value.ToString()) % ARR_SIZE;
        }

        public void Add(object key, object value)
        {
            long hashIndex = Hash(key);

            HashItem hashItem = new HashItem();
            hashItem.value = value;
            hashItem.key = key;

            if (!keys.Contains(key))
            {
                keys.Add(key);
            }

            if (array1[hashIndex] != null)
            {
                LinkedListNode<HashItem> node = GetNode(key);

                if (node != null)
                {
                    node.Value.value = value;
                }
                else
                {
                    array1[hashIndex].AddLast(hashItem);
                }

            }
            else
            {
                LinkedList<HashItem> item = new LinkedList<HashItem>();
                item.AddLast(hashItem);
                array1[hashIndex] = item;
            }

        }

        public Object Get(Object key)
        {
            long hashIndex = Hash(key);
            if (array1[hashIndex] != null)
            {
                LinkedListNode<HashItem> node = array1[hashIndex].First;

                while (node != null)
                {
                    if (node.Value.key.Equals(key))

                    {
                        return node.Value.value;
                    }

                    node = node.Next;
                }

            }
            return null;
        }

        private void UpdateNode(LinkedListNode<HashItem> node, Object value)
        {
            if (node != null)
            {
                node.Value.value = value;
            }
        }

        private LinkedListNode<HashItem> GetNode(Object key)
        {
            long hashIndex = Hash(key);
            if (array1[hashIndex] != null)
            {
                LinkedListNode<HashItem> node = array1[hashIndex].First;

                while (node != null)
                {
                    if (node.Value.key.Equals(key))

                    {

                        return node;
                    }

                    node = node.Next;
                }

            }
            return null;
        }


        public static long ConvertStringToInt(string s)
        {
            long result = 0;
            byte[] arr = Encoding.UTF8.GetBytes(s);

            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
                if (i != (arr.Length - 1))
                    result *= 10;
            }
            return result;
        }

        public bool IsExist(Object key)
        {
            return Get(key) != null;
        }



    }
}
