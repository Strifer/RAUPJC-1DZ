using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DZ
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int count;

        public IntegerList()
        {
            _internalStorage = new int[4];
            count = 0;
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(int item)
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
            int[] newStorage = new int[_internalStorage.Length*2];
            for (int i=0; i<_internalStorage.Length; i++)
            {
                newStorage[i] = _internalStorage[i];
            }
            this._internalStorage = newStorage;
        }

        public void Clear()
        {
            _internalStorage = new int[_internalStorage.Length];
            count = 0;
        }

        public bool Contains(int item)
        {
            foreach (int i in _internalStorage)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index < 0 || index > count )
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i<_internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(int item)
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index >= count || index < 0 )
            {
                return false;
            }

            for (int i=index; i<_internalStorage.Length-1; i++)
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
            for (int i = 0; i<count-1; i++)
            {
                sb.Append(_internalStorage[i] + ", ");
            }
            sb.Append(_internalStorage[count-1] + "]");
            return sb.ToString();
        }

        
    }
}
