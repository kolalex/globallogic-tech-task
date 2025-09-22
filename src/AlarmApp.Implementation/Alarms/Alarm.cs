using AlarmApp.Abstractions.Enums;
using AlarmApp.Abstractions.Interfaces;
using AlarmApp.Abstractions.Models;

namespace AlarmApp.Implementation.Alarms;

internal sealed class Alarm(Guid id, AlarmConfiguration configuration) : IAlarm
{
    private bool _isEnabled = true;
    private AlarmExecutionState _executionState = AlarmExecutionState.Enabled;
    private DateTime? _nextScheduledOccurrence;

	public Guid Id { get; } = id;

	public TimeOnly TimeOfDay { get; set; } = configuration.TimeOfDay;

	public AlarmLabel? AlarmName { get; set; } = configuration.AlarmName;

	public SnoozeDurationOption SnoozeDuration { get; set; } = configuration.SnoozeDuration;

	public RingtoneIdentifier RingtoneId { get; set; } = configuration.RingtoneId;

	public AlarmRepeatConfiguration RepeatConfiguration { get; set; } = configuration.RepeatConfiguration;

	public bool IsEnabled => _isEnabled;

    public AlarmExecutionState ExecutionState => _executionState;

    public DateTime? NextScheduledOccurrence => _nextScheduledOccurrence;

    public Task EnableAsync()
    {
        // TODO: Persist the enable flag and schedule the alarm according to the next occurrence policy.
        _isEnabled = true;
        _executionState = AlarmExecutionState.Enabled;
        return Task.CompletedTask;
    }

    public Task DisableAsync()
    {
        // TODO: Cancel any pending triggers and persist the disabled state.
        _isEnabled = false;
        _executionState = AlarmExecutionState.Disabled;
        return Task.CompletedTask;
    }

    public Task DisableForTodayAsync()
    {
        // TODO: Mark the alarm as skipped for the current day without altering future schedules.
        _executionState = AlarmExecutionState.TurnedOffForToday;
        return Task.CompletedTask;
    }

    public Task ResetDailyStateAsync()
    {
        // TODO: Reset transient state at the end of the day to allow the alarm to ring again.
        if (_isEnabled)
        {
            _executionState = AlarmExecutionState.Enabled;
        }

        return Task.CompletedTask;
    }

    internal Task SetNextOccurrenceAsync(DateTime? occurrence)
    {
        // TODO: Update stored schedule information whenever the scheduler calculates a new time.
        _nextScheduledOccurrence = occurrence;
        return Task.CompletedTask;
    }
}
