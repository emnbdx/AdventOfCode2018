using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day1 : IDay
    {
        public List<int> data = new List<int>();
        private List<int> oldFrequency = new List<int>();

        public Day1()
        {
            data = File.ReadAllLines("data/day1").Select(_ => int.Parse(_)).ToList();
        }

        public string Part1()
        {
            return data.Sum().ToString();
        }

        public string Part2()
        {
            oldFrequency.Add(0);
            return GetDouble();
        }

        private string GetDouble(int count = 0)
        {
            foreach (var i in data)
            {
                count += i;
                if (oldFrequency.Contains(count))
                {
                    return count.ToString();
                }

                oldFrequency.Add(count);
            }

            return GetDouble(count);
        }
    }
}