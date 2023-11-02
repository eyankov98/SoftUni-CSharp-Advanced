int matrixSize = int.Parse(Console.ReadLine());

int rows = matrixSize;
int columns = matrixSize;

char[,] matrix = new char[rows, columns];

int currentRow = 0;
int currentColumn = 0;

int countCruisers = 0;
int countMines = 0;

for (int row = 0; row < rows; row++)
{
    string matrixElements = Console.ReadLine();

    for (int column = 0; column < columns; column++)
    {
        matrix[row, column] = matrixElements[column];

        if (matrix[row, column] == 'S')
        {
            currentRow = row;
            currentColumn = column;

            matrix[row, column] = '-';

        }
    }
}
string command = Console.ReadLine();

while (true)
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

    if (matrix[currentRow, currentColumn] == '-')
    {
        command = Console.ReadLine();

        continue;
    }
    else if (matrix[currentRow, currentColumn] == '*')
    {
        countMines++;

        matrix[currentRow, currentColumn] = '-';

        if (countMines >= 3)
        {
            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currentRow}, {currentColumn}]!");

            break;
        }

        command = Console.ReadLine();

        continue;
    }
    else if (matrix[currentRow, currentColumn] == 'C')
    {
        countCruisers++;

        matrix[currentRow, currentColumn] = '-';

        if (countCruisers == 3)
        {
            Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");

            break;
        }

        command = Console.ReadLine();

        continue;
    }
}

matrix[currentRow, currentColumn] = 'S';

for (int row = 0; row < rows; row++)
{
    for (int column = 0; column < columns; column++)
    {
        Console.Write(matrix[row, column]);
    }

    Console.WriteLine();
}