namespace Task_2;


class Program
{
    static void Main(string[] args)
    {
        var concurrentSys = new ConcurrentSystem();
        var thread1 = new Thread(concurrentSys.GenerateData);
        var thread2 = new Thread(concurrentSys.Move);
        thread1.Start();
        thread2.Start();

        thread2.Join();

        Console.WriteLine($"Count {concurrentSys.UserList.Count}");
        foreach (var user in concurrentSys.UserList)
        {
            Console.WriteLine($"{user.Name}");
        }

        Console.WriteLine();
    }
}

/*
(7 баллов) 
Напишите ConcurrentSystem: 
один поток-продюсер генерирует объекты User и записывает их в очередь, 
а второй поток-консьюмер одновременно с ним считывает их из очереди и записывает в List.
*/