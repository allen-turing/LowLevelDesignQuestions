namespace Logger;

public class InfoLogProcessor : LogProcessor
{
    public InfoLogProcessor(LogProcessor nextProcessor) : base(nextProcessor)
    {
    }

    public override void Log(LogLevel level, string message)
    {
        if (level == LogLevel.Info)
        {
            Console.WriteLine($"INFO: {message}");
            return;
        }
        base.Log(level, message);
    }
}