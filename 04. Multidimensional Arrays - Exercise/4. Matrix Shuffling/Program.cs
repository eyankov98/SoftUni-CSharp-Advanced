int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSize[0];
int columns = matrixSize[1];

string[,] matrix = new string[rows, columns];

for (int row = 0; row < rows; row++)
{
    string[] matrixElements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int column = 0; column < columns; column++)
    {
        matrix[row, column] = matrixElements[column];
    }
}

string command = Console.ReadLine();

while (command != "END")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string currentCommand = commandInfo[0];

    if (currentCommand == "swap" && commandInfo.Length == 5)
    {
        int row1 = int.Parse(commandInfo[1]);
        int column1 = int.Parse(commandInfo[2]);
        int row2 = int.Parse(commandInfo[3]);
        int column2 = int.Parse(commandInfo[4]);

        if (row1 >= 0 && row1 < rows
        && column1 >= 0 && column1 < columns
        && row2 >= 0 && row2 < rows
        && column2 >= 0 && column2 < columns)
        {
            string tempValue = matrix[row1, column1];
            matrix[row1, column1] = matrix[row2, column2];
            matrix[row2, column2] = tempValue;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }

    command = Console.ReadLine();
}