Dictionary<string, Dictionary<string, List<string>>> continentesCountryCities = new Dictionary<string, Dictionary<string, List<string>>>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string continent = input[0];
    string country = input[1];
    string city = input[2];

    if (!continentesCountryCities.ContainsKey(continent))
    {
        continentesCountryCities.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!continentesCountryCities[continent].ContainsKey(country))
    {
        continentesCountryCities[continent].Add(country, new List<string>());
    }

    continentesCountryCities[continent][country].Add(city);
}

foreach (var (continent, countries) in continentesCountryCities)
{
    Console.WriteLine($"{continent}:");

    foreach (var (country, cities) in countries)
    {
        Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
    }
}