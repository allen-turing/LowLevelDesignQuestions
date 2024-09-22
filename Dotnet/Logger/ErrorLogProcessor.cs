namespace Logger;

public class ErrorLogProcessor : LogProcessor
{
    public ErrorLogProcessor(LogProcessor nextProcessor, ILogSink sink) : base(nextProcessor,sink)
    {
    }

    public override void Log(LogLevel level, string message)
    {
        if (level == LogLevel.Error)
        {
            _sink.Log(message, level);
            return;
        }

        base.Log(level, message);
    }
}