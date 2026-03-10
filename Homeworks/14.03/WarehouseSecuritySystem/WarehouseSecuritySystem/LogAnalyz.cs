namespace WarehouseSecuritySystem;

public static class LogAnalyzer
{
    public static void AnalyzeLog<T>(IEnumerable<T> logs, Predicate<T> filter)
    {
        Console.WriteLine("\n--- Результаты анализа ---");
        foreach (var log in logs)
        {
            if (filter(log))
                Console.WriteLine($"Найдено: {log}");
        }
    }
}