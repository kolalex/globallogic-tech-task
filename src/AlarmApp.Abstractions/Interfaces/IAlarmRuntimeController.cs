using System;

namespace AlarmApp.Abstractions;

// Pattern: Command Handler coordinating runtime actions on alarms.
public interface IAlarmRuntimeController
{
    // Invoked when an alarm should start ringing so the controller can update state and notify listeners.
    void BeginAlarm(AlarmTriggerContext context);

    // Invoked when the user stops a ringing alarm; controller should apply repeat semantics and stop playback.
    void StopAlarm(Guid alarmId);

    // Invoked when the user snoozes a ringing alarm, optionally overriding the default duration for this instance.
    void SnoozeAlarm(Guid alarmId, TimeSpan? overrideSnoozeDuration);

    // Invoked when the user dismisses the pre-alarm notification before the alarm starts ringing.
    void DismissBeforeTrigger(Guid alarmId);
}
