namespace Tuple;

public class StartUp
{
    static void Main(string[] args)
    {

        string[] personInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string firstName = personInfo[0];
        string lastName = personInfo[1];
        string address = personInfo[2];

        string[] drinkingBeerInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string name = drinkingBeerInfo[0];
        int litersOfBeer = int.Parse(drinkingBeerInfo[1]);

        string[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        int integerNumber = int.Parse(numbers[0]);
        double doubleNumber = double.Parse(numbers[1]);

        CustomTuple<string, string> nameAddress = new CustomTuple<string, string>($"{firstName} {lastName}", address);
        CustomTuple<string, int> nameLitersOfBeer = new CustomTuple<string, int>(name, litersOfBeer);
        CustomTuple<int, double> integerDouble = new CustomTuple<int, double>(integerNumber, doubleNumber);

        Console.WriteLine(nameAddress.ToString());
        Console.WriteLine(nameLitersOfBeer.ToString());
        Console.WriteLine(integerDouble.ToString());

    }
}