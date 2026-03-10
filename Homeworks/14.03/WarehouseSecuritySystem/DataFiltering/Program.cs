namespace DataFiltering;

class Program
{
    static void Main(string[] args)
    {
        #region Уровень 2: Фильтрация данных
       
        var employees = new List<Employee>()
        {
            new Employee("Brad", 50001m, 6f),
            new Employee("John", 4000m, 40f),  
            new Employee("Samuel", 70000m, 5.1f),
            new Employee("Lisa", 500m, 4.5f),
            new Employee("Michiel", 150000m, 7f)
        };
       
        new Employee().FilterEmployees(employees, SimplePredicate);
       
        bool SimplePredicate (Employee emp)
        {
            if (emp.salary > 50000m && emp.experience > 5f)
                return true;
            return false;
        }
       
        #endregion

    }
}