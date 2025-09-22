using AlarmApp.Abstractions.Enums;

namespace AlarmApp.Abstractions.Models;

// Pattern: Domain Event payload delivered when an alarm fires.
public sealed record AlarmTriggerContext(
    Guid AlarmId,
    DateTime ScheduledTime,
    bool IsSnoozeTrigger,
    AlarmLabel DisplayName,
    RingtoneIdentifier RingtoneId,
    SnoozeDurationOption DefaultSnoozeDuration);
