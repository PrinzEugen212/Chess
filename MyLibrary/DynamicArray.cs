using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary
{
    public class DynamicArray<T>
    {
        private T[] data;
        private int capacity = 4;
        private int index = -1;

        public DynamicArray()
        {
            data = new T[capacity];
        }

        public DynamicArray(int cap)
        {
            if (cap > 0)
            {
                capacity = cap;
                data = new T[capacity];
            }
        }
        public DynamicArray(T[] array)
        {
            capacity = array.Length;
            data = array;

        }

        public int Count()
        {
            return index;
        }

        public void Add(T value)
        {
            index++;
            if (index == capacity)
            {
                capacity *= 2;
                T[] data1 = new T[capacity];
                for (int i = 0; i < data.Length; i++)
                {
                    data1[i] = data[i];
                }
                data = data1;
            }
            data[index] = value;
        }

        public void Remove(T value)
        {
            int findedIndex = -1;
            for (int i = 0; i < index; i++)
            {
                if (data[i].Equals(value))
                {
                    findedIndex = i;
                    break;
                }
            }
            if (findedIndex < 0)
            {
                throw new Exception("Объект не найден");
            }
            Remove(findedIndex);
        }

        public void Remove(int indexForRemove)
        {
            CheckIndex(indexForRemove);
            for (int i = indexForRemove; i < index; i++)
            {
                data[i] = data[i + 1];
            }
            index--;
        }

        public T Get(int indexForReturn)
        {
            CheckIndex(indexForReturn);
            return data[indexForReturn];
        }

        public void Set(T value, int indexForSet)
        {
            CheckIndex(indexForSet);
            data[indexForSet] = value;
        }

        private void CheckIndex(int indexForCheck)
        {
            if (indexForCheck < 0 || indexForCheck > index)
            {
                throw new Exception("Неверный индекс");
            }
        }
    }
}
