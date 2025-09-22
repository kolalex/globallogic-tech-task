using AlarmApp.Abstractions.Models;

namespace AlarmApp.Abstractions.Interfaces;

// Pattern: Facade exposing alarm management use-cases to clients.
public interface IAlarmCollection
{
    // Returns a read-only list of all alarms managed by the application.
    IReadOnlyList<IAlarm> Alarms { get; }

    // Creates a new alarm with the provided configuration and returns the created instance.
    Task<IAlarm> CreateAlarmAsync(AlarmConfiguration configuration);

    // Replaces the configuration of an existing alarm while preserving its identity and runtime settings.
    Task UpdateAlarmAsync(Guid alarmId, AlarmConfiguration configuration);

    // Retrieves an alarm by identifier, returning null when it does not exist.
    Task<IAlarm?> GetAlarmAsync(Guid alarmId);

    // Removes the specified alarm from the collection and cancels any scheduled occurrences.
    Task DeleteAlarmAsync(Guid alarmId);
}
