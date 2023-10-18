Dictionary<string, Dictionary<string, int>> colorsClothes = new Dictionary<string, Dictionary<string, int>>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

    string color = input[0];

    if (!colorsClothes.ContainsKey(color))
    {
        colorsClothes.Add(color, new Dictionary<string, int>());
    }

    for (int j = 1; j < input.Length; j++)
    {
        string currentWear = input[j];

        if (!colorsClothes[color].ContainsKey(currentWear))
        {
            colorsClothes[color].Add(currentWear, 0);
        }

        colorsClothes[color][currentWear]++;
    }
}

string[] colorWearToFind = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string colorToFind = colorWearToFind[0];
string wearToFind = colorWearToFind[1];

foreach (var colorClothes in colorsClothes)
{
    Console.WriteLine($"{colorClothes.Key} clothes:");

    foreach (var clothesCount in colorClothes.Value)
    {
        if (colorClothes.Key == colorToFind && clothesCount.Key == wearToFind)
        {
            Console.WriteLine($"* {clothesCount.Key} - {clothesCount.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {clothesCount.Key} - {clothesCount.Value}");
        }
    }
}