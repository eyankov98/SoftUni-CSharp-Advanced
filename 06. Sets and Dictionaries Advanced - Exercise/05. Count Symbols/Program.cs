SortedDictionary<char, int> symbolsCounts = new SortedDictionary<char, int>();

string input = Console.ReadLine();

foreach (var symbol in input)
{
    if (!symbolsCounts.ContainsKey(symbol))
    {
        symbolsCounts.Add(symbol, 0);
    }

    symbolsCounts[symbol]++;
}

foreach (var symbol in symbolsCounts)
{
    Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
}