string[] matrixSize = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

int rows = int.Parse(matrixSize[0]);
int colums = int.Parse(matrixSize[1]);

int[,] matrix = new int[rows, colums];

for (int row = 0; row < rows; row++)
{
    int[] matrixElements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int colum = 0; colum < colums; colum++)
    {
        matrix[row, colum] = matrixElements[colum];
    }
}

for (int colum = 0; colum < colums; colum++)
{
    int sumMatrixElementsInColums = 0;

    for (int row = 0; row < rows; row++)
    {
        sumMatrixElementsInColums = sumMatrixElementsInColums + matrix[row, colum];
    }

    Console.WriteLine(sumMatrixElementsInColums);
}