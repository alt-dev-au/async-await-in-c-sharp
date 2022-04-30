namespace AsyncAwaitExample.Common;

public static class TimeSpanExtensions
{
    public static string AsElapsedString(this TimeSpan ts)
    {
        return $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
    }
}
