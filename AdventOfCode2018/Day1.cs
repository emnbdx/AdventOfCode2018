using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day1 : AbstractDay
    {
        private readonly List<int> _oldFrequency = new List<int>();

        public Day1() : base(1)
        { }


        public override string Part1()
        {
            return Data.Select(int.Parse).Sum().ToString();
        }

        public override string Part2()
        {
            _oldFrequency.Add(0);
            return GetDouble();
        }

        private string GetDouble(int count = 0)
        {
            while(true)
            {
                foreach (var i in Data.Select(int.Parse))
                {
                    count += i;
                    if (_oldFrequency.Contains(count))
                    {
                        return count.ToString();
                    }

                    _oldFrequency.Add(count);
                }
            }
        }
    }
}