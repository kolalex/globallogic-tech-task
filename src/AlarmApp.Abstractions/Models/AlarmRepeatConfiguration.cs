using System;

namespace AlarmApp.Abstractions;

// Pattern: Value Object ensuring repeat rules stay internally consistent.
public sealed record class AlarmRepeatConfiguration
{
    private AlarmRepeatConfiguration(AlarmRepeatMode mode, AlarmWeekday daysOfWeek)
    {
        Mode = mode;
        DaysOfWeek = daysOfWeek;
    }

    public AlarmRepeatMode Mode { get; }

    public AlarmWeekday DaysOfWeek { get; }

    public static AlarmRepeatConfiguration OnlyForToday() => new(AlarmRepeatMode.OnlyForToday, AlarmWeekday.None);

    public static AlarmRepeatConfiguration ForDaysOfWeek(AlarmWeekday daysOfWeek)
    {
        if (daysOfWeek == AlarmWeekday.None)
        {
            throw new ArgumentException("At least one weekday must be selected for a weekly repeat.", nameof(daysOfWeek));
        }

        return new AlarmRepeatConfiguration(AlarmRepeatMode.DaysOfWeek, daysOfWeek);
    }
}
