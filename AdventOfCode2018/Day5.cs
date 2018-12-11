using System;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day5 : AbstractDay
    {
        public Day5() : base(5)
        { }

        public override string Part1()
        {
            var polymer = Data.First();
            var reactedPolymer = string.Empty;

            while (true)
            {
                reactedPolymer = ReactPolymer(polymer);
                if (reactedPolymer == polymer)
                    break;

                polymer = reactedPolymer;
            }

            return reactedPolymer.Length.ToString();
        }

        public override string Part2()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var result = int.MaxValue;

            foreach(var letter in alphabet)
            {
                var cleanedPolymer = Data.First().Replace($"{letter}", "").Replace($"{char.ToUpper(letter)}", "");

                var reactedPolymer = string.Empty;

                while (true)
                {
                    reactedPolymer = ReactPolymer(cleanedPolymer);
                    if (reactedPolymer == cleanedPolymer)
                        break;

                    cleanedPolymer = reactedPolymer;
                }

                result = Math.Min(result, cleanedPolymer.Length);
            }

            return result.ToString();
        }

        private string ReactPolymer(string polymer)
        {
            var newLine = polymer;
            for (var i = 0; i < polymer.Length; i++)
            {
                if (i == polymer.Length - 1)
                    break;

                if (char.ToUpperInvariant(polymer[i]) == char.ToUpperInvariant(polymer[i + 1]) && polymer[i] != polymer[i + 1])
                {
                    newLine = newLine.Replace($"{polymer[i]}{polymer[i + 1]}", "");
                }
            }

            return newLine;
        }
    }
}
