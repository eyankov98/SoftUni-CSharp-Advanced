SortedSet<string> periodicElements = new SortedSet<string>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] element = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    periodicElements.UnionWith(element);
}

Console.WriteLine(string.Join(" ", periodicElements));