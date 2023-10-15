int matrixSize = int.Parse(Console.ReadLine());

char[,] matrix = new char[matrixSize, matrixSize];

for (int row = 0; row < matrixSize; row++)
{
    char[] matrixElements = Console.ReadLine()
        .ToCharArray();

    for (int colum = 0; colum < matrixSize; colum++)
    {
        matrix[row, colum] = matrixElements[colum];
    }
}

char symbol = char.Parse(Console.ReadLine());

for (int row = 0; row < matrixSize; row++)
{
    for (int colum = 0; colum < matrixSize; colum++)
    {
        if (matrix[row, colum] == symbol)
        {
            Console.WriteLine($"({row}, {colum})");

            return;
        }
    }
}

Console.WriteLine($"{symbol} does not occur in the matrix");