using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }

    public class TwoLinkedList<T>
    {
        Node<T> first;
        Node<T> last;
        int index { get; set; }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (first == null)
            {
                first = node;
            }
            else
            {
                last.Next = node;
                node.Previous = last;
            }
            last = node;
            index++;
        }
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> t = first;
            node.Next = t;
            first = node;
            index++;
        }
        public void Remove(T data)
        {
            Node<T> current = first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                last = current.Previous;
            }

            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                first = current.Next;
            }
            index--;
        }
    }
}
