using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DZ
{
    class MainClass
    {
        static void Main(string[] args)
        {
            IIntegerList list = new IntegerList();
            list.Add(1);
            Console.WriteLine(list);
            list.Add(2);
            Console.WriteLine(list);
            list.Add(3);
            Console.WriteLine(list);
            list.Add(4);
            Console.WriteLine(list);
            list.Add(5);
            Console.WriteLine(list);

            list.RemoveAt(0);
            Console.WriteLine(list);
            list.Remove(5);
            Console.WriteLine(list);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Remove(100));
            Console.WriteLine(list.RemoveAt(5));
            list.Clear();
            Console.WriteLine(list);
            Console.WriteLine(list.Count);
            Console.ReadKey();
        }

    }
}
