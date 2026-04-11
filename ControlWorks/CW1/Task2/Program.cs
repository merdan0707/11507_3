namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car();
        car1.Model = "Volkswagen";
        car1.SpeedExceeded += MySpeedLimit;
        car1.Accelerate(90);
        Console.WriteLine($"Current speed: {car1.CurrentSpeed}");
        car1.Accelerate(-100);
        Console.WriteLine($"Current speed: {car1.CurrentSpeed}");
        Console.WriteLine();
        
        car1.Accelerate(110);
        Console.WriteLine($"Current speed: {car1.CurrentSpeed}");
        car1.Accelerate(50);
        Console.WriteLine($"Current speed: {car1.CurrentSpeed}");

    }
    
    static void MySpeedLimit(object? sender, int speed)
    {
        Console.WriteLine($"Сбавьте скорость! Текущая: [{speed}] км/ч");
    }
}
