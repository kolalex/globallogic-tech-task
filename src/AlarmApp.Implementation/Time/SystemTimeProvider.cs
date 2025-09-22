using AlarmApp.Abstractions;

namespace AlarmApp.Implementation.Time;

internal sealed class SystemTimeProvider : ITimeProvider
{
    public DateTime GetCurrentDateTime()
    {
        // TODO: Bridge to platform-specific clock source if higher precision is required.
        return DateTime.UtcNow;
    }

    public AlarmWeekday GetCurrentWeekday()
    {
        // TODO: Respect locale-specific first-day-of-week rules if needed.
        return DateTime.UtcNow.DayOfWeek switch
        {
            DayOfWeek.Monday => AlarmWeekday.Monday,
            DayOfWeek.Tuesday => AlarmWeekday.Tuesday,
            DayOfWeek.Wednesday => AlarmWeekday.Wednesday,
            DayOfWeek.Thursday => AlarmWeekday.Thursday,
            DayOfWeek.Friday => AlarmWeekday.Friday,
            DayOfWeek.Saturday => AlarmWeekday.Saturday,
            DayOfWeek.Sunday => AlarmWeekday.Sunday,
            _ => AlarmWeekday.None
        };
    }
}
