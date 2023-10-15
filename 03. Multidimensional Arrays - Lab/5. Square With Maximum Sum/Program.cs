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

int maxSum = int.MinValue;
int maxRow = 0;
int maxColum = 0;

for (int row = 0; row < rows - 1; row++)
{
    for (int colum = 0; colum < colums - 1; colum++)
    {
        int currentSum = 0;

        currentSum = currentSum + matrix[row, colum];
        currentSum = currentSum + matrix[row, colum + 1];
        currentSum = currentSum + matrix[row + 1, colum];
        currentSum = currentSum + matrix[row + 1, colum + 1];

        if (currentSum > maxSum)
        {
            maxRow = row;
            maxColum = colum;
            maxSum = currentSum;
        }
    }
}

Console.WriteLine($"{matrix[maxRow, maxColum]} {matrix[maxRow, maxColum + 1]}");
Console.WriteLine($"{matrix[maxRow + 1, maxColum]} {matrix[maxRow + 1, maxColum + 1]}");

Console.WriteLine(maxSum);