using AlarmApp.Abstractions.Models;

namespace AlarmApp.Abstractions.Interfaces;

// Pattern: Observer/Event Aggregator broadcasting alarm lifecycle events.
public interface IAlarmEventPublisher
{
    // Raised when an alarm begins to ring so the UI can display the alarm screen and start playback.
    event EventHandler<AlarmTriggerContext> AlarmStarted;

    // Raised when an alarm is stopped so the UI can close the alarm screen and clean up playback.
    event EventHandler<AlarmTriggerContext> AlarmStopped;

    // Raised when an alarm is snoozed so the UI can update its representation and inform the user.
    event EventHandler<AlarmTriggerContext> AlarmSnoozed;

    // Raised 30 minutes before an alarm is scheduled to ring so the UI can surface a pre-notification.
    event EventHandler<AlarmPreNotificationContext> PreNotificationRaised;

    // Raised when a pre-notification is cleared because the alarm was dismissed or rescheduled.
    event EventHandler<AlarmPreNotificationContext> PreNotificationCleared;
}
