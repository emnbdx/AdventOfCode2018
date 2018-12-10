using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day3 : AbstractDay
    {
        public List<Rectangle> Rectangles = new List<Rectangle>();

        public Day3() : base(3)
        {
            Rectangles = data.Select(_ => new Rectangle(_)).ToList();
        }

        public override string Part1()
        {
            var area = 0;
            foreach(var rectangle in Rectangles)
            {
                area += rectangle.W * rectangle.H;
            }

            return ((1000 * 1000) - area).ToString();
        }

        public override string Part2()
        {
            throw new NotImplementedException();
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
