using AlarmApp.Abstractions.Interfaces;
using AlarmApp.Implementation.Collections;
using AlarmApp.Implementation.Persistence;
using AlarmApp.Implementation.Runtime;
using AlarmApp.Implementation.Scheduling;
using AlarmApp.Implementation.Time;
using Microsoft.Extensions.DependencyInjection;

namespace AlarmApp.Implementation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAlarmCore(this IServiceCollection services)
    {
        // TODO: Wire persistence and scheduling infrastructure suitable for the target environment.
        services.AddSingleton<InMemoryAlarmCollection>();
        services.AddSingleton<IAlarmCollection>(sp => sp.GetRequiredService<InMemoryAlarmCollection>());

        services.AddSingleton<AlarmEventPublisher>();
        services.AddSingleton<IAlarmEventPublisher>(sp => sp.GetRequiredService<AlarmEventPublisher>());

        services.AddSingleton<AlarmScheduleService>();
        services.AddSingleton<IAlarmScheduleService>(sp => sp.GetRequiredService<AlarmScheduleService>());

        services.AddSingleton<IAlarmRuntimeController, AlarmRuntimeController>();
        services.AddSingleton<IAlarmStateRepository, InMemoryAlarmStateRepository>();
        services.AddSingleton<ITimeProvider, SystemTimeProvider>();

        return services;
    }
}
