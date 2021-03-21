using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary.Tree
{
    public class Node<T>
    {
        public T _data { get; private set; }

        public Node<T> childLeft, childRight;

        public Node (T data)
        {
            _data = data;
        }
    }
}
