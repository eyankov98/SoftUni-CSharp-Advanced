Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

string command = Console.ReadLine();

while (command != "Revision")
{
    string[] input = command
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string shop = input[0];
    string product = input[1];
    double price = double.Parse(input[2]);

    if (!shops.ContainsKey(shop))
    {
        shops.Add(shop, new Dictionary<string, double>());
    }

    if (!shops[shop].ContainsKey(product))
    {
        shops[shop].Add(product, price);
    }

    shops[shop][product] = price;

    command = Console.ReadLine();
}

shops = shops.OrderBy(x => x.Key)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var (shop, products) in shops)
{
    Console.WriteLine($"{shop}->");

    foreach (var (product, price) in products)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}