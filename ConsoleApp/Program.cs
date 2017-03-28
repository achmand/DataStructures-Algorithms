using System;
using System.Collections.Generic;
using DataStructures.ArrayBasedVector;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var abv = new SfArrayBasedVector<int>();
            //abv.InsertFirst(23);
            //abv.InsertFirst(3);
            //abv.InsertFirst(4);
            //abv.InsertFirst(9);
            //abv.InsertLast(5);
            //abv.InsertLast(18);

            //var str =
            //    $"{abv.ElementAtRank(0)} {abv.ElementAtRank(1)} {abv.ElementAtRank(2)} {abv.ElementAtRank(3)} {abv.ElementAtRank(4)} {abv.ElementAtRank(5)}";
            //Console.WriteLine(str);
            //Console.ReadKey();
           
            LinkedList<int> ln = new LinkedList<int>();
            ln.AddFirst(2);
            ln.AddFirst(4);
            Console.WriteLine(ln.Count);
            Console.ReadKey();
        }
    }
}
