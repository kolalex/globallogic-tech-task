using System;

namespace AlarmApp.Abstractions;

// Pattern: Domain Event payload delivered when an alarm fires.
public sealed record AlarmTriggerContext(
    Guid AlarmId,
    DateTime ScheduledTime,
    bool IsSnoozeTrigger,
    AlarmLabel DisplayName,
    RingtoneIdentifier RingtoneId,
    SnoozeDurationOption DefaultSnoozeDuration);
