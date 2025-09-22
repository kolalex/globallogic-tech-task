using System;

namespace AlarmApp.Abstractions;

// Pattern: Data Transfer Object for persisting and editing alarm configuration.
public sealed record AlarmConfiguration(
    TimeOnly TimeOfDay,
    AlarmLabel? AlarmName,
    SnoozeDurationOption SnoozeDuration,
    RingtoneIdentifier RingtoneId,
    AlarmRepeatConfiguration RepeatConfiguration);
