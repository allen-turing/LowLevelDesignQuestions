namespace Logger;

public class DebugLogProcessor : LogProcessor
{
    public DebugLogProcessor(LogProcessor nextProcessor) : base(nextProcessor)
    {
        
    }
    
    public override void Log(LogLevel level, string message)
    {
        if (level == LogLevel.Debug)
        {
            Console.WriteLine($"DEBUG: {message}");
            return; 
        }
        base.Log(level, message);
    }
}