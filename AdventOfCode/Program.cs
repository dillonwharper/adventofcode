using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1 d1 = new Day1(@"..\..\Day1\input.txt");
            //// Part 1
            //Console.WriteLine(d1.CalculateFrequency());
            //// Part 2 ...Takes a while
            //Console.WriteLine(d1.FindDuplicateFrequency());

            //Day2 d2 = new Day2(@"..\..\Day2\input.txt");
            //// Part 1
            //Console.WriteLine(d2.CalculateCheckSum());
            //// Part 2
            //Console.WriteLine(d2.FindCorrectBoxes());

            Day3 d3 = new Day3(@"..\..\Day3\input.txt");
            // Part 1
            Console.WriteLine(d3.CalcSquareInchesMultiClaimed());
            // Part 2
            Console.WriteLine(d3.FindIDWithNoOverlap());
        }
    }
}
