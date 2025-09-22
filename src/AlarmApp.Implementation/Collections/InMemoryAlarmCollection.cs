using AlarmApp.Abstractions.Interfaces;
using AlarmApp.Abstractions.Models;
using AlarmApp.Implementation.Alarms;

namespace AlarmApp.Implementation.Collections;

internal sealed class InMemoryAlarmCollection : IAlarmCollection
{
    private readonly Dictionary<Guid, Alarm> _alarms = [];

    public IReadOnlyList<IAlarm> Alarms => [.. _alarms.Values.Cast<IAlarm>()];

    public Task<IAlarm> CreateAlarmAsync(AlarmConfiguration configuration)
    {
        // TODO: Validate configuration, persist the new alarm, and schedule its first trigger.
        var alarm = new Alarm(Guid.NewGuid(), configuration);
        _alarms[alarm.Id] = alarm;
        return Task.FromResult<IAlarm>(alarm);
    }

    public Task UpdateAlarmAsync(Guid alarmId, AlarmConfiguration configuration)
    {
        // TODO: Persist changes and reschedule any pending triggers according to the new configuration.
        if (_alarms.TryGetValue(alarmId, out var alarm))
        {
            alarm.TimeOfDay = configuration.TimeOfDay;
            alarm.AlarmName = configuration.AlarmName;
            alarm.SnoozeDuration = configuration.SnoozeDuration;
            alarm.RingtoneId = configuration.RingtoneId;
            alarm.RepeatConfiguration = configuration.RepeatConfiguration;
        }

        return Task.CompletedTask;
    }

    public Task<IAlarm?> GetAlarmAsync(Guid alarmId)
    {
        // TODO: Retrieve alarm from persistence layer and hydrate domain model as needed.
        _ = _alarms.TryGetValue(alarmId, out var alarm);
        return Task.FromResult<IAlarm?>(alarm);
    }

    public Task DeleteAlarmAsync(Guid alarmId)
    {
        // TODO: Remove stored alarm and cancel any scheduled triggers or notifications.
        _alarms.Remove(alarmId);
        return Task.CompletedTask;
    }
}
