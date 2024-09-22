namespace Logger;

public class FileSink : ILogSink
{
    private readonly string _fileName;

    public FileSink(string fileName)
    {
        _fileName = fileName+DateTime.UtcNow.ToString("yyyyMMdd")+".txt";
    }
    public void Log(string message, LogLevel level)
    {
        string projectDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string fullFilePath = Path.Combine(projectDirectory,"LogFileSink", _fileName);
        using StreamWriter streamWriter = new StreamWriter(fullFilePath, true);
        streamWriter.WriteLine($"[{DateTime.UtcNow:s} {level.ToString().ToUpper()}] {message}");
    }
}