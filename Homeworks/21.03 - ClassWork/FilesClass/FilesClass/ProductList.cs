using System.Text.Json;
namespace FilesClass;


public class ProductList
{
    public static void Run()
    {

        Console.Clear();
        
        var fileDirectory = Directory.GetCurrentDirectory();
        var filePath = Path.Combine(fileDirectory, "products.json");
        List<Product> listProducts;
            
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            listProducts = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            Console.WriteLine("Data loaded from file");
        }
        else
        {
            listProducts = new List<Product>()
            {
                new Product("Bread", 3, 70),
                new Product("Cheese", 5, 90),
                new Product("Pasta", 6, 100),
            };
            
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(listProducts, options);
            File.WriteAllText(filePath, jsonString + Environment.NewLine);
        }

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. Delete a product");
            Console.WriteLine("3. Display a product");
            Console.WriteLine("4. Exit");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Choose correct option");
                continue;
            }
            switch (choice)
            {
                case 1:
                {
                    AddProduct(listProducts, filePath);
                    break;
                }
                case 2:
                {
                    DeleteProduct(listProducts, filePath);
                    break;
                }
                case 3:
                {
                    Display(listProducts);
                    break;
                }
                case 4: 
                    return;
                default:
                    Console.WriteLine("Choose correct option (1-4)\n");
                    break;
            }
        }
    }

    public static void AddProduct(List<Product> listProducts, string filePath)
    {
        Console.WriteLine();
        Console.WriteLine("Name - Amount - Price");
        var inputText = Console.ReadLine().Split(" ");
        var newProduct = new Product(
            inputText[0], 
            int.Parse(inputText[1]), 
            decimal.Parse(inputText[2]));
        
        listProducts.Add(newProduct);
        File.WriteAllText(filePath, JsonSerializer.Serialize(
                listProducts, new JsonSerializerOptions(){WriteIndented = true}) + Environment.NewLine);
        Console.WriteLine("Product has added");
    }

    public static void DeleteProduct(List<Product> listProducts, string filePath)
    {
        if (listProducts.Count == 0)
        {
            Console.WriteLine("List is empty");
            return;
        }
        
        Console.WriteLine();
        Console.WriteLine("Which one do you want to delete?");
        Display(listProducts);

        while (true)
        {
            Console.Write("\nYour choice (or 0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Choose correct product");
                continue;
            }
            
            if (choice==0) return;

            if (choice > 0 && choice <= listProducts.Count)
            {
                listProducts.RemoveAt(choice-1);
                File.WriteAllText(filePath,JsonSerializer.Serialize(
                    listProducts, new JsonSerializerOptions(){WriteIndented = true}) + Environment.NewLine);
                Console.WriteLine("Product deleted successfully!");
                return;
            }
            else
            {
                Console.WriteLine("Choose correct product");
                continue;
            }
        }
    }

    public static void Display(List<Product> listProducts)
    {

        if (listProducts == null || listProducts.Count==0)
        {
            Console.WriteLine("List of products is empty");
            return;
        }

        for (int i = 0; i < listProducts.Count; i++)
        {
            Console.WriteLine($"{i+1}_ {listProducts[i]}");
        }
        Console.WriteLine();
    }
}