int[] programmerTime = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] numberOfTasks = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> times = new Queue<int>(programmerTime);
Stack<int> tasks = new Stack<int>(numberOfTasks);

Dictionary<string, int> rubberDucks = new Dictionary<string, int>()
{
    { "Darth Vader Ducky", 0 },
    { "Thor Ducky", 0 },
    { "Big Blue Rubber Ducky", 0 },
    { "Small Yellow Rubber Ducky", 0 }
};

while (times.Any() && tasks.Any())
{
    int currentTime = times.Dequeue();
    int currentTask = tasks.Pop();

    int result = currentTime * currentTask;

    if (result >= 0 && result <= 60)
    {
        rubberDucks["Darth Vader Ducky"]++;
    }
    else if (result >= 61 && result <= 120)
    {
        rubberDucks["Thor Ducky"]++;
    }
    else if (result >= 121 && result <= 180)
    {
        rubberDucks["Big Blue Rubber Ducky"]++;
    }
    else if (result >= 181 && result <= 240)
    {
        rubberDucks["Small Yellow Rubber Ducky"]++;
    }
    else if (result > 240)
    {
        currentTask -= 2;

        tasks.Push(currentTask);
        times.Enqueue(currentTime);
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

foreach (var rubberDuck in rubberDucks)
{
    Console.WriteLine($"{rubberDuck.Key}: {rubberDuck.Value}");
}