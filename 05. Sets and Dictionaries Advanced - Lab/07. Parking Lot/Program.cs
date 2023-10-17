HashSet<string> carsNumbers = new HashSet<string>();

string command = Console.ReadLine();

while (command != "END")
{
    string[] input = command
        .Split(",", StringSplitOptions.RemoveEmptyEntries);

    string currendCommand = input[0];
    string carNumber = input[1];

    if (currendCommand == "IN")
    {
        carsNumbers.Add(carNumber);
    }
    else if (currendCommand == "OUT")
    {
        carsNumbers.Remove(carNumber);
    }

    command = Console.ReadLine();
}

if (carsNumbers.Any())
{
    foreach (var carNumber in carsNumbers)
    {
        Console.WriteLine(carNumber);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}