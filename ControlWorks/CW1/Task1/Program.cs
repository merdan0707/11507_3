namespace Task1;

class Program
{
    static void Main(string[] args)
    {
        Organization<Engineer> orgEngineer = new Organization<Engineer>();
        
        Company alpha = new Company(){Name = "Alpha"};
        Engineer engineer = new Engineer();
        engineer.Name = "Merdan";
        engineer.Employer = alpha;
        Console.WriteLine($"Name: {engineer.Name}\nCompany: {engineer.Employer.Name}");
        
        
        Company beta = new Company(){Name = "Beta"};
        var engineerForBeta = orgEngineer.HireReplacement(engineer, beta);
        Console.WriteLine($"Name: {engineerForBeta.Name}\nCompany: {engineerForBeta.Employer.Name}");

    }
}

public class Engineer : Worker
{
}