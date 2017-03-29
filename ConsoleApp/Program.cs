using System;
using System.Collections.Generic;
using DataStructures.ArrayBasedVector;
using DSAlgorithms;

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
            var array = new[] { 19, 5, 17, 20, 14, 13 };
            var x = HomelessAlgorithms.ComputeDifferenceArray(array);
            foreach (var a in x)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("");
            var t = HomelessAlgorithms.Profits(array);

            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
