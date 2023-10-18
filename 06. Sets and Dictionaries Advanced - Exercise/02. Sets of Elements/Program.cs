HashSet<int> firstSet = new HashSet<int>();
HashSet<int> SecondSet = new HashSet<int>();

int[] countOfElements = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = countOfElements[0];
int m = countOfElements[1];

for (int i = 0; i < n; i++)
{
    int number = int.Parse(Console.ReadLine());

    firstSet.Add(number);
}

for (int i = 0; i < m; i++)
{
    int number = int.Parse(Console.ReadLine());

    SecondSet.Add(number);
}

firstSet.IntersectWith(SecondSet);

Console.WriteLine(string.Join(" ", firstSet));