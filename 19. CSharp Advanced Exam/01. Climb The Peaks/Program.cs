int[] dailyFoodSupplies = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] dailyStamina = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> foodSupplies = new Stack<int>(dailyFoodSupplies);
Queue<int> stamina = new Queue<int>(dailyStamina);

Queue<string> namesOfPeaks = new Queue<string>();
namesOfPeaks.Enqueue("Vihren");
namesOfPeaks.Enqueue("Kutelo");
namesOfPeaks.Enqueue("Banski Suhodol");
namesOfPeaks.Enqueue("Polezhan");
namesOfPeaks.Enqueue("Kamenitza");

Queue<string> conqueredPeaks = new Queue<string>();

int days = 0;

while (foodSupplies.Any() && stamina.Any() && namesOfPeaks.Any())
{
    int sum = foodSupplies.Peek() + stamina.Peek();

    string firstPeak = namesOfPeaks.Peek();

    bool isConquered = false;

    string peak = string.Empty;

    days++;

    if (firstPeak == "Vihren")
    {
        if (sum >= 80)
        {
            peak = namesOfPeaks.Dequeue();
            conqueredPeaks.Enqueue(peak);
            isConquered = true;
        }
    }
    else if (firstPeak == "Kutelo")
    {
        if (sum >= 90)
        {
            peak = namesOfPeaks.Dequeue();
            conqueredPeaks.Enqueue(peak);
            isConquered = true;
        }
    }
    else if (firstPeak == "Banski Suhodol")
    {
        if (sum >= 100)
        {
            peak = namesOfPeaks.Dequeue();
            conqueredPeaks.Enqueue(peak);
            isConquered = true;
        }
    }
    else if (firstPeak == "Polezhan")
    {
        if (sum >= 60)
        {
            peak = namesOfPeaks.Dequeue();
            conqueredPeaks.Enqueue(peak);
            isConquered = true;
        }
    }
    else if (firstPeak == "Kamenitza")
    {
        if (sum >= 70)
        {
            peak = namesOfPeaks.Dequeue();
            conqueredPeaks.Enqueue(peak);
            isConquered = true;
        }
    }

    foodSupplies.Pop();
    stamina.Dequeue();

    if (days == 7)
    {
        break;
    }
}

if (conqueredPeaks.Count == 5)
{
    Console.WriteLine($"Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (conqueredPeaks.Any())
{
    Console.WriteLine("Conquered peaks:");
    foreach (var mountainPeak in conqueredPeaks)
    {
        Console.WriteLine($"{mountainPeak}");
    }
}