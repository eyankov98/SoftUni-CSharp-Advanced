int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

char[,] bunnyLiar = new char[rows, cols];

//Creating The Bunny Lair
int playerRow = 0;
int playerCol = 0;

for (int row = 0; row < rows; row++)
{
    string chars = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        bunnyLiar[row, col] = chars[col];

        if (bunnyLiar[row, col] == 'P')
        {
            playerRow = row;
            playerCol = col;
            bunnyLiar[row, col] = '.';
        }
    }
}

//Moving Player
bool won = true;
char[] directions = Console.ReadLine().ToCharArray();

for (int i = 0; i < directions.Length; i++)
{
    char currentMove = directions[i];

    int prevPlayerRow = playerRow;
    int prevPlayerCol = playerCol;

    if (currentMove == 'U')
    {
        bunnyLiar = BunnySpread(bunnyLiar, rows, cols);
        playerRow--;
    }
    else if (currentMove == 'D')
    {
        bunnyLiar = BunnySpread(bunnyLiar, rows, cols);
        playerRow++;
    }
    else if (currentMove == 'L')
    {
        bunnyLiar = BunnySpread(bunnyLiar, rows, cols);
        playerCol--;
    }
    else if (currentMove == 'R')
    {
        bunnyLiar = BunnySpread(bunnyLiar, rows, cols);
        playerCol++;
    }

    if (isValid(playerRow, playerCol, rows, cols)) //Result Check
    {
        if (bunnyLiar[playerRow, playerCol] == 'B') //If Stepped On a Bunny
        {
            MatrixPrint(bunnyLiar, rows, cols);
            Console.WriteLine($"dead: {playerRow} {playerCol}");
            break;
        }
    }
    else
    {
        MatrixPrint(bunnyLiar, rows, cols);
        Console.WriteLine($"won: {prevPlayerRow} {prevPlayerCol}");
        break;
    }
}

//Bunny Spread
static char[,] BunnySpread(char[,] matrix, int rows, int cols)
{
    char[,] newMatrix = new char[rows, cols];

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            newMatrix[row, col] = matrix[row, col];
        }
    }

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            if (matrix[row, col] == 'B')
            {
                if (isValid(row - 1, col, rows, cols)) //Up Move
                {
                    newMatrix[row - 1, col] = 'B';
                }

                if (isValid(row + 1, col, rows, cols)) //Down Move
                {
                    newMatrix[row + 1, col] = 'B';
                }

                if (isValid(row, col - 1, rows, cols)) //Left Move
                {
                    newMatrix[row, col - 1] = 'B';
                }
                
                if (isValid(row, col + 1, rows, cols)) //Right Move
                {
                    newMatrix[row, col + 1] = 'B';
                }
            }
        }
    }
    return newMatrix;
}

//Valid Coordinates Checker
static bool isValid(int row, int col, int rows, int cols)
{
    if (row >= 0 && row < rows && col >= 0 && col < cols)
    {
        return true;
    }
    else
    {
        return false;
    }
}

//Matrix Output
static void MatrixPrint(char[,] matrix, int rows, int cols)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}