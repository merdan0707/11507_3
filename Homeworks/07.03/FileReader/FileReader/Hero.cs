namespace FileReader;

public class Hero
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }

    public override string ToString()
    {
        return $"{Name,-15} | Сила: {Strength,2} | Ловкость: {Agility,2} | Интеллект: {Intelligence,2}";
    }
}