namespace Linq.HomeWork;

public static class TakeMethod
{
    public static void Run()
    {
        var array = new[] { 1, 2, 3, 4, 5, 6 };
        var result = array.MySkip(3)
            .MyConcat(array.MyTake(3));
        Console.WriteLine(string.Join(", ", result));
        
        
    }

    public static  IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count)
    {
        int i = 1;
        foreach (var item in source)
        {
            if (i++ <= count) continue;
            yield return item;
        }
    }
    
    public static  IEnumerable<T> MyTake<T>(this IEnumerable<T> source, int count)
    {
        int i = 1;
        foreach (var item in source)
        {
            if (i++ <= count) 
                yield return item;
            else
                yield break;
        }
    }

    public static IEnumerable<TSource> MyConcat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
        foreach (var item in first) yield return item;
        foreach (var item in second) yield return item;
    }
}