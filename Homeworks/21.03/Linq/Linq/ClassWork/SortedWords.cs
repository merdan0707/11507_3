namespace Linq;

public class SortedWords
{
    public static void Run()
    {
        var vocabulary = GetSortedWords(
            "Hello, hello, hello, how low",
            "",
            "With the lights out, it's less dangerous",
            "Here we are now; entertain us",
            "I feel stupid and contagious",
            "Here we are now; entertain us",
            "A mulatto, an albino, a mosquito, my libido...",
            "Yeah, hey"
        );
        foreach (var word in vocabulary)
            Console.WriteLine(word);
    }
    
    
    public static string[] GetSortedWords(params string[] textLines)
    {
        #region Linq Extension Method
        
        // return textLines
        //     .SelectMany(line => line.Split(new char[]{' ', ',', ';', '.'}, StringSplitOptions.RemoveEmptyEntries))
        //     .Select(x => x.ToLower().Trim())
        //     .Distinct()
        //     .OrderBy(x => x)
        //     .ToArray();
        #endregion

        #region Linq Expression
        
        var result = 
            from line in textLines
            from part in line.Split(new char[] { ' ', ',', ';', '.' },
                StringSplitOptions.RemoveEmptyEntries)
            let word = part.ToLower().Trim()
            orderby word
            select word;
        
        return result.Distinct().ToArray();
        
        #endregion
    }
}