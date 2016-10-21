using _2Zadatak;
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
            IGenericList<string> list = new GenericList<string>();
            list.Add("jedan");
            Console.WriteLine(list);
            list.Add("dva");
            Console.WriteLine(list);
            list.Add("tri");
            Console.WriteLine(list);
            list.Add("četiri");
            Console.WriteLine(list);
            list.Add("pet");
            Console.WriteLine(list);

            Console.WriteLine(list.Contains("nula"));

            Console.WriteLine("Foreach test:");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }

            list.RemoveAt(0);
            Console.WriteLine(list);
            list.Remove("tri");
            Console.WriteLine(list);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Remove("ayylmao"));
            Console.WriteLine(list.RemoveAt(5));
            list.Clear();
            Console.WriteLine(list);
            Console.WriteLine(list.Count);
            Console.ReadKey();


        }

    }
}
