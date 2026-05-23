using System.Reflection;
using System.Xml;

namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        var logger = new PropertyLogger();
        var user = new User() { Age = 78, Name = "Merdan"};
        logger.GetLog(user);

        Console.WriteLine("First User");
        foreach (var property in logger.properties)
        {
            Console.WriteLine(property);
        }
        Console.WriteLine();
        
        
        var logger2 = new PropertyLogger();
        var user2 = new User(){ Age = 18, Name = null};
        logger2.GetLog(user2);

        Console.WriteLine("Second User");
        foreach (var property in logger2.properties)
        {
            Console.WriteLine(property);
        }
    }
}

/*Вариант 2
(7 баллов) 
Напишите PropertyLogger. 
Метод GetLog(object obj) должен через рефлексию вернуть список строк (НЕ ВЫВЕСТИ В КОНСОЛЬ) 
"[ИмяСвойства]: [Значение]" для всех свойств, у которых значение не null.


(7 баллов) 
Напишите ConcurrentSystem: один поток-продюсер генерирует объекты User и записывает их в очередь, 
а второй поток-консьюмер одновременно с ним считывает их из очереди и записывает в List.

(1 балл) 
Модифицируйте код: консьюмер должен не просто записывать объект,
а каждый раз вызывать PropertyLogger.GetLog() для извлечения состояния объекта перед записью в список (сохранять значения не надо).
*/