namespace AlarmApp.Abstractions;

// Pattern: Repository ensuring persistence concerns stay outside the domain model.
public interface IAlarmStateRepository
{
    // Loads all stored alarms, including their configuration and runtime state, into memory.
    Task<IReadOnlyList<IAlarm>> LoadAlarmsAsync();

    // Persists the current set of alarms so configuration and state survive application restarts.
    Task SaveAlarmsAsync(IReadOnlyList<IAlarm> alarms);
}
