int[] nsxNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int elementsToPop = nsxNumbers[1];
int numberSearch = nsxNumbers[2];

Queue<int> numbers = new Queue<int>(inputNumbers);

for (int i = 0; i < elementsToPop; i++)
{
    numbers.Dequeue();
}

if (numbers.Contains(numberSearch))
{
    Console.WriteLine("true");
}
else if (!numbers.Contains(numberSearch) && numbers.Any())
{
    Console.WriteLine(numbers.Min());
}
else if (!numbers.Any())
{
    Console.WriteLine(0);
}