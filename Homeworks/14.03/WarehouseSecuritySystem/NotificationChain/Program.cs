namespace NotificationChain;

public class User(){}

class Program
{
    static void Main(string[] args)
    {
        #region Уровень 3: Цепочка уведомлений
        
        void Method1(User user){Console.WriteLine("This is the first method");};
        void Method2(User user){Console.WriteLine("This is the second method");};
        void Method3(User user){Console.WriteLine("This is the third method");};
        
        Action<User> MultiMethod;
        MultiMethod = Method1;
        MultiMethod += Method2;
        MultiMethod += Method3;
        MultiMethod?.Invoke(new User());
        
        #endregion
    }
}