using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day3 : AbstractDay
    {
        public List<Rectangle> Rectangles;

        public Day3() : base(3)
        {
            Rectangles = Data.Select(_ => new Rectangle(_)).ToList();
        }

        public override string Part1()
        {
            var array = DrawRectangles();

            return CountOverlap(array).ToString();
        }

        public override string Part2()
        {
            var array = DrawRectangles();

            foreach (var rectangle in Rectangles)
            {
                var overlap = false;
                for (var x = 0; x < rectangle.W; x++)
                {
                    for (var y = 0; y < rectangle.H; y++)
                    {
                        if(array[rectangle.X + x, rectangle.Y + y] > 1)
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
            foreach (var rectangle in Rectangles)
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
            var lineParts = line.Split(' ');
            Id = int.Parse(lineParts[0].Replace("#", ""));
            var xy = lineParts[2].Replace(":", "").Split(',');
            X = int.Parse(xy[0]);
            Y = int.Parse(xy[1]);
            var wh = lineParts[3].Split('x');
            W = int.Parse(wh[0]);
            H = int.Parse(wh[1]);
        }
    }
}
