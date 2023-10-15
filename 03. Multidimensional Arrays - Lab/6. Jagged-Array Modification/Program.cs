int rows = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[rows][];

jaggedArray[0] = new int[rows];

for (int row = 0; row < rows; row++)
{
    jaggedArray[row] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

string command = Console.ReadLine();

while (command != "END")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string currentCommand = commandInfo[0];
    int row = int.Parse(commandInfo[1]);
    int colum = int.Parse(commandInfo[2]);
    int value = int.Parse(commandInfo[3]);

    if (row < 0 || jaggedArray.Length <= row || colum < 0 || jaggedArray[row].Length <= colum)
    {
        Console.WriteLine("Invalid coordinates");
    }
    else if (currentCommand == "Add")
    {
        jaggedArray[row][colum] = jaggedArray[row][colum] + value;
    }
    else if (currentCommand == "Subtract")
    {
        jaggedArray[row][colum] = jaggedArray[row][colum] - value;
    }

    command = Console.ReadLine();
}

for (int row = 0; row < jaggedArray.Length; row++)
{
    for (int colum = 0; colum < jaggedArray[row].Length; colum++)
    {
        Console.Write($"{jaggedArray[row][colum]} ");
    }

    Console.WriteLine();
}