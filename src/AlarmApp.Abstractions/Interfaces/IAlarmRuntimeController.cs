namespace AlarmApp.Abstractions;

// Pattern: Command Handler coordinating runtime actions on alarms.
public interface IAlarmRuntimeController
{
    // Invoked when an alarm should start ringing so the controller can update state and notify listeners.
    Task BeginAlarmAsync(AlarmTriggerContext context);

    // Invoked when the user stops a ringing alarm; controller should apply repeat semantics and stop playback.
    Task StopAlarmAsync(Guid alarmId);

    // Invoked when the user snoozes a ringing alarm, optionally overriding the default duration for this instance.
    Task SnoozeAlarmAsync(Guid alarmId, TimeSpan? overrideSnoozeDuration);

    // Invoked when the user dismisses the pre-alarm notification before the alarm starts ringing.
    Task DismissBeforeTriggerAsync(Guid alarmId);
}
