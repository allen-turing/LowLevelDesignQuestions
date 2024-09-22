namespace Logger;

public interface ILogSink
{
    void Log(string message, LogLevel level);
}