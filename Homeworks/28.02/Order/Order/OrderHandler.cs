using System.Numerics;

namespace Order;

public abstract class OrderHandler<T> where T : INumber<T>
{
    protected OrderHandler<T> _nextHandler;

    public OrderHandler<T> SetNext(OrderHandler<T> nextHandler)
    {
        _nextHandler = nextHandler;
        return nextHandler;
    }

    public virtual void Handle(Order<T> order)
    {
        if  (_nextHandler != null)
        {
            _nextHandler.Handle(order);
        }
    }
}