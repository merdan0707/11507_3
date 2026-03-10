namespace WarehouseSecuritySystem;

public class Siren
{
    public void Triggered(string message, DateTime time)
    {
        Console.WriteLine($"ВКЛЮЧЕНА СИРЕНА: {message}");
    }
}