namespace Linq.HomeWork;

public record Point(int X, int Y);

public static class TwoNeighbours
{
    public static void Run()
    {
        var points = new Point[] { new Point(0, 0), new Point(0, 1) };
        var result = points
            .MySelect(GetNeighbors)
            .MySelectMany()
            .MyDistinct();

        Console.WriteLine(result.Count());
        foreach (var point in result)
        {
            Console.WriteLine(point);
        }

    }

    public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        foreach (var item in source)
            yield return selector(item);
    }
    
    public static IEnumerable<T> MySelectMany<T>(this IEnumerable<IEnumerable<T>> source)
    {
        foreach (var list in source)
            foreach (var item in list)
                yield return item;
    }
    
    public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> source)
    {
        var seen = new HashSet<T>();
        foreach (var item in source)
        {
            if (seen.Add(item))
                yield return item;
        }
    }

    static IEnumerable<Point> GetNeighbors(Point p)
    {
        int[] d = { -1, 0, 1 };
        
        foreach (var dx in d)
            foreach (var dy in d)
                if (dx != 0 || dy != 0)
                    yield return new Point(p.X + dx, p.Y + dy);
    }
    
}