using System;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main()
        {
            var day1 = new Day1();
            Console.WriteLine(day1.Part1());
            Console.WriteLine(day1.Part2());

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
