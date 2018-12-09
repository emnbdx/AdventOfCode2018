using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public abstract class AbstractDay
    {
        internal List<string> data = new List<string>();

        internal AbstractDay(int dayCount)
        {
            data = File.ReadAllLines(Path.Combine("data", $"day{dayCount}")).ToList();

            Console.WriteLine($"Day {dayCount} part 1 result: {Part1()}");
            Console.WriteLine($"Day {dayCount} part 2 result: {Part2()}");
        }

        public abstract string Part1();

        public abstract string Part2();
    }
}
