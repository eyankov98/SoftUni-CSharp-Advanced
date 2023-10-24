namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        int countOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfPeople; i++)
        {
            string[] personInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);

            Person person = new Person(name, age);

            persons.Add(person);
        }

        foreach (var person in persons.OrderBy(p => p.Name))
        {
            if (person.Age > 30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}