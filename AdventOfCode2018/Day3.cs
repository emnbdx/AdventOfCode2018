using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day3 : AbstractDay
    {
        private readonly List<Rectangle> _rectangles;
        private static Regex Regex = new Regex(@"#(\d+)\s@\s(\d+),(\d+):\s(\d+)x(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public Day3() : base(3)
        {
            _rectangles = Data.Select(_ => new Rectangle(_)).ToList();
        }

        public override string Part1()
        {
            var array = DrawRectangles();

            return CountOverlap(array).ToString();
        }

        public override string Part2()
        {
            var array = DrawRectangles();

            foreach (var rectangle in _rectangles)
            {
                var overlap = false;
                for (var x = 0; x < rectangle.W; x++)
                {
                    for (var y = 0; y < rectangle.H; y++)
                    {
                        if (array[rectangle.X + x, rectangle.Y + y] > 1)
                        {
                            overlap = true;
                        }
                    }
                }

                if (!overlap)
                    return rectangle.Id.ToString();
            }

            return null;
        }

        private int[,] DrawRectangles()
        {
            var array = new int[1000, 1000];
            foreach (var rectangle in _rectangles)
            {
                for (var x = 0; x < rectangle.W; x++)
                {
                    for (var y = 0; y < rectangle.H; y++)
                    {
                        array[rectangle.X + x, rectangle.Y + y]++;
                    }
                }
            }

            return array;
        }

        private int CountOverlap(int[,] array)
        {
            var overlap = 0;
            for (var x = 0; x < 1000; x++)
            {
                for (var y = 0; y < 1000; y++)
                {
                    if (array[x, y] > 1)
                    {
                        overlap++;
                    }
                }
            }

            return overlap;
        }

        public class Rectangle
        {
            public int Id { get; }
            public int X { get; }
            public int Y { get; }
            public int W { get; }
            public int H { get; }

            public Rectangle(string line)
            {
                var result = Regex.Match(line);
                Id = int.Parse(result.Groups[1].Value);
                X = int.Parse(result.Groups[2].Value);
                Y = int.Parse(result.Groups[3].Value);
                W = int.Parse(result.Groups[4].Value);
                H = int.Parse(result.Groups[5].Value);
            }
        }
    }
}
