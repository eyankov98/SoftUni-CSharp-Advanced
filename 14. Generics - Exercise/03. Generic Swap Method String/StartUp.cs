List<string> items = new List<string>();

int countOfNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < countOfNumber; i++)
{
    string item = Console.ReadLine();

    items.Add(item);
}

int[] indices = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int firstIndices = indices[0];
int secondIndices = indices[1];

Swap(firstIndices, secondIndices, items);

foreach (string item in items)
{
    Console.WriteLine($"{typeof(string)}: {item}");
}

static void Swap<T>(int firstIndex, int secondIndex, List<T> items)
{
    //T temp = items[firstIndex];
    //items[firstIndex] = items[secondIndex];
    //items[secondIndex] = temp;

    (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
}