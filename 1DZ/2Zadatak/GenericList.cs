using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Zadatak
{
    class GenericList<X> : IGenericList <X>
    {

        private X[] _internalStorage;
        private int count;

        public GenericList()
        {
            _internalStorage = new X[2];
            count = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
            {
                throw new ArgumentException("Collection size must be a positive number.");
            }
            _internalStorage = new X[initialSize];
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(X item)
        {
            if (_internalStorage.Length == count)
            {
                IncreaseSize();
            }
            _internalStorage[count] = item;
            count++;
        }

        private void IncreaseSize()
        {
            X[] newStorage = new X[_internalStorage.Length * 2];
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                newStorage[i] = _internalStorage[i];
            }
            this._internalStorage = newStorage;
        }

        public void Clear()
        {
            _internalStorage = new X[_internalStorage.Length];
            count = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < count; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(X item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                return false;
            }

            for (int i = index; i < count - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            count--;
            return true;

        }

        override public string ToString()
        {
            if (count == 0)
            {
                return "[]";
            }
            StringBuilder sb = new StringBuilder(count + 2);
            sb.Append("[");
            for (int i = 0; i < count - 1; i++)
            {
                sb.Append(_internalStorage[i].ToString() + ", ");
            }
            sb.Append(_internalStorage[count - 1].ToString() + "]");
            return sb.ToString();
        }
    }
}
