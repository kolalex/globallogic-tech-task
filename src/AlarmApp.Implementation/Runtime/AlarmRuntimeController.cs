using AlarmApp.Abstractions.Interfaces;
using AlarmApp.Abstractions.Models;
using AlarmApp.Implementation.Collections;
using AlarmApp.Implementation.Scheduling;

namespace AlarmApp.Implementation.Runtime;

internal sealed class AlarmRuntimeController(InMemoryAlarmCollection alarmCollection, AlarmEventPublisher eventPublisher, AlarmScheduleService scheduleService) : IAlarmRuntimeController
{
    private readonly InMemoryAlarmCollection _alarmCollection = alarmCollection;
    private readonly AlarmEventPublisher _eventPublisher = eventPublisher;
    private readonly AlarmScheduleService _scheduleService = scheduleService;

    public Task BeginAlarmAsync(AlarmTriggerContext context)
    {
        // TODO: Transition alarm to ringing state, start playback, and notify observers.
        return _eventPublisher.PublishAlarmStartedAsync(context);
    }

    public async Task StopAlarmAsync(Guid alarmId)
    {
        // TODO: Stop playback, update repeat state, and compute next occurrence as needed.
        var alarm = await _alarmCollection.GetAlarmAsync(alarmId);
        if (alarm is null)
        {
            return;
        }

        _ = _scheduleService.GetNextTriggerTime(alarm, DateTime.UtcNow);
        var context = CreateTriggerContext(alarm, isSnooze: false);
        await _eventPublisher.PublishAlarmStoppedAsync(context);
    }

    public async Task SnoozeAlarmAsync(Guid alarmId, TimeSpan? overrideSnoozeDuration)
    {
        // TODO: Schedule a snoozed trigger using override duration when provided.
        var alarm = await _alarmCollection.GetAlarmAsync(alarmId);
        if (alarm is null)
        {
            return;
        }

        // TODO: Incorporate overrideSnoozeDuration into the scheduler once implemented.
        _ = _scheduleService.GetNextTriggerTime(alarm, DateTime.UtcNow);
        var context = CreateTriggerContext(alarm, isSnooze: true);
        await _eventPublisher.PublishAlarmSnoozedAsync(context);
    }

    public async Task DismissBeforeTriggerAsync(Guid alarmId)
    {
        // TODO: Cancel pending trigger for the current day and emit appropriate notification events.
        var alarm = await _alarmCollection.GetAlarmAsync(alarmId);
        if (alarm is null)
        {
            return;
        }

        _ = _scheduleService.GetPreNotificationTime(alarm, DateTime.UtcNow);
        var context = new AlarmPreNotificationContext(alarm.Id, DateTime.UtcNow, alarm.RepeatConfiguration.Mode);
        await _eventPublisher.PublishPreNotificationClearedAsync(context);
    }

    private static AlarmTriggerContext CreateTriggerContext(IAlarm alarm, bool isSnooze)
    {
        var label = alarm.AlarmName ?? AlarmLabel.Default;
        return new AlarmTriggerContext(alarm.Id, DateTime.UtcNow, isSnooze, label, alarm.RingtoneId, alarm.SnoozeDuration);
    }
}
