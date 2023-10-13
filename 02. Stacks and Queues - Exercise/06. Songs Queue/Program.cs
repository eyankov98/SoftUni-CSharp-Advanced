string[] inputSongs = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

Queue<string> songsQueue = new Queue<string>(inputSongs);

while (songsQueue.Any())
{
    string[] commandInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string currentCommand = commandInfo[0];

    if (currentCommand == "Play")
    {
        songsQueue.Dequeue();
    }
    else if (currentCommand == "Add")
    {
        //string song = string.Join(" ", commandInfo.Skip(1));
        string song = string.Join(" ", commandInfo[1..]);

        if (songsQueue.Contains(song))
        {
            Console.WriteLine($"{song} is already contained!");
        }
        else
        {
            songsQueue.Enqueue(song);
        }
    }
    else if (currentCommand == "Show")
    {
        Console.WriteLine(string.Join(", ", songsQueue));
    }
}

Console.WriteLine("No more songs!");