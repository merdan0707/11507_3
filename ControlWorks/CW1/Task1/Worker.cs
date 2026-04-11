namespace Task1;

public class Worker
{
    public string Name { get; set; }
    public Company Employer { get; set; }

    public Worker() { }

    public Worker(string name,  Company employer)
    {
        Name = name;
        Employer = employer;
    }
}