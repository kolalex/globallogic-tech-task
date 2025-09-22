using AlarmApp.Abstractions.Interfaces;
using AlarmApp.Abstractions.Models;

namespace AlarmApp.Implementation.Runtime;

internal sealed class AlarmEventPublisher : IAlarmEventPublisher
{
    public event EventHandler<AlarmTriggerContext>? AlarmStarted;
    public event EventHandler<AlarmTriggerContext>? AlarmStopped;
    public event EventHandler<AlarmTriggerContext>? AlarmSnoozed;
    public event EventHandler<AlarmPreNotificationContext>? PreNotificationRaised;
    public event EventHandler<AlarmPreNotificationContext>? PreNotificationCleared;

    public Task PublishAlarmStartedAsync(AlarmTriggerContext context)
    {
        // TODO: Dispatch start event to subscribers and initiate audio playback integration.
        AlarmStarted?.Invoke(this, context);
        return Task.CompletedTask;
    }

    public Task PublishAlarmStoppedAsync(AlarmTriggerContext context)
    {
        // TODO: Notify listeners that the alarm has been stopped and handle cleanup workflows.
        AlarmStopped?.Invoke(this, context);
        return Task.CompletedTask;
    }

    public Task PublishAlarmSnoozedAsync(AlarmTriggerContext context)
    {
        // TODO: Notify listeners about snooze event so UI can refresh countdown.
        AlarmSnoozed?.Invoke(this, context);
        return Task.CompletedTask;
    }

    public Task PublishPreNotificationRaisedAsync(AlarmPreNotificationContext context)
    {
        // TODO: Surface pre-notification details to listeners for the upcoming alarm trigger.
        PreNotificationRaised?.Invoke(this, context);
        return Task.CompletedTask;
    }

    public Task PublishPreNotificationClearedAsync(AlarmPreNotificationContext context)
    {
        // TODO: Inform subscribers that the pre-notification can be dismissed.
        PreNotificationCleared?.Invoke(this, context);
        return Task.CompletedTask;
    }
}
