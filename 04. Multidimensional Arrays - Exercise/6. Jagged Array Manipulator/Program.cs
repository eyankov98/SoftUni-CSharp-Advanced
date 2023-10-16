int rows = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[rows][];

for (int row = 0; row < rows; row++)
{
    int[] columns = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    jaggedArray[row] = columns;
}

for (int row = 0; row < rows - 1; row++)
{
    if (jaggedArray[row].Length == jaggedArray[row + 1].Length) 
    {
        for (int column = 0; column < jaggedArray[row].Length; column++) 
        {
            jaggedArray[row][column] = jaggedArray[row][column] * 2;
            jaggedArray[row + 1][column] = jaggedArray[row + 1][column] * 2;
        }
    }
    else 
    {
        for (int column = 0; column < jaggedArray[row].Length; column++)
        {
            jaggedArray[row][column] = jaggedArray[row][column] / 2;
        }

        for (int column = 0; column < jaggedArray[row + 1].Length; column++)
        {
            jaggedArray[row + 1][column] = jaggedArray[row + 1][column] / 2;
        }
    }
}

string command = Console.ReadLine();

while (command != "End")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string currentCommand = commandInfo[0];
    int row = int.Parse(commandInfo[1]);
    int column = int.Parse(commandInfo[2]);
    int value = int.Parse(commandInfo[3]);

    if (currentCommand == "Add"
            && row >= 0 && row < jaggedArray.Length
        && column >= 0 && column < jaggedArray[row].Length)
    {
        jaggedArray[row][column] = jaggedArray[row][column] + value;
    }
    else if (currentCommand == "Subtract"
        && row >= 0 && row < jaggedArray.Length
    && column >= 0 && column < jaggedArray[row].Length)
    {
        jaggedArray[row][column] = jaggedArray[row][column] - value;
    }

    command = Console.ReadLine();
}

for (int row = 0; row < rows; row++)
{
    for (int column = 0; column < jaggedArray[row].Length; column++)
    {
        Console.Write($"{jaggedArray[row][column]} ");
    }

    Console.WriteLine();
}