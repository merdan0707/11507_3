
namespace Linq;



public static class ProgramForParse
{
    public static void Run()
    {
        foreach (var num in ParseNumbers(new[] { "-0", "+0000" }))
            Console.WriteLine(num);
        Console.WriteLine();
        foreach (var num in ParseNumbers(new List<string> { "1", "", "-03", "0" }))
            Console.WriteLine(num);
    }
    
    
    public static int[] ParseNumbers(IEnumerable<string> lines)
    {
        return lines
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => int.Parse(x))
            .ToArray();
    }
}

