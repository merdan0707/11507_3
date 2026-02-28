using System.Numerics;
using Order;

namespace Order;

public class OrderBuilder<T>: IIdStep<T>, IPriceStep<T>,  IFinalStep<T> 
    where T: INumber<T>
{
    Order<T> _order = new Order<T>();
    private OrderBuilder() { }
    
    public static IIdStep<T> StartOrder()
    {
        return new OrderBuilder<T>();
    }
    
    public IPriceStep<T> SetId(int id)
    {
        _order.Id = id;
        return this;
    }

    public IFinalStep<T> SetBasePrice(T productBasePrice)
    {
        _order.Price = productBasePrice;
        return this;
    }

    public Order<T> Build()
    {
        return _order;
    }
}