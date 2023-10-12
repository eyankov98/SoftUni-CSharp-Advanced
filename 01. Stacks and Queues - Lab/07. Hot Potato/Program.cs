string[] inputNames = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

int n = int.Parse(Console.ReadLine());

Queue<string> people = new Queue<string>(inputNames);

while (people.Count > 1)
{
    for (int i = 1; i < n; i++)
    {
        string name = people.Dequeue();

        people.Enqueue(name);
    }

    Console.WriteLine($"Removed {people.Dequeue()}");
}

Console.WriteLine($"Last is {people.Peek()}");