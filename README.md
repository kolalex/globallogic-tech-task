# Alarm Application Domain Model

This repository contains a .NET 8 solution that defines the business interfaces and reference implementation for an alarm application similar to the native Android/iPhone clock experience. The focus is on clean, testable business logic that UI layers can consume without modification.

## Projects

- src/AlarmApp.Abstractions – Contracts, value objects, and domain events that describe alarms, scheduling, runtime control, and persistence abstractions.
- src/AlarmApp.Implementation – In-memory, placeholder implementation of the abstractions with dependency-injection registration helpers.
- samples/AlarmApp.ConsoleSample – Console walk-through showing how to configure alarms, subscribe to events, and exercise runtime operations.

## Key Concepts

- **Strongly typed value objects** (AlarmLabel, RingtoneIdentifier, AlarmRepeatConfiguration) remove ambiguity when constructing records and enforce valid repeat rules.
- **Async-first interfaces** allow future persistence, scheduling, and runtime integrations to remain non-blocking.
- **Design patterns** such as Aggregate Root (IAlarm), Facade (IAlarmCollection), Strategy (IAlarmScheduleService), Repository (IAlarmStateRepository), Adapter (ITimeProvider), and Observer (IAlarmEventPublisher) keep the domain expressive and maintainable.

## Getting Started

1. **Restore & build**
   `ash
   dotnet build
   `
2. **Run the sample console app**
   `ash
   dotnet run --project samples/AlarmApp.ConsoleSample
   `
3. Review the output to see alarm lifecycle events (start, snooze, stop, pre-notification cleared) emitted over the sample publisher.

## Extending

- Replace the in-memory collections/persistence with database or platform services by implementing the corresponding interfaces.
- Implement real scheduling logic in IAlarmScheduleService to integrate with timers or OS alarm managers.
- Hook IAlarmEventPublisher into UI frameworks to surface notifications and playback controls.

## Testing

The abstractions are designed for straightforward unit testing. Swap out ITimeProvider, IAlarmStateRepository, and IAlarmEventPublisher with fakes to verify alarm behavior without touching UI concerns.

## License

This repository is provided for interview/technical assessment purposes.
