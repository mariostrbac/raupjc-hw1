using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class GenericList<X> : IEnumerable
    {
            private X[] _internalStorage;
            private int index;

            public GenericList()
            {
                _internalStorage = new X[4];
                index = 0;
            }

            public GenericList(int initialSize)
            {
                if (initialSize < 0)
                    initialSize = (-1) * initialSize;

                _internalStorage = new X[initialSize];
                index = 0;
            }


            public IEnumerator<X> GetEnumerator()
            {
                return new GenericListEnumerator<X>(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(X item)
            {
                if (item != null)
                {
                    if (index == _internalStorage.Length)
                    {
                        X[] _internalStorageTemp = new X[2 * index];

                        for (int i = 0; i < index; i++)
                        {
                            _internalStorageTemp[i] = _internalStorage[i];
                        }

                        _internalStorageTemp[index++] = item;
                        _internalStorage = _internalStorageTemp;
                    }
                    else
                    {
                        _internalStorage[index++] = item;
                    }
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
                        _internalStorage[j] = default(X);
                    }
                }
                index--;
            }

            public bool Remove(X item)
            {
                if (item != null)
                {
                    for (int i = 0; i < index; i++)
                    {
                        if (_internalStorage[i].Equals(item))
                        {
                            return RemoveAt(i);
                        }
                    }
                }
                return false;
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

            public X GetElement(int index)
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
                    return default(X);
                }

                return _internalStorage[index];
            }

            public int IndexOf(X item)
            {
                if (item != null)
                {
                    for (int i = 0; i < _internalStorage.Length; i++)
                    {
                        if (_internalStorage[i].Equals(item))
                            return i;
                    }
                }
                return -1;
            }

            public int Count
            {
                get { return index; }
            }

            public void Clear()
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                    _internalStorage[i] = default(X);

                index = 0;
            }

            public bool Contains(X item)
            {
                if (item != null)
                {
                    for (int i = 0; i < _internalStorage.Length; i++)               // if(IndexOf(item) != -1) return true; else return false;
                    {
                        if (_internalStorage[i].Equals(item))
                            return true;
                    }
                }
                return false;
            }
        }
}
