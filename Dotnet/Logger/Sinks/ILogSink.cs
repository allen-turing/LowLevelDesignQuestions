namespace Logger.Sinks;

public interface ILogSink
{
    void Log(string message, LogLevel level);
}