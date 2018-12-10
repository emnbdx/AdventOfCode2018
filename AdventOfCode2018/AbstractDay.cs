using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public abstract class AbstractDay
    {
        internal int DayCount;
        internal List<string> data = new List<string>();

        internal AbstractDay(int dayCount)
        {
            DayCount = dayCount;
            data = File.ReadAllLines(Path.Combine("data", $"day{dayCount}")).ToList();
        }

        public void Compute()
        {
            Console.WriteLine($"Day {DayCount} part 1 result: {Part1()}");
            Console.WriteLine($"Day {DayCount} part 2 result: {Part2()}");
        }

        public abstract string Part1();

        public abstract string Part2();
    }
}
