using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary.Tree
{
    class Tree<T> where T : IComparable<T>
    {

        Node<T> Root;

        public void Add(T data)
        {

            Node<T> node = Root;
            Node<T> nodeToAdd = new Node<T>(data);

            while (true)
            {
                if (node._data.CompareTo(data) < 0)
                {
                    if (node.childLeft == null)
                    {
                        node.childLeft = nodeToAdd;
                        break;
                    }
                    node = node.childLeft;
                }
                else
                {
                    if (node.childRight == null)
                    {
                        node.childRight = nodeToAdd;
                        break;
                    }
                    node = node.childRight;
                }
            }
        }

        public bool Contains(T data)
        {
            Node<T> node = Root;

            while (node._data.CompareTo(data) != 0)
            {
                if (node._data.CompareTo(data) < 0)
                {
                    node = node.childLeft;
                }
                else
                {
                    node = node.childRight;
                }

                if (node == null)
                {
                    return false;
                }
            }
            return true;

        }

        public void Delete(T data)
        {
            Node<T> node = Root;
            Node<T> parent = null;
            bool isLeftChild = false;
            while (node._data.CompareTo(data) != 0)
            {
                if (node._data.CompareTo(data) < 0)
                {
                    parent = node;
                    node = node.childLeft;
                    isLeftChild = true;
                }
                else
                {
                    parent = node;
                    node = node.childRight;
                    isLeftChild = false;
                }
                if (node == null)
                {
                    break;
                }
            }

            if (node.childLeft == null && node.childRight == null)
            {
                if (node == Root)
                {
                    Root = null; return;
                }

                if (isLeftChild)
                {
                    parent.childLeft = null; 
                }
                else
                {
                    parent.childRight = null; 
                }
            }

            else if (node.childLeft == null)
            {
                if (isLeftChild)
                {
                    parent.childLeft = node.childRight;
                }
                else
                {
                    parent.childRight = node.childRight;
                }
            }
            else if (node.childRight == null)
            {
                if (isLeftChild)
                {
                    parent.childLeft = node.childLeft;
                }
                else
                {
                    parent.childRight = node.childLeft;
                }
            }
            else
            {
                Node<T> r = searchLeft(node);
                if (isLeftChild)
                {
                    parent.childLeft = r;
                    r.childLeft = node.childLeft;
                    r.childRight = node.childRight;
                }
                else
                {
                    parent.childRight = r;
                    r.childLeft = node.childLeft;
                    r.childRight = node.childRight;
                }
            }


        }

        public void GetAll()
        {
            InOrder(Root);
        }

        private Node<T> searchLeft(Node<T> node)
        {
            node = node.childRight;
            Node<T> parent = null;
            while(node.childLeft != null)
            {
                parent = node;
                node = node.childLeft;
            }

            parent.childLeft = node.childRight;
            return node;
        }

        private void InOrder(Node<T> node)
        {
            if (node != null)
            {
                InOrder(node.childLeft);
                Console.WriteLine(node._data);
                InOrder(node.childRight);
            }
        }
    }
}
