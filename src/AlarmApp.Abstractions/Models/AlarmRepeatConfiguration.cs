namespace AlarmApp.Abstractions;

// Pattern: Value Object capturing repeat semantics for an alarm.
public sealed record AlarmRepeatConfiguration(AlarmRepeatMode Mode, AlarmWeekday DaysOfWeek);
