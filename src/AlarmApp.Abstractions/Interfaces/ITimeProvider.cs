using AlarmApp.Abstractions.Enums;

namespace AlarmApp.Abstractions.Interfaces;

// Pattern: Adapter abstracting system clock access for testability.
public interface ITimeProvider
{
    // Returns the current wall-clock date and time.
    DateTime GetCurrentDateTime();

    // Returns the current weekday in the application's domain representation.
    AlarmWeekday GetCurrentWeekday();
}
