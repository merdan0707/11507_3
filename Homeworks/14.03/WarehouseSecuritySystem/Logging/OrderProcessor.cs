namespace Logging;

public delegate void LogHandler(string str);

public class OrderProcessor
{
    public LogHandler _logHandler;
    
    public void Process()
    {
        _logHandler?.Invoke("Заказ принят");
        _logHandler?.Invoke("Платеж прошел");
    }
}