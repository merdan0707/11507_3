namespace Linq;

public class LongestWord
{
    public static void Run()
    {
        Console.WriteLine(GetLongest(new[] {"azaz", "as", "sdsd"}));
        Console.WriteLine(GetLongest(new[] {"zzzz", "as", "sdsd"}));
        Console.WriteLine(GetLongest(new[] {"as", "12345", "as", "sds"}));
    }
    
    public static string GetLongest(IEnumerable<string> words)
    {
        #region Method Syntax

        return words.MinBy(w => (-w.Length, w));

        #endregion

        #region Query Syntax 

        var result =
            from word in words
            select word;
        
        return result.MinBy(w => (-w.Length, w));

        #endregion
    }
}