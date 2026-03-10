namespace WarehouseSecuritySystem;

class Program
{
    static void Main(string[] args)
    {
        #region Система безопасности склада
        
        
        Sensor sensor = new Sensor();
        Siren siren = new Siren();
        Logger logger = new Logger();
        
        sensor.OnAlert += siren.Triggered;
        sensor.OnAlert += logger.Triggered;
        
        logger.logs.CollectionChanged += (s, e) =>
        {
            if (e.NewItems != null)
            {
                foreach (string newItem in e.NewItems)
                    Console.WriteLine($"Запись добавлена в БД: {newItem}");
            }
        };
        
        sensor.Trigger("Критично: Открыт сейф!");
        
        LogAnalyzer.AnalyzeLog(logger.logs, log => log.Contains("Крит"));
        LogAnalyzer.AnalyzeLog(logger.logs, log => log.Contains("крит"));
        
        Console.WriteLine("\n=== Все записи в логе ===");
        foreach (string log in logger.logs)
        {
            Console.WriteLine(log);
        }
        
        #endregion
    }
}
