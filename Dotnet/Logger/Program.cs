// See https://aka.ms/new-console-template for more information

using Logger;

Console.WriteLine("---------Log Processor-------");

LogProcessor logObject = new InfoLogProcessor(new DebugLogProcessor( new ErrorLogProcessor(null)));

logObject.Log(LogLevel.Error, "Exception Happens");
logObject.Log(LogLevel.Debug, "Debug The Error");
logObject.Log(LogLevel.Info, "Information Details");