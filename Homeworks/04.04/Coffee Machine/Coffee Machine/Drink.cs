namespace Coffee_Machine;

public class Drink
{
    public string Name { get; set; }
    public int Price { get; set; }
    
    public int TakeWater { get; set; }
    public int TakeMilk { get; set; }
    public int TakeBeans { get; set; }
    
    public Drink(){}

    public Drink(string name, int price, int takeWater, int takeMilk, int takeBeans)
    {
        Name = name;
        Price = price;
        TakeWater = takeWater;
        TakeMilk = takeMilk;
        TakeBeans = takeBeans;
    }
}