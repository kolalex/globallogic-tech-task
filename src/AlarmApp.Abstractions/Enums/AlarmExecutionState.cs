namespace AlarmApp.Abstractions.Enums;

// Pattern: Enumerated state representation used by higher level State Machine logic.
public enum AlarmExecutionState
{
    Disabled,
    Enabled,
    Ringing,
    Snoozed,
    TurnedOffForToday
}
