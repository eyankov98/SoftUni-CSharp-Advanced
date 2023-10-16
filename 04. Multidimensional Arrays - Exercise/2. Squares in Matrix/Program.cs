int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSize[0];
int columns = matrixSize[1];

char[,] matrix = new char[rows, columns];

for (int row = 0; row < rows; row++)
{
    char[] matrixElements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int column = 0; column < columns; column++)
    {
        matrix[row, column] = matrixElements[column];
    }
}

int count = 0;

for (int row = 0; row < rows - 1; row++)
{
    for (int column = 0; column < columns - 1; column++)
    {
        if (matrix[row, column] == matrix[row, column + 1]
            && matrix[row, column] == matrix[row + 1, column]
            && matrix[row, column] == matrix[row + 1, column + 1])
        {
            count++;
        }
    }
}

Console.WriteLine(count);