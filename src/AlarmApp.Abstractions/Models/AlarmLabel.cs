namespace AlarmApp.Abstractions.Models;

// Pattern: Value Object ensuring labelled alarm text is validated and typed.
public readonly record struct AlarmLabel
{
    private AlarmLabel(string value) => Value = value;

    public string Value { get; }

    public static AlarmLabel Default { get; } = new("Alarm");

    public override string ToString() => Value;

    public static AlarmLabel Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Alarm label cannot be null or whitespace.", nameof(value));
        }

        return new AlarmLabel(value.Trim());
    }

    public static AlarmLabel? CreateOptional(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : Create(value);
    }
}
