
class Program
{
    [Obsolete]
    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.Age = 42;
        p1.BirthDate = Convert.ToDateTime("1977-01-01");
        p1.Name = "Jack Daniels";
        p1.idInfo = new IdInfo(666);
        Person p2 = p1.ShallowCopy();
        Person p3 = p1.DeepCopy();
        Console.WriteLine("Original values of p1, p2, p3:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values:");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values:");
        DisplayValues(p3);
        p1.Age = 32;
        p1.BirthDate = Convert.ToDateTime("1900-01-01");
        p1.Name = "Frank";
        p1.idInfo.IdNumber = 7878;
        Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values (reference values have changed):");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values (everything was kept the same):");
        DisplayValues(p3);
    }

    public static void DisplayValues(Person p)
    {
        Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
            p.Name, p.Age, p.BirthDate);
        Console.WriteLine("      ID#: {0:d}", p.idInfo.IdNumber);
    }
}





[Obsolete("", false)]
public class Person
{
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Name { get; set; }
    public IdInfo idInfo { get; set; }

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }

    public Person DeepCopy()
    {
        Person clone = (Person)this.MemberwiseClone();
        clone.idInfo = new IdInfo(idInfo.IdNumber);
        clone.Name = String.Copy(Name);
        return clone;
    }
}
public class IdInfo
{


    public IdInfo(int idNumber)
    {
        this.IdNumber = idNumber;

    }
    public int IdNumber { get; set; }


}
