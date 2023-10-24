namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        Family family = new Family();

        int countOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i  < countOfPeople; i ++)
        {
            string[] personInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);

            Person person = new Person(name, age);

            family.AddMember(person);
        }

        Person oldestPerson = family.GetOldestMember();

        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}