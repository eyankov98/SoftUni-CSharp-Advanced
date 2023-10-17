HashSet<string> vipGuests = new HashSet<string>();
HashSet<string> regularGuests = new HashSet<string>();

string command = Console.ReadLine();

while (command != "PARTY")
{
    string currentGuest = command;

    if (Char.IsDigit(currentGuest[0]))
    {
        vipGuests.Add(currentGuest);
    }
    else
    {
        regularGuests.Add(currentGuest);
    }

    command = Console.ReadLine();
}

while (command != "END")
{
    string currentGuest = command;

    if (Char.IsDigit(currentGuest[0]))
    {
        vipGuests.Remove(currentGuest);
    }
    else
    {
        regularGuests.Remove(currentGuest);
    }

    command = Console.ReadLine();
}

Console.WriteLine(vipGuests.Count + regularGuests.Count);

if (vipGuests.Any())
{
    foreach (var vipGuest in vipGuests)
    {
        Console.WriteLine(vipGuest);
    }
}

if (regularGuests.Any())
{
    foreach (var regularGuest in regularGuests)
    {
        Console.WriteLine(regularGuest);
    }
}