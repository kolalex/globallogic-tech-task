using System.Collections.Generic;

namespace AlarmApp.Abstractions;

// Pattern: Repository ensuring persistence concerns stay outside the domain model.
public interface IAlarmStateRepository
{
    // Loads all stored alarms, including their configuration and runtime state, into memory.
    IReadOnlyList<IAlarm> LoadAlarms();

    // Persists the current set of alarms so configuration and state survive application restarts.
    void SaveAlarms(IReadOnlyList<IAlarm> alarms);
}
