using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CongestionTaxCalculator.Infrastructure
{
    //https://code-maze.com/csharp-map-dateonly-timeonly-types-to-sql/
    public class TimeUtils
    { 
        public static List<DateTime> sortDateDesc(List<DateTime> datetimes)
        {
            return datetimes.OrderBy(x => x.Date).ThenBy(t => t.TimeOfDay).ToList();
        }
    }


    public class TimeRange
    {
        public TimeOnly Start { get; private set; }
        public TimeOnly End { get; private set; }

        public TimeRange(TimeOnly start, TimeOnly end)
        {
            Start = start;
            End = end;
        }

        public bool Overlap(TimeRange range)
        {
            return Start < range.End && End > range.Start;
        }

        public bool InRange(TimeOnly time)
        {
            return Start <= time && time<End;
        }

    }

}