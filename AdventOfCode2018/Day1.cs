using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day1 : AbstractDay
    {
        private readonly List<int> oldFrequency = new List<int>();

        public Day1() : base(1)
        { }


        public override string Part1()
        {
            return data.Select(_ => int.Parse(_)).Sum().ToString();
        }

        public override string Part2()
        {
            oldFrequency.Add(0);
            return GetDouble();
        }

        private string GetDouble(int count = 0)
        {
            while(true)
            {
                foreach (var i in data.Select(_ => int.Parse(_)))
                {
                    count += i;
                    if (oldFrequency.Contains(count))
                    {
                        return count.ToString();
                    }

                    oldFrequency.Add(count);
                }
            }
        }
    }
}