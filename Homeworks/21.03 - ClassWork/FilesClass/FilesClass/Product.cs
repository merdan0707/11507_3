namespace FilesClass;

public class Product
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }

    public Product() { }

    public Product(string name, int amount, decimal price)
    {
        Name = name;
        Amount = amount;
        Price = price;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Amount: {Amount}, Price: {Price}";
    }
}