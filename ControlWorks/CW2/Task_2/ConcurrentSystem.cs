using System.Reflection.Metadata;
using Task_1;
namespace Task_2;


public class ConcurrentSystem
{
    public Queue<User> UserQueue { get; set; } = new ();
    public List<User> UserList = new();
    
    public void GenerateData()
    {
        for (int i = 0; i < 20; i++)
        {
            var user = new User() { Age = i + 1 , Name = $"User_{i}"}; 
            UserQueue.Enqueue(user);
        }
    }

    public void Move()
    {
        for (int i = 0; i < 20; i++)
        {
            var user = UserQueue.Dequeue();
            if (user != null)
            {
                UserList.Add(user);
            }
        }
    }
}

/*
(7 баллов)
Напишите ConcurrentSystem:
один поток-продюсер генерирует объекты User и записывает их в очередь,
а второй поток-консьюмер одновременно с ним считывает их из очереди и записывает в List.
*/