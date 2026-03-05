namespace FileReader;

public class Hero
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    
    // public Hero(string name, int strength, int agility, int intelligence)
    // {
    //     Name = name;
    //     Strength = strength;
    //     Agility = agility;
    //     Intelligence = intelligence;
    // }

    public override string ToString()
    {
        return $"{Name,-15} | Сила: {Strength,2} | Ловкость: {Agility,2} | Интеллект: {Intelligence,2}";
    }
}