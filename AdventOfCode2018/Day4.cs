using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day4 : AbstractDay
    {
        private Dictionary<DateTime, string> comportements = new Dictionary<DateTime, string>();

        public Day4() : base(4)
        {
            foreach(var line in data)
            {
                var parts = line.Split(']');
                comportements.Add(DateTime.ParseExact(parts[0].Replace("[", ""), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), parts[1].Trim());
            }
        }

        public override string Part1()
        {
            var guards = new Dictionary<int, Guard>();
            foreach(var comportement in comportements.OrderBy(_ => _.Key))
            {
                if (comportement.Value.StartsWith("Guard"))
                {
                    var id = int.Parse(comportement.Value.Split(' ')[1].Replace("#", ""));

                    if (!guards.ContainsKey(id))
                    {
                        guards.Add(id, new Guard(id));
                    }
                }
            }

            return null;
        }

        public override string Part2()
        {
            throw new NotImplementedException();
        }
    }

    public class Guard
    {
        public int Id { get; }
        public int SleepTime { get; private set; }

        public Guard(int id)
        {
            Id = id;
            SleepTime = 0;
        }

        public void AddSleepTime(int time)
        {
            SleepTime += time;
        }
    }
}
