int matrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[matrixSize, matrixSize];

for (int row = 0; row < matrixSize; row++)
{
    int[] matrixElements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int colum = 0; colum < matrixSize; colum++)
    {
        matrix[row, colum] = matrixElements[colum];
    }
}

int sumOfMatrixElementsOnDiagonal = 0;

for (int i = 0; i < matrixSize; i++)
{
    sumOfMatrixElementsOnDiagonal = sumOfMatrixElementsOnDiagonal + matrix[i, i];
}

Console.WriteLine(sumOfMatrixElementsOnDiagonal);