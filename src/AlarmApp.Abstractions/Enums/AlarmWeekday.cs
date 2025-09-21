﻿using System;

namespace AlarmApp.Abstractions;

// Pattern: Bit Flag enumeration enabling composite weekday sets.
[Flags]
public enum AlarmWeekday
{
    None = 0,
    Monday = 1 << 0,
    Tuesday = 1 << 1,
    Wednesday = 1 << 2,
    Thursday = 1 << 3,
    Friday = 1 << 4,
    Saturday = 1 << 5,
    Sunday = 1 << 6,
    Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
    Weekends = Saturday | Sunday,
    Everyday = Weekdays | Weekends
}
