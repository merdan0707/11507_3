using System.Collections.ObjectModel;

namespace WarehouseSecuritySystem;


public class Logger
{
    public ObservableCollection<string> logs = new();
    
    public void Triggered(string message, DateTime time)
    {
        logs.Add($"Message: {message} | Time: {time}");    
    }
}