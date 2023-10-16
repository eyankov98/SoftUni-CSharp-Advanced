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

string[] coordinatesOfBombCells = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var coordinateOfBombCell in coordinatesOfBombCells)
{
    int[] indexes = coordinateOfBombCell
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int row = indexes[0];
    int column = indexes[1];

    Explode(row, column, matrix);
}

int aliveCells = 0;
int sumOfCells = 0;

for (int row = 0; row < matrixSize; row++)
{
    for (int column = 0; column < matrixSize; column++)
    {
        if (matrix[row, column] > 0)
        {
            aliveCells++;

            sumOfCells = sumOfCells + matrix[row, column];
        }
    }
}

Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {sumOfCells}");

for (int row = 0; row < matrixSize; row++)
{
    for (int column = 0; column < matrixSize; column++)
    {
        Console.Write($"{matrix[row, column]} ");
    }

    Console.WriteLine();
}

static void Explode(int row, int column, int[,] matrix)
{
    int value = matrix[row, column];

    if (value > 0)
    {
        matrix[row, column] = 0;

        if (row > 0 && matrix[row - 1, column] > 0) // up
        {
            matrix[row - 1, column] = matrix[row - 1, column] - value;
        }

        if (row < matrix.GetLength(0) - 1 && matrix[row + 1, column] > 0) // down
        {
            matrix[row + 1, column] = matrix[row + 1, column] - value;
        }

        if (column > 0 && matrix[row, column - 1] > 0) // left
        {
            matrix[row, column - 1] = matrix[row, column - 1] - value;
        }

        if (column < matrix.GetLength(1) - 1 && matrix[row, column + 1] > 0) // right
        {
            matrix[row, column + 1] = matrix[row, column + 1] - value;
        }

        if (row > 0 && column > 0 && matrix[row - 1, column - 1] > 0) // up left
        {
            matrix[row - 1, column - 1] = matrix[row - 1, column - 1] - value;
        }

        if (row < matrix.GetLength(0) - 1 && column > 0 && matrix[row + 1, column - 1] > 0) // down left
        {
            matrix[row + 1, column - 1] = matrix[row + 1, column - 1] - value;
        }

        if (row > 0 && column < matrix.GetLength(1) - 1 && matrix[row - 1, column + 1] > 0) // up right
        {
            matrix[row - 1, column + 1] = matrix[row - 1, column + 1] - value;
        }

        if (row < matrix.GetLength(0) - 1 && column < matrix.GetLength(1) - 1 && matrix[row + 1, column + 1] > 0) // down right
        {
            matrix[row + 1, column + 1] = matrix[row + 1, column + 1] - value;
        }
    }
}