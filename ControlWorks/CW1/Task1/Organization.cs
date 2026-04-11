namespace Task1;

public class Organization<T> where T : Worker, new() 
{
    public T HireReplacement(T oldWorker, Company newCompany)
    {
        T newWorker = new T();
        newWorker.Name = oldWorker.Name;
        newWorker.Employer = newCompany;
        return newWorker;
    }
}