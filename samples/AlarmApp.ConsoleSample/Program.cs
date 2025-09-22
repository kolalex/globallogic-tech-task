using System.Threading.Tasks;
using AlarmApp.Abstractions;
using AlarmApp.Implementation.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddAlarmCore();

await using var provider = services.BuildServiceProvider();

var alarms = provider.GetRequiredService<IAlarmCollection>();
var runtime = provider.GetRequiredService<IAlarmRuntimeController>();
var events = provider.GetRequiredService<IAlarmEventPublisher>();

// Hook sample event handlers to illustrate how a UI could react to alarm lifecycle events.
events.AlarmStarted += (_, context) =>
    Console.WriteLine($"Alarm started: {context.DisplayName.Value} at {context.ScheduledTime:HH:mm}");
events.AlarmStopped += (_, context) =>
    Console.WriteLine($"Alarm stopped: {context.DisplayName.Value}");
events.AlarmSnoozed += (_, context) =>
    Console.WriteLine($"Alarm snoozed: {context.DisplayName.Value} (is snooze trigger: {context.IsSnoozeTrigger})");
events.PreNotificationCleared += (_, context) =>
    Console.WriteLine($"Pre-notification cleared for alarm {context.AlarmId} ({context.RepeatMode})");

// Example 1: Weekday wake-up alarm with custom ringtone.
var weekdayAlarmConfig = new AlarmConfiguration(
    TimeOnly.FromDateTime(DateTime.Today.AddHours(7)),
    AlarmLabel.Create("Weekday Wake Up"),
    SnoozeDurationOption.Minutes10,
    RingtoneIdentifier.Create("early-bird"),
    AlarmRepeatConfiguration.ForDaysOfWeek(AlarmWeekday.Weekdays));
var weekdayAlarm = await alarms.CreateAlarmAsync(weekdayAlarmConfig);
Console.WriteLine($"Created weekday alarm {weekdayAlarm.Id} at {weekdayAlarm.TimeOfDay:HH:mm}");

// Example 2: One-time travel alarm with shorter snooze.
var travelAlarmConfig = new AlarmConfiguration(
    TimeOnly.FromDateTime(DateTime.Today.AddHours(4)),
    AlarmLabel.Create("Airport Shuttle"),
    SnoozeDurationOption.Minutes5,
    RingtoneIdentifier.Create("gentle-rise"),
    AlarmRepeatConfiguration.OnlyForToday());
var travelAlarm = await alarms.CreateAlarmAsync(travelAlarmConfig);
Console.WriteLine($"Created travel alarm {travelAlarm.Id} for {travelAlarm.TimeOfDay:HH:mm}");

// Example 3: Weekend alarm with longer snooze stretch.
var weekendAlarmConfig = new AlarmConfiguration(
    TimeOnly.FromDateTime(DateTime.Today.AddHours(9)),
    AlarmLabel.Create("Weekend Brunch"),
    SnoozeDurationOption.Minutes20,
    RingtoneIdentifier.Create("soft-chimes"),
    AlarmRepeatConfiguration.ForDaysOfWeek(AlarmWeekday.Weekends));
var weekendAlarm = await alarms.CreateAlarmAsync(weekendAlarmConfig);
Console.WriteLine($"Created weekend alarm {weekendAlarm.Id} with repeat mode {weekendAlarm.RepeatConfiguration.Mode}");

// Simulate the weekday alarm ringing.
var weekdayContext = new AlarmTriggerContext(
    weekdayAlarm.Id,
    DateTime.UtcNow.AddMinutes(1),
    false,
    weekdayAlarm.AlarmName ?? AlarmLabel.Default,
    weekdayAlarm.RingtoneId,
    weekdayAlarm.SnoozeDuration);
await runtime.BeginAlarmAsync(weekdayContext);

// Demonstrate snoozing with an override duration.
await runtime.SnoozeAlarmAsync(weekdayAlarm.Id, TimeSpan.FromMinutes(3));

// Demonstrate stopping the alarm after the user reaches the phone.
await runtime.StopAlarmAsync(weekdayAlarm.Id);

// Show how a pre-notification dismissal might be surfaced.
await runtime.DismissBeforeTriggerAsync(travelAlarm.Id);

Console.WriteLine("Sample workflow complete. Press any key to exit.");
Console.ReadKey();
