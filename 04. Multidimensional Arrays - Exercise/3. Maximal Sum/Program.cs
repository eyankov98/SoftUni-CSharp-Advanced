int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSize[0];
int columns = matrixSize[1];

int[,] matrix = new int[rows, columns];

for (int row = 0; row < rows; row++)
{
    int[] matrixElements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int column = 0; column < columns; column++)
    {
        matrix[row, column] = matrixElements[column];
    }
}

int maximalSumOfMatrixElements = int.MinValue;
int maxRow = 0;
int maxColumn = 0;

for (int row = 0; row < rows - 2; row++)
{
    for (int column = 0; column < columns - 2; column++)
    {
        int currentSum = 0;

        currentSum += matrix[row, column];
        currentSum += matrix[row, column + 1];
        currentSum += matrix[row, column + 2];
        currentSum += matrix[row + 1, column];
        currentSum += matrix[row + 1, column + 1];
        currentSum += matrix[row + 1, column + 2];
        currentSum += matrix[row + 2, column];
        currentSum += matrix[row + 2, column + 1];
        currentSum += matrix[row + 2, column + 2];

        if (currentSum > maximalSumOfMatrixElements)
        {
            maximalSumOfMatrixElements = currentSum;
            maxRow = row;
            maxColumn = column;
        }
    }
}

Console.WriteLine($"Sum = {maximalSumOfMatrixElements}");

/*Console.WriteLine($"{matrix[maxRow, maxColumn]} {matrix[maxRow, maxColumn + 1]} {matrix[maxRow, maxColumn + 2]}");
Console.WriteLine($"{matrix[maxRow + 1, maxColumn]} {matrix[maxRow + 1, maxColumn + 1]} {matrix[maxRow + 1, maxColumn + 2]}");
Console.WriteLine($"{matrix[maxRow + 2, maxColumn]} {matrix[maxRow + 2, maxColumn + 1]} {matrix[maxRow + 2, maxColumn + 2]}");*/

for (int row = maxRow; row < maxRow + 3; row++)
{
    for (int column = maxColumn; column < maxColumn + 3; column++)
    {
        Console.Write($"{matrix[row, column]} ");
    }

    Console.WriteLine();
}