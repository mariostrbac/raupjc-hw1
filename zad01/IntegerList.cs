using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace zad01
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int index;

        public IntegerList()
        {
            _internalStorage = new int[4];
            index = 0;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                initialSize = (-1) * initialSize;
            }
            _internalStorage = new int[initialSize];
            index = 0;
        }


        public void Add(int value)
        {
            if (index == _internalStorage.Length)
            {
                int[] _internalStorageTemp = new int[2 * index];

                for (int i = 0; i < index; i++)
                {
                    _internalStorageTemp[i] = _internalStorage[i];
                }

                _internalStorageTemp[index++] = value;
                _internalStorage = _internalStorageTemp;
            }
            else
            {
                _internalStorage[index++] = value;
            }
        }

        /// <summary>
        /// Shifting every element in array for one postion to left from given index.
        /// </summary>
        /// <param name="i"></param>
        public void SiftToLeft(int i)
        {
            for (int j = i; j < index; j++)
            {
                if (!(j + 1 == _internalStorage.Length))
                {
                    _internalStorage[j] = _internalStorage[j + 1];
                }
                else
                {
                    _internalStorage[j] = 0;
                }
            }
            index--;
        }

        public bool RemoveAt(int index)
        {
            try
            {
                if (index >= _internalStorage.Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                return false;
            }

            if (index < this.index)
            {
                SiftToLeft(index);
                return true;
            }

            return false;
            
        }

        public bool Remove(int item)
        {
            for(int i=0; i < index; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return RemoveAt(i);
                }
            }
            return false; 
        }

        public int GetElement(int index)
        {
            try
            {
                if (index >= _internalStorage.Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                return -1;
            }

            return _internalStorage[index];
        }

        public int indexOf(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                    return i;
            }
            return -1;
        }

        public void Clear()
        {
            for (int i = 0; i < _internalStorage.Length; i++)   
                _internalStorage[i] = 0;

            index = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                    return true;
            }
            return false;
        }

        public int Count
        {
            get { return index; }
        }
    }
}
