using Logger.Sinks;

namespace Logger.LogProcessor;

public class ErrorLogProcessor : LogProcessor
{
    public ErrorLogProcessor(Logger.LogProcessor.LogProcessor nextProcessor, ILogSink sink) : base(nextProcessor,sink)
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