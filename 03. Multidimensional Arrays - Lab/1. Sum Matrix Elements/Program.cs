string[] matrixSize = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

int rows = int.Parse(matrixSize[0]);
int colums = int.Parse(matrixSize[1]);

int[,] matrix = new int[rows, colums];

for (int row = 0; row < rows; row++)
{
    int[] matrixElements = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int colum = 0; colum < colums; colum++)
    {
        matrix[row, colum] = matrixElements[colum];
    }
}

int sumMatrixElements = 0;

for (int row = 0; row < rows; row++)
{
    for (int colum = 0; colum < colums; colum++)
    {
        sumMatrixElements = sumMatrixElements + matrix[row, colum];
    }
}

Console.WriteLine(rows);
Console.WriteLine(colums);
Console.WriteLine(sumMatrixElements);