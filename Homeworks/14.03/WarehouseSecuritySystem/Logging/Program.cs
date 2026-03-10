namespace Logging;

class Program
{
    static void Main(string[] args)
    {
        #region Уровень 1: Логирование
       
        OrderProcessor orderProcessor1 = new OrderProcessor();
        orderProcessor1._logHandler = Print;
        orderProcessor1._logHandler += PrintWithRedColor;
        orderProcessor1.Process();
        void Print(string str) => Console.WriteLine(str);
       
        void PrintWithRedColor(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        #endregion
    }
}