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
    }
}
