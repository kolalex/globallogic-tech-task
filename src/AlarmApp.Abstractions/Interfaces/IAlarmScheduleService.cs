using System;

namespace AlarmApp.Abstractions;

// Pattern: Strategy for computing alarm trigger and notification times.
public interface IAlarmScheduleService
{
    // Calculates the next time the specified alarm should ring based on the provided reference time.
    DateTime? GetNextTriggerTime(IAlarm alarm, DateTime referenceTime);

    // Calculates the time 30 minutes prior to the next trigger when a pre-notification should be raised.
    DateTime? GetPreNotificationTime(IAlarm alarm, DateTime referenceTime);
}
