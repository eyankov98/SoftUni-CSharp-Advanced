int matrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[matrixSize, matrixSize];

for (int row = 0; row < matrixSize; row++)
{
    int[] matrixElements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int column = 0; column < matrixSize; column++)
    {
        matrix[row, column] = matrixElements[column];
    }
}

int primaryDiagonalSum = 0;
int secondaryDiagonalSum = 0;

for (int i = 0; i < matrixSize; i++)
{
    primaryDiagonalSum = primaryDiagonalSum + matrix[i, i];
    secondaryDiagonalSum = secondaryDiagonalSum + matrix[i, matrixSize - 1 - i];
}

Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));