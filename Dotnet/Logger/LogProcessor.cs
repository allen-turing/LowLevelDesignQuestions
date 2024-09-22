namespace Logger;

public abstract class LogProcessor
{
    private readonly LogProcessor _nextProcessor;

    public LogProcessor(LogProcessor nextProcessor)
    {
        _nextProcessor = nextProcessor;
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