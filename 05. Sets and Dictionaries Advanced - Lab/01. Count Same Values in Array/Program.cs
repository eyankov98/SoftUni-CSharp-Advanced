List<double> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToList();

Dictionary<double, int> numberOfOccurrences = new Dictionary<double, int>();

foreach (var number in list)
{
    if (!numberOfOccurrences.ContainsKey(number))
    {
        numberOfOccurrences.Add(number, 0);
    }

    numberOfOccurrences[number]++;
}

foreach (var number in numberOfOccurrences)
{
    Console.WriteLine($"{number.Key} - {number.Value} times");
}