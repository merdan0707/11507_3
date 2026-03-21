namespace Linq;

public class SortedWordsWithTuples
{
    
    public static void Run()
    {

        string text = "Hello world hello apple pie apple";
        var sortedWords = GetSortedWords(text);
        foreach (var word in sortedWords)
        {
            Console.WriteLine($"Word: {word}, Length: {word.Length}");
        }
    }
    
    
    public static List<string> GetSortedWords(string text)
    {
        #region Method Syntax
        
        return text
            .Split(new char[]{' ',',','.',';'}, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToLower().Trim())
            .Distinct()
            .OrderBy(x => (x.Length, x))
            .ToList();
        
        #endregion

        #region Query Syntax
        
        var result =
            from line in text.Split(new char[] { ' ', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries)
            let word = line.ToLower().Trim()
            where !string.IsNullOrEmpty(word)
            orderby (word.Length, word)
            select word;
        
        return result.Distinct().ToList(); 

        #endregion
    }
}