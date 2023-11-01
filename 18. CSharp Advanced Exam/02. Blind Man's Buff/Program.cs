int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSize[0];
int columns = matrixSize[1];

string[,] matrixPlayGround = new string[rows, columns];

int touchedOpponents = 0;
int moves = 0;

int currentRow = 0;
int currentColumn = 0;

for (int row = 0; row < rows; row++)
{
    string[] matrixElements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int column = 0; column < columns; column++)
    {
        matrixPlayGround[row, column] = matrixElements[column];

        if (matrixPlayGround[row, column] == "B")
        {
            currentRow = row;
            currentColumn = column;
            matrixPlayGround[row, column] = "-";
        }
    }
}

string command = Console.ReadLine();

while (command != "Finish")
{
    if (command == "up" && currentRow - 1 < 0
        || command == "down" && currentRow + 1 >= rows
        || command == "left" && currentColumn - 1 < 0
        || command == "right" && currentColumn + 1 >= columns)
    {
        command = Console.ReadLine();

        continue;
    }

    if (command == "up")
    {
        if (matrixPlayGround[currentRow - 1, currentColumn] == "O")
        {
            command = Console.ReadLine();

            continue;
        }
    }
    else if (command == "down")
    {
        if (matrixPlayGround[currentRow + 1, currentColumn] == "O")
        {
            command = Console.ReadLine();

            continue;
        }
    }
    else if (command == "left")
    {
        if (matrixPlayGround[currentRow, currentColumn - 1] == "O")
        {
            command = Console.ReadLine();

            continue;
        }
    }
    else if (command == "right")
    {
        if (matrixPlayGround[currentRow, currentColumn + 1] == "O")
        {
            command = Console.ReadLine();

            continue;
        }
    }

    moves++;

    if (command == "up")
    {
        currentRow--;
    }
    else if (command == "down")
    {
        currentRow++;
    }
    else if (command == "left")
    {
        currentColumn--;
    }
    else if (command == "right")
    {
        currentColumn++;
    }

    if (matrixPlayGround[currentRow, currentColumn] == "P")
    {
        touchedOpponents++;

        matrixPlayGround[currentRow, currentColumn] = "-";

        if (touchedOpponents == 3)
        {
            break;
        }
    }

    command = Console.ReadLine();
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");