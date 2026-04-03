using System.Text.Json;
using System.Text.Json.Nodes;

namespace Coffee_Machine;

class Program
{
    static void Main(string[] args)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "MyConfig.json");
        Config config1;
        List<SalesHistory> salesHistories = new();
        
        if (File.Exists(filePath))
        {
            var currentContent = JsonSerializer.Deserialize<Config>(File.ReadAllText(filePath));
            config1 = currentContent;
            Console.WriteLine("Already exist");
        }
        else
        {
            config1 = new Config();
            File.WriteAllText(filePath, 
                JsonSerializer.Serialize(config1, new JsonSerializerOptions(){WriteIndented = true}));
        }
        
        RunCoffeeMachine(config1, filePath, salesHistories);
        
        GenerateReport(salesHistories);
    }

    
    
    public static void RunCoffeeMachine(Config config, string filePath, List<SalesHistory> salesHistories)
    {
        while (true)
        {
            Console.WriteLine("\nList of Drinks:");
            int i = 1;
            foreach (var drink in config.Menu)
            {
                Console.WriteLine($"{i++} _ Name:{drink.Name,15} |");
            }
            Console.WriteLine("0 _ Конец смены");
            Console.Write("Choose a drink (or 0 to Exit):");
            
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("\nInput the number of Drink\n");
                continue;
            }

            if (choice == 0) break;
            
            if (choice < 1 || choice > config.Menu.Count)
            {
                Console.WriteLine("\nInvalid number!\n");
                continue;
            }

            // проверка резервов
            if (config.WaterLeft < config.Menu[choice-1].TakeWater 
                || config.MilkLeft < config.Menu[choice-1].TakeMilk
                || config.BeansLeft < config.Menu[choice-1].TakeBeans)
            {
                Console.WriteLine("Not enough ingredients");
                continue;
            }
            else
            {
                config.WaterLeft -= config.Menu[choice - 1].TakeWater;
                config.MilkLeft -= config.Menu[choice - 1].TakeMilk;
                config.BeansLeft -= config.Menu[choice - 1].TakeBeans;
                Console.WriteLine($"{config.Menu[choice-1].Name} have cooked successfully!");

                var sailed = new SalesHistory(DateTime.Now, config.Menu[choice - 1].Name, config.Menu[choice - 1].Price);
                var historyPath = Path.Combine(Directory.GetCurrentDirectory(), "sales_history.txt");
                string logEntry = 
                    $"[{sailed.Date.ToString("g")}] Продано: {sailed.Name}, Цена: {sailed.Price}.{Environment.NewLine}";
                
                File.AppendAllText(historyPath, logEntry);
                File.WriteAllText(filePath, 
                    JsonSerializer.Serialize(config, new JsonSerializerOptions(){WriteIndented = true}));
                salesHistories.Add(sailed);
                
                Console.WriteLine($"{sailed.Name} record to history");
            }
        }
    }

    public static void GenerateReport(List<SalesHistory> salesHistories)
    {
        Console.WriteLine("Начинаем генерацию отчета...");
        string pathHistory = Path.Combine(Directory.GetCurrentDirectory(), "sales_history.txt");

        if (!File.Exists(pathHistory))
        {
            Console.WriteLine("Файл истории не найден!");
            return;
        }

        int[] allPrices = salesHistories
            .Select(x => x.Price)
            .ToArray();
        
        var report = new ShiftReport(DateTime.Now, allPrices.Sum(), allPrices.Length);
        var reportContent = JsonSerializer.Serialize(report, new JsonSerializerOptions() { WriteIndented = true });
        string dateFileName = DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
        File.WriteAllText(
            Path.Combine(Directory.GetCurrentDirectory(), $"report_{dateFileName}.json"),
            reportContent);
    }
}



