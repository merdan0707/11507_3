namespace FileReader;
public static class SortHeroes
{
    public static void Sort(List<Hero> heroes, int choiceSort, bool isAscending)
    {
        int currentValue = 0;
        int nextValue = 0;
        bool swap;
        for (int i = 0; i < heroes.Count-1; i++)
        {
            for (int j = 0; j < heroes.Count-1-i; j++)
            {
                Hero currentHero = heroes[j];
                Hero nextHero = heroes[j+1];
                
                switch (choiceSort)
                {
                    case 1:
                    {
                        currentValue = currentHero.Strength; 
                        nextValue = nextHero.Strength;
                        break;
                    }
                    case 2:
                    {
                        currentValue = currentHero.Agility;
                        nextValue = nextHero.Agility;
                        break;
                    }
                    case 3:
                    {
                        currentValue = currentHero.Intelligence;
                        nextValue = nextHero.Intelligence;
                        break;
                    }
                }

                swap = false;
                if (isAscending)
                {
                    if (currentValue > nextValue) 
                        swap = true;
                }
                else
                {
                    if (currentValue < nextValue) 
                        swap = true;
                };
                if (swap)
                {
                    Hero temp = heroes[j];
                    heroes[j] =  heroes[j+1];
                    heroes[j+1] =  temp;
                }

            }
        }
    }
}