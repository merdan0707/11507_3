namespace Linq;

public static class ParsePoint
{
    public static void Run()
    {
        foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
            Console.WriteLine(point.X + " " + point.Y);
        Console.WriteLine();
        foreach (var point in ParsePoints(new List<string> { "+01 -0042", "0009 +1804" }))
            Console.WriteLine(point.X + " " + point.Y);
    }

    
    public static List<Point> ParsePoints(IEnumerable<string> lines)
    {
        return lines
            .Select(line => line.Split(' '))
            .Select(parts => new Point(int.Parse(parts[0]), int.Parse(parts[1])))
            .ToList();
    }
    
    public record Point(int X, int Y);  
}