using Logger.Sinks;

namespace Logger.LogProcessor;

public class InfoLogProcessor : LogProcessor
{
    public InfoLogProcessor(Logger.LogProcessor.LogProcessor nextProcessor, ILogSink sink) : base(nextProcessor,sink)
    {
    }

    public override void Log(LogLevel level, string message)
    {
        if (level == LogLevel.Info)
        {
             _sink.Log(message, level);
            return;
        }
        base.Log(level, message);
    }
}