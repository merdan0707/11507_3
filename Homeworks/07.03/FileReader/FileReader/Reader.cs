namespace FileReader;

public static class Reader
{
    public static IEnumerable<Hero> ReadHeroesFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            bool isFirstLine = true; // для заголовка

            while ((line = reader.ReadLine()) != null)
            {
                // пропускаем первую строку в файле (Заголовок)
                // пропускаем пустые строки
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                
                // разделяем строку по точке с запятой
                // потом проверяем что строка имеет 4 части
                string[] parts = line.Split(';');
                if (parts.Length == 4)
                {
                    string name = parts[0].Trim();
                    int str = int.Parse(parts[1].Trim());
                    int agi = int.Parse(parts[2].Trim());
                    int intel = int.Parse(parts[3].Trim());
                    yield return new Hero(){
                        Name = name, 
                        Strength = str,
                        Agility = agi, 
                        Intelligence = intel
                    };
                }
            }
        }
    }
}