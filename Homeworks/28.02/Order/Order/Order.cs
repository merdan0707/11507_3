using System.Numerics;
namespace Order;

public class Order<T> where T: INumber<T>
{
    public int Id { get; set; }
    public T Price { get; set; }
}