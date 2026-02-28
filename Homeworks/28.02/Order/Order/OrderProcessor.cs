using System.Numerics;

namespace Order;

public static class OrderProcessor<T>
{
    public static void Process<T>(Order<T> order, OrderHandler<T> firstHandler) 
        where T : INumber<T>
    {
        Console.WriteLine($"--- Начало обработки заказа #{order.Id} ---");
        firstHandler.Handle(order);
        Console.WriteLine($"--- Обработка завершена ---\n");
    }
}