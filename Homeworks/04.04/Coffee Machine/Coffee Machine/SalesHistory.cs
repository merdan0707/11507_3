namespace Coffee_Machine;

public class SalesHistory
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public SalesHistory(DateTime date, string name, int price)
    {
        Date = date;
        Name = name;
        Price = price;
    }

    public SalesHistory() { }
}