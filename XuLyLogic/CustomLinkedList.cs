using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XuLyLogic
{
    class Node<T> where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {
            Data = default;
            Next = null;
        }

        public Node(T element)
        {
            Data = element;
            Next = null;
        }
    }

    class CustomLinkedList<T> where T : IComparable
    {
        public Node<T> Header { get; set; } = new Node<T>();

        public Node<T> Find(T data)
        {
            var currentNode = Header;
            while (currentNode.Next != null && currentNode.Data?.CompareTo(data) != 0)
                currentNode = currentNode.Next;
            if (currentNode != Header)
                return currentNode;
            return null;
        }

        public Node<T> FindPrevious(T data)
        {
            var currentNode = Header;
            while ((currentNode.Next != null) && (currentNode.Next?.Data.CompareTo(data) != 0))
                currentNode = currentNode.Next;
            if (currentNode != Header) return currentNode;
            return null;
        }

        public Node<T> Insert(T data, T afterValue)
        {
            var newNode = new Node<T>(data);
            var currentNode = Find(afterValue);
            if (currentNode != null)
            {
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
                return newNode;
            }
            return null;
        }

        public Node<T> Insert(T data, Node<T> afterNode)
        {
            var newNode = new Node<T>(data)
            {
                Next = afterNode.Next
            };
            afterNode.Next = newNode;
            return newNode;
        }

        public Node<T> Add(T data)
        {
            var currentNode = Header;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            var newNode = new Node<T>(data);
            currentNode.Next = newNode;
            return newNode;
        }

        public void Remove(T data)
        {
            var previousNode = FindPrevious(data);
            if (previousNode != null)
            {
                previousNode.Next = previousNode.Next.Next;
            }
        }

        public void Traverse(Action<T> action)
        {
            var currentNode = Header;
            while (currentNode.Next != null)
            {
                action?.Invoke(currentNode.Next.Data);
                currentNode = currentNode.Next;
            }
        }

        public void Sort()
        {
            if (Header == null || Header.Next == null) return; // there is nothing to sort
            InsertionSort(Header, null);
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Header == null || Header.Next == null) return; // there is nothing to sort
            InsertionSort(Header, comparer);
        }

        private void Swap(Node<T> a, Node<T> b)
        {
            var tmp = a.Data;
            a.Data = b.Data;
            b.Data = tmp;
        }

        private void InsertionSort(Node<T> head, IComparer<T> comparer)
        {
            if (head == null || head.Next == null) return; // there is nothing to sort

            Node<T> i = head.Next;
            Node<T> j = i.Next;
            while (i != null)
            {
                j = i.Next;
                while(j != null)
                {
                    if ((comparer != null && comparer.Compare(i.Data, j.Data) > 0)
                        || (comparer == null && i.Data.CompareTo(j.Data) > 0))
                    {
                        Swap(i, j);
                    }
                    j = j.Next;
                }
                i = i.Next;
            }
        }
    }
}
