namespace Linq.HomeWork;

public static class StringValidation
{
    public static void Run()
    {
        var text = new[] { "abc", "aabbcc", "aaab", "myNameIsMerdan","hello", "world", "test"};

        var result = text
            .MyWhere(IsRepeatTwoTimes);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if(predicate(item))
                yield return item;
        }
    }
    
    public static bool IsRepeatTwoTimes(string text)
    {
        text = text.ToLower().Trim();

        foreach (var c in text)
        {
            int count = 0;
            foreach (var c2 in text)
            {
                if (c == c2) 
                    count++;
            }
            
            if(count > 2) return false;
        }
        
        return true;
    }
}