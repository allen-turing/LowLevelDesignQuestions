namespace Logger;

public class ErrorLogProcessor : LogProcessor
{
    public ErrorLogProcessor(LogProcessor nextProcessor) : base(nextProcessor)
    {
    }

    public override void Log(LogLevel level, string message)
    {
        if (level == LogLevel.Error)
        {
            Console.WriteLine($"ERROR: {message}");
            return;
        }

        base.Log(level, message);
    }
}