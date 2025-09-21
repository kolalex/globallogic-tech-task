using System;

namespace AlarmApp.Abstractions;

// Pattern: Domain Event payload for pre-alarm notifications.
public sealed record AlarmPreNotificationContext(
    Guid AlarmId,
    DateTime ScheduledTime,
    AlarmRepeatMode RepeatMode);
