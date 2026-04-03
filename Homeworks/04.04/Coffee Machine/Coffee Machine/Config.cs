namespace Coffee_Machine;

public class Config
{
    public int WaterLeft { get; set; }
    public int MilkLeft { get; set; }
    public int BeansLeft { get; set; }

    public List<Drink> Menu { get; set; } = new();

    public Config()
    {
        Menu = new List<Drink>()
        {
            new Drink("Espresso", 100, 50, 0, 18),
            new Drink("Cappuccino", 170, 50, 150, 18),
            new Drink("Latte", 200, 50, 250, 18),
            new Drink("Americano", 120, 150, 0, 18),
            new Drink("Lavender Raf", 250, 50, 200, 18)
        };
        
        WaterLeft = 15000; // ml
        MilkLeft = 5000; // ml
        BeansLeft = 1000; //gr
    }
    
    
}