namespace Logger;

public class ConsoleSink: ILogSink
{
    public void Log(string message, LogLevel level)
    {
        Console.WriteLine($"[{DateTime.UtcNow} {level.ToString().ToUpper()}] {message}");
    }
}