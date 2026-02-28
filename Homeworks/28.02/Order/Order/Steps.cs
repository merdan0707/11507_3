using System.Numerics;
namespace Order;

public interface IIdStep <T> where T : INumber<T>
{
    IPriceStep<T> SetId(int id); 
}

public interface IPriceStep<T> where T : INumber<T>
{
    IFinalStep<T> SetBasePrice(T  productBasePrice);
}

public interface IFinalStep<T> where T : INumber<T>
{
    Order<T> Build();
} 