// See https://aka.ms/new-console-template for more information

using Logger;

Console.WriteLine("---------Log Processor-------");
ILogSink sink = new ConsoleSink();
sink = new FileSink("log");
LogProcessor logObject = new InfoLogProcessor(new DebugLogProcessor( new ErrorLogProcessor(null,sink),sink),sink);

logObject.Log(LogLevel.Error, "Exception Happens");
logObject.Log(LogLevel.Debug, "Debug The Error");
logObject.Log(LogLevel.Info, "Information Details");