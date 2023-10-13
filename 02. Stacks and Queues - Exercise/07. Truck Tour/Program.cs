int n = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new Queue<int[]>();

int litersPerKilometer = 1;

for (int i = 0; i < n; i++)
{
    int[] inputNumber = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    pumps.Enqueue(inputNumber);
}

int startPetrolPump = 0;

while (true)
{
    bool isComplete = true;
    int totalLiters = 0;

    foreach (var number in pumps)
    {
        int liters = number[0];
        int kilometers = number[1];

        totalLiters = totalLiters + liters;

        totalLiters = totalLiters - kilometers * litersPerKilometer;

        if (totalLiters < 0)
        {
            int[] currentPumps = pumps.Dequeue();

            pumps.Enqueue(currentPumps);

            startPetrolPump++;

            isComplete = false;

            break;
        }
    }

    if (isComplete)
    {
        Console.WriteLine(startPetrolPump);
        break;
    }
}