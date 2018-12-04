using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day1 : IDay
    {
        private readonly List<int> _data;
        private readonly List<int> _oldFrequency = new List<int>();

        public Day1()
        {
            _data = File.ReadAllLines(Path.Combine("data", "day1")).Select(int.Parse).ToList();
        }

        public string Part1()
        {
            return _data.Sum().ToString();
        }

        public string Part2()
        {
            _oldFrequency.Add(0);
            return GetDouble();
        }

        private string GetDouble(int count = 0)
        {
            while (true)
            {
                foreach (var i in _data)
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