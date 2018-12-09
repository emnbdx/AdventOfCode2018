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
            throw new NotImplementedException();
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

        }
    }
}
