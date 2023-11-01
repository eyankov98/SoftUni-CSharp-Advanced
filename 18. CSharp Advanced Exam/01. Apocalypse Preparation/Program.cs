int[] firstNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] secondNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();


Queue<int> textiles = new Queue<int>(firstNumbers);
Stack<int> medicaments = new Stack<int>(secondNumbers);

Dictionary<string, int> items = new Dictionary<string, int>();

while (textiles.Any() && medicaments.Any())
{
    int sum = textiles.Peek() + medicaments.Peek();

    if (sum == 30)
    {
        if (!items.ContainsKey("Patch"))
        {
            items.Add("Patch", 0);
        }

        items["Patch"]++;

        textiles.Dequeue();
        medicaments.Pop();
    }
    else if (sum == 40)
    {
        if (!items.ContainsKey("Bandage"))
        {
            items.Add("Bandage", 0);
        }

        items["Bandage"]++;

        textiles.Dequeue();
        medicaments.Pop();
    }
    else if (sum >= 100)
    {
        if (!items.ContainsKey("MedKit"))
        {
            items.Add("MedKit", 0);
        }

        items["MedKit"]++;

        textiles.Dequeue();
        medicaments.Pop();

        sum -= 100;

        if (medicaments.Any())
        {
            int removeMedicament = medicaments.Pop();
            removeMedicament += sum;
            medicaments.Push(removeMedicament);
        }
    }
    else
    {
        textiles.Dequeue();
        int removeMedicament = medicaments.Pop();
        removeMedicament += 10;
        medicaments.Push(removeMedicament);
    }
}

items = items.OrderByDescending(x => x.Value)
    .ThenBy(x => x.Key)
    .ToDictionary(x => x.Key, x => x.Value);

if (textiles.Any())
{
    Console.WriteLine("Medicaments are empty.");
    foreach (var item in items)
    {
        if (item.Value > 0)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}
else if (medicaments.Any())
{
    Console.WriteLine("Textiles are empty.");
    foreach (var item in items)
    {
        if (item.Value > 0)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}
else if (!textiles.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
    foreach (var item in items)
    {
        if (item.Value > 0)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
}