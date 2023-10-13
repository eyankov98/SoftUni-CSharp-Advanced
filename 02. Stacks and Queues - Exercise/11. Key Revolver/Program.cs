int bulletPrice = int.Parse(Console.ReadLine());

int barrelSize = int.Parse(Console.ReadLine());

int[] bullets = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] locks = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> stackOfBullets = new Stack<int>(bullets);

Queue<int> queueOfLocks = new Queue<int>(locks);

int valueOfIntelligence = int.Parse(Console.ReadLine());

int initialBulletsCount = stackOfBullets.Count;

int currentBarrelSize = barrelSize;

for (int i = 0; i < initialBulletsCount; i++)
{
    if (stackOfBullets.Pop() <= queueOfLocks.Peek())
    {
        Console.WriteLine("Bang!");

        queueOfLocks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    currentBarrelSize--;

    if (currentBarrelSize == 0 && stackOfBullets.Any())
    {
        Console.WriteLine("Reloading!");

        currentBarrelSize = barrelSize;
    }

    if (!stackOfBullets.Any() && queueOfLocks.Any())
    {
        Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");

        return;
    }

    if (!queueOfLocks.Any())
    {
        Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${valueOfIntelligence - (initialBulletsCount - stackOfBullets.Count) * bulletPrice}");

        return;
    }
}