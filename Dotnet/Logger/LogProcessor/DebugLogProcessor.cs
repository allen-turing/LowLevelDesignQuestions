using Logger.Sinks;

namespace Logger.LogProcessor;

public class DebugLogProcessor : LogProcessor
{
    public DebugLogProcessor(Logger.LogProcessor.LogProcessor nextProcessor,ILogSink sink) : base(nextProcessor,sink)
    {
        
    }
    
    public override void Log(LogLevel level, string message)
    {
        if (level == LogLevel.Debug)
        {
            _sink.Log(message, level);
            return; 
        }
        base.Log(level, message);
    }
}