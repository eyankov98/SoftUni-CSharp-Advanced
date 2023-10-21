Func<double, double> addingVat = n => n + (n * 0.2);

double[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

for (int i = 0; i < prices.Length; i++)
{
    prices[i] = addingVat(prices[i]);

    Console.WriteLine($"{prices[i]:f2}");
}