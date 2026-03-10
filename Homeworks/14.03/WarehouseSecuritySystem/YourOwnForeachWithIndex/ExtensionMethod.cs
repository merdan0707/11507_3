namespace YourOwnForeachWithIndex;

static public class ExtensionMethod
{
    public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> action)
    {
        int  index = 0;
        foreach (var item in enumerable)
        {
            index++;
            action(item, index);
        }
    }
}