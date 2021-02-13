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

        /// <summary>
        /// Создаётся новый массив стандартной вместимости
        /// </summary>
        public DynamicArray()
        {
            data = new T[capacity];
        }

        /// <summary>
        /// Создаётся новый массив заданной длины
        /// </summary>
        /// <param name="cap"></param>
        public DynamicArray(int cap)
        {
            if (cap > 0)
            {
                capacity = cap;
                data = new T[capacity];
            }
        }
        /// <summary>
        /// Создаётся новый массив, равный по длине и содержанию переданному массиву
        /// </summary>
        /// <param name="array"></param>
        public DynamicArray(T[] array)
        {
            capacity = array.Length;
            data = array;

        }

        /// <summary>
        /// Возвращает количество элементов в массиве
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return index;
        }

        /// <summary>
        /// Добавляет в массив элемент с переданным значением
        /// </summary>
        /// <param name="value">Значение элемента, который нужно добавить</param>
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

        /// <summary>
        /// Удаляет элемент с переданным значением из массива
        /// </summary>
        /// <param name="value">Значение элемента, который нужно удалить</param>
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

        /// <summary>
        /// Удаляет элемент с переданным индексом из массива
        /// </summary>
        /// <param name="indexForRemove">Индекс элемента, который нужно удалить</param>
        public void Remove(int indexForRemove)
        {
            CheckIndex(indexForRemove);
            for (int i = indexForRemove; i < index; i++)
            {
                data[i] = data[i + 1];
            }
            index--;
        }

        /// <summary>
        /// Возвращает значение элемента с переданным индексом
        /// </summary>
        /// <param name="indexForReturn">Индекс, значение которого нужно вернуть</param>
        /// <returns></returns>
        public T Get(int indexForReturn)
        {
            CheckIndex(indexForReturn);
            return data[indexForReturn];
        }

        /// <summary>
        /// Записывает переданное значение в элемент с переданным индексом
        /// </summary>
        /// <param name="value">Нужное значение элемента</param>
        /// <param name="indexForSet">Нужный индекс</param>
        public void Set(T value, int indexForSet)
        {
            CheckIndex(indexForSet);
            data[indexForSet] = value;
        }

        public T this[int index]
        {
            get
            {
                return data[index];
            }
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
