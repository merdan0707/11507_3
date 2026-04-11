namespace Task3;

class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine("C:","Windows");
        var filesList = Directory.GetFiles(path);
        foreach (var file in filesList)
        {
            Console.WriteLine(file);
        }

        var scanneredFilesList = filesList
            .Select(file => new FileInfo(file))
            .Where(file => file.Length < 1024)
            .GroupBy(file => file.Extension.ToLower())
            .Select(group => new
            {
                Extension = group.Key,
                Count = group.Count()
            })
            .OrderByDescending(x => x.Count)
            .ToList();
        

        using (var writer = new StreamWriter(@"C:\Users\User\Desktop\11507_3\ControlWorks\CW1\summary.txt"))
        {
            foreach (var item in scanneredFilesList)
            {
                writer.WriteLine($"{item.Extension}: {item.Count}");
            }
        }
    }
}