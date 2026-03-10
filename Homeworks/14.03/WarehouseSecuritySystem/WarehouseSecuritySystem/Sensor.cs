namespace WarehouseSecuritySystem;

public class Sensor
{
    public event Action<string, DateTime> OnAlert;

    public void Trigger(string message)
    {
        Console.WriteLine($"[Sensor] Сработал датчик: {message}");
        OnAlert?.Invoke(message, DateTime.Now);
    }
}