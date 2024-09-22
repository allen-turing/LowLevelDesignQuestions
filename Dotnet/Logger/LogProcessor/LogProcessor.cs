using Logger.Sinks;

namespace Logger.LogProcessor;

public abstract class LogProcessor
{
    private readonly LogProcessor _nextProcessor;
    public readonly ILogSink _sink;

    public LogProcessor(LogProcessor nextProcessor, ILogSink sink)
    {
        _nextProcessor = nextProcessor;
        _sink = sink;
    }

    public virtual void Log(LogLevel level, string message)
    {
        if (_nextProcessor is not null)
        {
            _nextProcessor.Log(level, message);
        }
        else
        {
            Console.WriteLine("LogLevel Unknown!");
        }
    }
}