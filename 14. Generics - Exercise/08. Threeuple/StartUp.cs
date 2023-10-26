namespace Threeuple;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] personInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string firstName = personInfo[0];
        string lastName = personInfo[1];
        string address = personInfo[2];
        string town = string.Join(" ", personInfo[3..]); // '..' - (to the end) 

        string[] drinkingBeerInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string name = drinkingBeerInfo[0];
        int litersOfBeer = int.Parse(drinkingBeerInfo[1]);
        bool drunkOrNot = drinkingBeerInfo[2] == "drunk";

        string[] bankInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string accountName = bankInfo[0];
        double accountBalance = double.Parse(bankInfo[1]);
        string bankName = bankInfo[2];

        CustomeThreeuple<string, string, string> nameAddressTown = new CustomeThreeuple<string, string, string>($"{firstName} {lastName}", address, town);
        CustomeThreeuple<string, int, bool> nameLitersOfBeerDrunkOrNot = new CustomeThreeuple<string, int, bool>(name, litersOfBeer, drunkOrNot);
        CustomeThreeuple<string, double, string> nameAccountBankBankName = new CustomeThreeuple<string, double, string>(accountName, accountBalance, bankName);

        Console.WriteLine(nameAddressTown.ToString());
        Console.WriteLine(nameLitersOfBeerDrunkOrNot.ToString());
        Console.WriteLine(nameAccountBankBankName.ToString());
    }
}