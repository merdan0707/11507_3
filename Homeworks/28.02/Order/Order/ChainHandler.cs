using System.Numerics;

namespace Order;

public class DiscountHandler<T> : OrderHandler<T>
    where T: INumber<T>
{
    private T _discount;

    public DiscountHandler(int discount)
    {
        _discount = T.CreateChecked(discount);
    }
    public override void Handle(Order<T> order)
    {
        order.Price -= _discount;
        Console.WriteLine($"Discount: {_discount},  Total price with discount: {order.Price}");
        base.Handle(order);
    }
}

public class TaxHandler<T> : OrderHandler<T>
    where T: INumber<T>
{
    private T _tax;

    public TaxHandler(T tax)
    {
        _tax = T.CreateChecked(tax);
    }
    public override void Handle(Order<T> order)
    {
        order.Price *= _tax;
        Console.WriteLine($"Tax: {_tax} ,  Total price with tax: {order.Price}");
        base.Handle(order);
    }
    
}

public class ValidationHandler<T> : OrderHandler<T>
    where T : INumber<T>
{
    public override void Handle(Order<T> order)
    {
        if (order.Price < T.Zero)
        {
            throw new ArgumentException($"Total Price is {order.Price}\nPrice cannot be less than zero");
        }
        
        Console.WriteLine($"[Validation] Проверка пройдена. Итоговая цена: {order.Price}");
        base.Handle(order);
    }
}