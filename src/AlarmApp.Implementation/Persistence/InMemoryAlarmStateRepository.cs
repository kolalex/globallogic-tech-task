using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlarmApp.Abstractions;

namespace AlarmApp.Implementation.Persistence;

internal sealed class InMemoryAlarmStateRepository : IAlarmStateRepository
{
    private readonly List<IAlarm> _cache = new();

    public Task<IReadOnlyList<IAlarm>> LoadAlarmsAsync()
    {
        // TODO: Load alarms from durable storage and hydrate the domain model.
        return Task.FromResult<IReadOnlyList<IAlarm>>(_cache.ToList());
    }

    public Task SaveAlarmsAsync(IReadOnlyList<IAlarm> alarms)
    {
        // TODO: Persist alarms to durable storage and ensure transactional guarantees.
        _cache.Clear();
        _cache.AddRange(alarms);
        return Task.CompletedTask;
    }
}
