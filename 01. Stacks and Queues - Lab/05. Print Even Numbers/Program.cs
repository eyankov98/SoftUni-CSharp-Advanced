int[] inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> numbers = new Queue<int>(inputNumbers);

string result = string.Empty;

while (numbers.Any())
{
    int number = numbers.Dequeue();

    if (number % 2 == 0)
    {
        result = result + $"{number}, ";
    }
}

Console.WriteLine(result.TrimEnd(' ', ','));