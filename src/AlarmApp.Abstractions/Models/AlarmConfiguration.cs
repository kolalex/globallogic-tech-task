using System;

namespace AlarmApp.Abstractions;

// Pattern: Data Transfer Object for persisting and editing alarm configuration.
public sealed record AlarmConfiguration(
    TimeOnly TimeOfDay,
    string? AlarmName,
    SnoozeDurationOption SnoozeDuration,
    string RingtoneId,
    AlarmRepeatConfiguration RepeatConfiguration);
