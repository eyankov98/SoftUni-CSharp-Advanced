int[] inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> countClothes = new Stack<int>(inputNumbers);

int capacityOfRack = int.Parse(Console.ReadLine());

int currentCapacityOfRack = capacityOfRack;

int countRacks = 1;

while (countClothes.Any())
{
    currentCapacityOfRack = currentCapacityOfRack - countClothes.Peek();

    if (currentCapacityOfRack < 0)
    {
        currentCapacityOfRack = capacityOfRack;

        countRacks++;

        continue;
    }

    countClothes.Pop();
}

Console.WriteLine(countRacks);