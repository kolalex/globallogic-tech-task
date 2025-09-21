using System;

namespace AlarmApp.Abstractions;

// Pattern: Domain Event payload delivered when an alarm fires.
public sealed record AlarmTriggerContext(
    Guid AlarmId,
    DateTime ScheduledTime,
    bool IsSnoozeTrigger,
    string DisplayName,
    string RingtoneId,
    SnoozeDurationOption DefaultSnoozeDuration);
