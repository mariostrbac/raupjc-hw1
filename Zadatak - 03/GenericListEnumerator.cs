using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak___03
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> _list;
        private T current;
        private int index;

        public GenericListEnumerator(GenericList<T> genericList)
        {
            if (genericList != null)
            {
                _list = genericList;
                current = default(T);
                index = -1;
            }
        }

        public void Dispose(){ }

        public bool MoveNext()
        {
            if (++index < _list.Count)
            {
                current = _list.GetElement(index);
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public T Current
        {
            get { return current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
