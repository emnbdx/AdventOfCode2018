using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day6 : AbstractDay
    {
        private static readonly Regex Regex = new Regex(@"(\d+),\s(\d+)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly List<CustomPoint> _points;

        public Day6() : base(6)
        {
            _points = new List<CustomPoint>();

            var index = 1;
            foreach (var coordinate in Data)
            {
                var result = Regex.Match(coordinate);
                _points.Add(new CustomPoint(index++,
                    new Point(int.Parse(result.Groups[2].Value), int.Parse(result.Groups[1].Value))));
            }
        }

        public override string Part1()
        {
            var output = ComputeAllNearestDistance(400);

            var infinitePoints = GetInfinitePoints(output);

            return GetLargestArea(output, infinitePoints).ToString();
        }

        public override string Part2()
        {
            var output = ComputeAllDistance(400);

            var result = 0;
            for (var x = 0; x < Math.Sqrt(output.Length); x++)
            {
                for (var y = 0; y < Math.Sqrt(output.Length); y++)
                {
                    if (output[x, y] < 10000)
                        result++;
                }
            }

            return result.ToString();
        }

        private int[,] ComputeAllNearestDistance(int side)
        {
            var output = new int[side, side];

            for (var x = 0; x < side; x++)
            {
                for (var y = 0; y < side; y++)
                {
                    // get distance from current point to nearest
                    var currentPoint = new Point(x, y);
                    var distance = GetNearestPoint(currentPoint, _points);

                    if (_points.Any(_ => _.Point.X == x && _.Point.Y == y))
                    {
                        var id = _points.First(_ => _.Point.X == x && _.Point.Y == y).Id;
                        output[x, y] = id;
                    }
                    else
                    {
                        output[x, y] = distance == null ? '.' : distance.Id;
                    }
                }
            }

            return output;
        }

        private static CustomPoint GetNearestPoint(Point p, IEnumerable<CustomPoint> points)
        {
            var distance = new Dictionary<CustomPoint, int>();
            foreach (var point in points)
            {
                var currentDistance = Math.Abs(point.Point.X - p.X) + Math.Abs(point.Point.Y - p.Y);
                distance.Add(point, currentDistance);
            }

            var distanceGroup = distance.GroupBy(_ => _.Value).Select(_ => new { distance = _.Key, count = _.Count() })
                .ToList();
            if (distanceGroup.OrderBy(_ => _.distance).First().count == 1)
            {
                return distance.FirstOrDefault(_ =>
                    _.Value == distanceGroup.OrderBy(x => x.distance).First().distance).Key;
            }

            return null;
        }

        public List<int> GetInfinitePoints(int[,] data)
        {
            var infinites = new List<int>();
            //get infinite
            for (var x = 0; x < Math.Sqrt(data.Length); x++)
            {
                infinites.Add(data[x, 0]);
                infinites.Add(data[x, (int)Math.Sqrt(data.Length) - 1]);
            }
            for (var y = 0; y < Math.Sqrt(data.Length); y++)
            {
                infinites.Add(data[0, y]);
                infinites.Add(data[(int)Math.Sqrt(data.Length) - 1, y]);
            }

            return infinites;
        }

        private static int GetLargestArea(int[,] data, ICollection<int> infinites)
        {
            var list = new Dictionary<int, int>();
            for (var x = 1; x < Math.Sqrt(data.Length) - 1; x++)
            {
                for (var y = 1; y < Math.Sqrt(data.Length) - 1; y++)
                {
                    if (list.ContainsKey(data[x, y]))
                    {
                        list[data[x, y]]++;
                    }
                    else if (!infinites.Contains(data[x, y]))
                    {
                        list.Add(data[x, y], 1);
                    }
                }
            }

            return list.OrderByDescending(_ => _.Value).FirstOrDefault().Value;
        }


        private int[,] ComputeAllDistance(int side)
        {
            var output = new int[side, side];

            for (var x = 0; x < side; x++)
            {
                for (var y = 0; y < side; y++)
                {
                    var currentPoint = new Point(x, y);
                    output[x, y] = GetDistanceToAllPoint(currentPoint);
                }
            }

            return output;
        }

        private int GetDistanceToAllPoint(Point p)
        {
            var distance = 0;
            foreach (var point in _points)
            {
                var currentDistance = Math.Abs(point.Point.X - p.X) + Math.Abs(point.Point.Y - p.Y);
                distance += currentDistance;
            }

            return distance;
        }

        public class CustomPoint
        {
            public int Id { get; set; }
            public Point Point { get; set; }

            public CustomPoint(int id, Point point)
            {
                Id = id;
                Point = point;
            }
        }
    }
}