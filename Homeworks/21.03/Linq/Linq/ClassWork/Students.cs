namespace Linq;

public class Classroom
{
    public List<string> Students = new List<string>();
}

public class Student
{
    public static void Run()
    {
        Classroom[] classes =
        {
            new Classroom { Students = { "Pavel", "Ivan", "Petr" } },
            new Classroom { Students = { "Anna", "Ilya", "Vladimir" } },
            new Classroom { Students = { "Bulat", "Alex", "Galina" } }
        };
        var allStudents = GetAllStudents(classes);
        Array.Sort(allStudents);
        Console.WriteLine(string.Join(" ", allStudents));
    }

    public static string[] GetAllStudents(Classroom[] classes)
    {
        return classes
            .SelectMany(clas => clas.Students)
            .ToArray();
    }
}