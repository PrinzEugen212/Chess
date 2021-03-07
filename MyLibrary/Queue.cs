using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary
{
    public class Queue<T>
    {
        private T[] _array;
        private int _capacity;
        private int _indexStart, _indexEnd;

        
        public Queue(int capacity = 4)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _indexEnd = -1;
            _indexStart = -1;
        }

        public void Add(T el)
        {
            if (_indexStart == -1)
            {
                _indexStart = 0;
                _indexEnd = 0;
            }
            else
            {
                if (_indexEnd + 1 == _indexStart)
                {
                    throw new Exception("Очередь переполнена");
                }
                _indexEnd++;
            }

            if (_indexEnd == _array.Length-1)
                if (_indexStart != 0)
                    _indexEnd = 0;

            _array[_indexEnd] = el;


        }

        public T Get()
        {
            if (_indexEnd == -1 || _indexStart == -1)
            {
                throw new Exception("Пустая очередь");
            }

            T value = _array[_indexStart];
            if (_indexStart == _indexEnd)
            {
                _indexEnd = -1;
                _indexStart = -1;
                return value;
            }

            _indexStart++;
            return value;
        }
    }
}
