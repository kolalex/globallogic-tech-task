using AlarmApp.Abstractions;

namespace AlarmApp.Implementation.Alarms;

internal sealed class Alarm : IAlarm
{
    private bool _isEnabled;
    private AlarmExecutionState _executionState;
    private DateTime? _nextScheduledOccurrence;

    public Alarm(Guid id, AlarmConfiguration configuration)
    {
        Id = id;
        TimeOfDay = configuration.TimeOfDay;
        AlarmName = configuration.AlarmName;
        SnoozeDuration = configuration.SnoozeDuration;
        RingtoneId = configuration.RingtoneId;
        RepeatConfiguration = configuration.RepeatConfiguration;
        _isEnabled = true;
        _executionState = AlarmExecutionState.Enabled;
    }

    public Guid Id { get; }

    public TimeOnly TimeOfDay { get; set; }

    public AlarmLabel? AlarmName { get; set; }

    public SnoozeDurationOption SnoozeDuration { get; set; }

    public RingtoneIdentifier RingtoneId { get; set; }

    public AlarmRepeatConfiguration RepeatConfiguration { get; set; }

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
