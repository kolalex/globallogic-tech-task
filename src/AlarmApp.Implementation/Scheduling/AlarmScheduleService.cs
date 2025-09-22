using System;
using AlarmApp.Abstractions;

namespace AlarmApp.Implementation.Scheduling;

internal sealed class AlarmScheduleService : IAlarmScheduleService
{
    private static readonly TimeSpan PreNotificationLeadTime = TimeSpan.FromMinutes(30);

    public DateTime? GetNextTriggerTime(IAlarm alarm, DateTime referenceTime)
    {
        // TODO: Evaluate repeat rules and snooze state to compute the next activation time.
        return null;
    }

    public DateTime? GetPreNotificationTime(IAlarm alarm, DateTime referenceTime)
    {
        // Requirement: surface notifications PreNotificationLeadTime (30 minutes) before the next ring.
        // TODO: Use the upcoming trigger time and subtract the lead to determine the notification moment.
        return null;
    }
}
