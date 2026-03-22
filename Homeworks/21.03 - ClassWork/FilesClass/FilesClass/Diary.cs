namespace FilesClass;

public static class Diary
{
    public static void Run()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        
        string fileName = DateTime.Now.ToString("dd.MM.yyyy hh") + ".txt";
        string filePath = Path.Combine(currentDirectory, fileName);
        
        Console.Clear();
        Console.Write("Введите запись в дневник: ");
        string userText = Console.ReadLine();
        string logEntry = $"[{DateTime.Now}]: {userText}\n";
        File.AppendAllText(filePath, logEntry);
        Console.WriteLine($"Запись сохранена в файл: {fileName}");
    }
}