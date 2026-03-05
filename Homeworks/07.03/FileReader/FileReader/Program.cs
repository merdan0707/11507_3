namespace FileReader;

class Program
{
    static void Main(string[] args)
    {
        char keypass = 'y';
        while (keypass == 'y' || keypass == 'Y')
        {
            // ! РАСПОЛОЖЕНИЕ файла!
            string filePath = @"C:\Users\User\Desktop\11507_3\Homeworks\07.03\heroes.txt";
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File not found! (The wrong file path)");
                return;
            }

            #region Вывод списка героев, затем идёт сортировка
            Console.WriteLine("Reading file...");
            Console.WriteLine("----- All Heroes ------");
            foreach (var hero in Reader.ReadHeroesFromFile(filePath))
                Console.WriteLine(hero);
            
            Console.WriteLine("Press 'Enter' to go to Sorting");
            Console.ReadLine();
            #endregion

            #region Сортировка
            // Для сортировки нам нужно видеть всех героев, поэтому загружаем их в список
            // Мы читаем файл второй раз через тот же метод с yield return
            List<Hero> heroesList = new List<Hero>();
            foreach (var hero in Reader.ReadHeroesFromFile(filePath))
                heroesList.Add(hero);
            
            string choiceInput;
            int choiceSort;
            while (true)
            {
                Console.WriteLine("|=== Sorting settings ===|" +
                                  "\nBy what characteristic to sort?" +
                                  "\n1 - Strength" +
                                  "\n2 - Agility" +
                                  "\n3 - Intelligence");
                Console.Write("Input: ");
                choiceInput = Console.ReadLine();
                if (choiceInput == "1" ||  choiceInput == "2" || choiceInput == "3")
                    break;
                else Console.WriteLine("Please enter a valid option");
            }
            choiceSort = int.Parse(choiceInput);
            
            
            string orderInput;
            bool isAscending;
            while (true)
            {
                Console.WriteLine("Порядок сортировки" +
                                  "\n1 - По возрастанию" +
                                  "\n2 - По убыванию");
                Console.Write("Input: ");
                orderInput = Console.ReadLine();
                if (orderInput == "1" ||  orderInput == "2")
                    break;
                else Console.WriteLine("Please enter a valid option");
            }
            isAscending = orderInput == "1"? true : false;
            #endregion
            
            //Готовый список с сортировкой 
            SortHeroes.Sort(heroesList, choiceSort, isAscending);
            Console.WriteLine("\n|===  Sorted list  ===|");
            foreach (var hero in heroesList)
            {
                Console.WriteLine(hero);
            }
            

            Console.WriteLine("If you want to continue press 'y', else press any key\n");
            keypass = Console.ReadKey().KeyChar;

        }
    }
}
