namespace AlarmApp.Abstractions;

// Pattern: Value Object uniquely identifying a ringtone resource.
public readonly record struct RingtoneIdentifier
{
    private RingtoneIdentifier(string value) => Value = value;

    public string Value { get; }

    public override string ToString() => Value;

    public static RingtoneIdentifier Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Ringtone identifier cannot be null or whitespace.", nameof(value));
        }

        return new RingtoneIdentifier(value.Trim());
    }
}
