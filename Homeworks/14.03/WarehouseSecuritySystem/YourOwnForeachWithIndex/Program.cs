namespace YourOwnForeachWithIndex;

class Program
{
    static void Main(string[] args)
    {
        #region Уровень 4: Свой "Foreach" с индексами
        
        List<string> company = new List<string>()
        {
            "Иван","Петр","Святослав","Николай","Павел","Александр","Федор","Дмитрий"
        };
        
        company.ForEachWithIndex(PrintListWithIndex);
        
        void PrintListWithIndex (string str, int index)
        {
            Console.WriteLine($"{index}. {str}");
        }
        #endregion
    }
}