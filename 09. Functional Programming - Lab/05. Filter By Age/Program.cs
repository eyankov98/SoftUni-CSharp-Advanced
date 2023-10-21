int peopleCount = int.Parse(Console.ReadLine());
List<Person> people = ReadPeople(peopleCount);

string condition = Console.ReadLine();
int ageThreshold = int.Parse(Console.ReadLine());
string format = Console.ReadLine();

Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
Action<Person> printer = CreatePrinter(format);

PrintFilteredPeople(people, filter, printer);


static List<Person> ReadPeople(int peopleCount)
{
    List<Person> people = new List<Person>();

    for (int i = 0; i < peopleCount; i++)
    {
        string[] currentPerson = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Person person = new Person(currentPerson[0], int.Parse(currentPerson[1]));

        people.Add(person);
    }
    return people;
}

static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
{
    Func<Person, bool> filter = null;

    if (condition == "younger")
    {
        filter = Person => Person.Age < ageThreshold;
    }
    else if (condition == "older")
    {
        filter = Person => Person.Age >= ageThreshold;
    }

    return filter;
}

static Action<Person> CreatePrinter(string format)
{
    Action<Person> printer = null;

    if (format == "name")
    {
        printer = person => Console.WriteLine(person.Name);
    }
    else if (format == "age")
    {
        printer = person => Console.WriteLine(person.Age);
    }
    else if (format == "name age")
    {
        printer = person => Console.WriteLine($"{person.Name} - {person.Age}");
    }

    return printer;
}

static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
{
    foreach (var person in people.Where(filter))
    {
        printer(person);
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}