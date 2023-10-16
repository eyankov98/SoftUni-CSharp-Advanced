int matrixSize = int.Parse(Console.ReadLine());

char[,] matrix = new char[matrixSize, matrixSize];

for (int row = 0; row < matrixSize; row++)
{
    string matrixElements = Console.ReadLine();

    for (int column = 0; column < matrixSize; column++)
    {
        matrix[row, column] = matrixElements[column];
    }
}

if (matrixSize < 3)
{
    Console.WriteLine(0);

    return;
}

int removedCountKnight = 0;

while (true)
{
    int countMostAttackingKnight = 0;
    int rowMostAttackingKnight = 0;
    int columnMostAttackingKnight = 0;

    for (int row = 0; row < matrixSize; row++)
    {
        for (int column = 0; column < matrixSize; column++)
        {
            if (matrix[row, column] == 'K')
            {
                int currentCountMostAttackingKnights = CountAttackedKnights(row, column, matrixSize, matrix);

                if (countMostAttackingKnight < currentCountMostAttackingKnights)
                {
                    countMostAttackingKnight = currentCountMostAttackingKnights;
                    rowMostAttackingKnight = row;
                    columnMostAttackingKnight = column;
                }
            }
        }
    }

    if (countMostAttackingKnight == 0)
    {
        break;
    }
    else
    {
        matrix[rowMostAttackingKnight, columnMostAttackingKnight] = '0';

        removedCountKnight++;
    }
}

Console.WriteLine(removedCountKnight);
static int CountAttackedKnights(int row, int column, int matrixSize, char[,] matrix)
{
    int currentCountMostAttackingKnights = 0;

    if (isValidCell(row - 1, column - 2, matrixSize)) // horizontal left-up
    {
        if (matrix[row - 1, column - 2] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }

    if (isValidCell(row + 1, column - 2, matrixSize)) // horizontal left-down
    {
        if (matrix[row + 1, column - 2] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }

    if (isValidCell(row - 1, column + 2, matrixSize)) // horizontal right-up
    {
        if (matrix[row - 1, column + 2] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }

    if (isValidCell(row + 1, column + 2, matrixSize)) // horizontal right-down
    {
        if (matrix[row + 1, column + 2] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }

    if (isValidCell(row - 2, column - 1, matrixSize)) // horizontal up-left
    {
        if (matrix[row - 2, column - 1] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }

    if (isValidCell(row - 2, column + 1, matrixSize)) // horizontal up-right
    {
        if (matrix[row - 2, column + 1] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }

    if (isValidCell(row + 2, column - 1, matrixSize)) // horizontal down-left
    {
        if (matrix[row + 2, column - 1] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }

    if (isValidCell(row + 2, column + 1, matrixSize)) // horizontal down-right
    {
        if (matrix[row + 2, column + 1] == 'K')
        {
            currentCountMostAttackingKnights++;
        }
    }


    return currentCountMostAttackingKnights;
}

static bool isValidCell(int row, int column, int matrixSize)
{
    return
        row >= 0
        && row < matrixSize
        && column >= 0
        && column < matrixSize;
}