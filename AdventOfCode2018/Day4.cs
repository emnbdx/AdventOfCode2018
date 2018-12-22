using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day4 : AbstractDay
    {
        private Dictionary<int, Guard> _guards;
        private static readonly Regex LineRegex = new Regex(@"\[(\d+-\d+-\d+\s\d+:\d+)\]\s(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex IdREegex = new Regex(@"Guard\s#(\d+)\s.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public Day4() : base(4)
        {
            Dictionary<DateTime, string> comportements = new Dictionary<DateTime, string>();
            foreach(var line in Data)
            {
                var result = LineRegex.Match(line);

                comportements.Add(DateTime.ParseExact(result.Groups[1].Value, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), result.Groups[2].Value.Trim());
            }

            InitGuard(comportements);
        }

        public override string Part1()
        {
            var sleepyBoy = _guards.Values.OrderByDescending(_ => _.SleepTime).First();
            var favoriteMinute = sleepyBoy.GetFavoriteMinute().minute;

            return (sleepyBoy.Id * favoriteMinute).ToString();
        }

        public override string Part2()
        {
            var sleepyBoy = _guards.Values.OrderByDescending(_ => _.GetFavoriteMinute().count).First();
            var favoriteMinute = sleepyBoy.GetFavoriteMinute().minute;

            return (sleepyBoy.Id * favoriteMinute).ToString();
        }

        private void InitGuard(Dictionary<DateTime, string> comportements)
        {
            _guards = new Dictionary<int, Guard>();
            var currentId = 0;
            var startDate = DateTime.MinValue;
            foreach (var comportement in comportements.OrderBy(_ => _.Key))
            {
                var match = IdREegex.Match(comportement.Value);

                if (match.Success)
                {
                    currentId = int.Parse(match.Groups[1].Value);

                    if (!_guards.ContainsKey(currentId))
                    {
                        _guards.Add(currentId, new Guard(currentId));
                    }
                }

                if (comportement.Value == "falls asleep")
                {
                    startDate = comportement.Key;
                    continue;
                }

                if (comportement.Value == "wakes up")
                {
                    var endDate = comportement.Key;

                    _guards[currentId].AddSleepPeriod(startDate, endDate);
                }
            }
        }
    }

    public class Guard
    {
        public int Id { get; }
        public int SleepTime { get; private set; }
        public List<SleepPeriod> SleepPeriods { get; }

        public Guard(int id)
        {
            Id = id;
            SleepTime = 0;
            SleepPeriods = new List<SleepPeriod>();
        }

        public void AddSleepPeriod(DateTime startDate, DateTime endDate)
        {
            SleepPeriods.Add(new SleepPeriod(startDate, endDate));
            SleepTime += (endDate - startDate).Minutes;
        }

        public (int minute, int count) GetFavoriteMinute()
        {
            var minutes = new int[60];
            foreach(var sleepPeriod in SleepPeriods)
            {
                var tempDate = sleepPeriod.StartDate;
                while(tempDate < sleepPeriod.EndDate)
                {
                    minutes[tempDate.Minute]++;
                    tempDate = tempDate.AddMinutes(1);
                }

            }

            int maxValue = minutes.Max();
            return (minutes.ToList().IndexOf(maxValue), maxValue);
        }
    }

    public class SleepPeriod
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SleepPeriod(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
