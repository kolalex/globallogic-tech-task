namespace AlarmApp.Abstractions;

// Pattern: State indicator guiding the repeat scheduling strategy.
public enum AlarmRepeatMode
{
    OnlyForToday,
    DaysOfWeek
}
