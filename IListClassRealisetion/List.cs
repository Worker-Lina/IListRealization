using System;
using System.Collections;
using System.Collections.Generic;


namespace IListClassRealisetion
{
    public class List : IList
    {
        private object[] _list;
        private int _count = 0;

        public object this[int index]
        {
            get
            {
                return _list[index];
            }
            set 
            {
                _list[index] = value;
            }
        }

        public bool IsFixedSize { get { return false; } }

        public bool IsReadOnly { get { return false; } }

        public int Count { get { return _count; } }

        public bool IsSynchronized { get { return false; } }

        public object SyncRoot { get { return this; } }

        public int Add(object value)
        {
            object[] newList = new object[_count + 1];
            for(int i = 0; i < _count; i++)
            {
                newList[i] = _list[i];
            }
            newList[_count] = value;
            _count++;
            _list = null;
            _list = newList;
            return _count - 1;
         
        }

        public void Clear()
        {
            _list = null;
            _count = 0;
        }

        public bool Contains(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_list[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_list[i], index++);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_list[i] == value)
                {
                    return i;
                }              
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if ((_count + 1 <= _list.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _list[i] = _list[i - 1];
                }
                _list[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _list[i] = _list[i + 1];
                }
                _count--;
            }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }
    }
}
