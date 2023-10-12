Queue<string> trafficJam = new Queue<string>();

int numberOfCars = int.Parse(Console.ReadLine());

string command = Console.ReadLine();

int carCount = 0;

while (command != "end")
{
    if (command != "green")
    {
        trafficJam.Enqueue(command);
        command = Console.ReadLine();
        continue;
    }

    int currentCount = numberOfCars;

    while (trafficJam.Any() && currentCount > 0)
    {
        Console.WriteLine($"{trafficJam.Dequeue()} passed!");

        currentCount--;

        carCount++;
    }

    command = Console.ReadLine();
}

Console.WriteLine($"{carCount} cars passed the crossroads.");