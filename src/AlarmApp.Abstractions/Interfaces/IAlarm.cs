using AlarmApp.Abstractions.Enums;
using AlarmApp.Abstractions.Models;

namespace AlarmApp.Abstractions.Interfaces;

// Pattern: DDD Aggregate Root interface representing a single alarm entity.
public interface IAlarm
{
    // Provides the unique identifier assigned to the alarm instance.
    Guid Id { get; }

    // Gets or sets the time-of-day when the alarm should ring.
    TimeOnly TimeOfDay { get; set; }

    // Gets or sets the name shown while the alarm is ringing; defaults to "Alarm" when null or empty.
    AlarmLabel? AlarmName { get; set; }

    // Gets or sets the default snooze period used when user accepts the standard snooze action.
    SnoozeDurationOption SnoozeDuration { get; set; }

    // Gets or sets the identifier of the ringtone to play when the alarm fires.
    RingtoneIdentifier RingtoneId { get; set; }

    // Gets or sets the repeat configuration controlling how the alarm behaves across days.
    AlarmRepeatConfiguration RepeatConfiguration { get; set; }

    // Indicates whether the alarm is currently enabled for scheduling.
    bool IsEnabled { get; }

    // Reports the runtime state of the alarm (enabled, ringing, snoozed, etc.).
    AlarmExecutionState ExecutionState { get; }

    // Returns the next date and time this alarm is expected to ring, or null if unscheduled.
    DateTime? NextScheduledOccurrence { get; }

    // Turns the alarm on so that it will be scheduled according to its repeat configuration.
    Task EnableAsync();

    // Turns the alarm off until the user manually enables it again.
    Task DisableAsync();

    // Marks the alarm as turned off for the remainder of the current day without altering future occurrences.
    Task DisableForTodayAsync();

    // Resets the daily execution state so the alarm can ring on its next scheduled day after being turned off for today.
    Task ResetDailyStateAsync();
}
