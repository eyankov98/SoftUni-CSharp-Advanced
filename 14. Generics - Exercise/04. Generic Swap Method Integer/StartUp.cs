List<int> items = new List<int>();

int countOfNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < countOfNumber; i++)
{
    int item = int.Parse(Console.ReadLine());

    items.Add(item);
}

int[] indices = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int firstIndices = indices[0];
int secondIndices = indices[1];

Swap(firstIndices, secondIndices, items);

foreach (int item in items)
{
    Console.WriteLine($"{typeof(int)}: {item}");
}

static void Swap<T>(int firstIndex, int secondIndex, List<T> items)
{
    //T temp = items[firstIndex];
    //items[firstIndex] = items[secondIndex];
    //items[secondIndex] = temp;

    (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
}