Stack<int> numbers = new Stack<int>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int[] inputNumbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int command = inputNumbers[0];

    if (command == 1)
    {
        int number = inputNumbers[1];
        numbers.Push(number);
    }
    else if (command == 2)
    {
        numbers.Pop();
    }
    else if (command == 3)
    {
        if (numbers.Any())
        {
            Console.WriteLine(numbers.Max());
        }
    }
    else if (command == 4)
    {
        if (numbers.Any())
        {
            Console.WriteLine(numbers.Min());
        }
    }
}

Console.WriteLine(string.Join(", ", numbers));