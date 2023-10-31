int matrixSize = int.Parse(Console.ReadLine());

int rows = matrixSize;
int columns = matrixSize;

char[,] matrix = new char[rows, columns];

int currentRow = 0;
int currentColumn = 0;

int countHazelnuts = 0;

string[] command = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

Queue<string> directions = new Queue<string>(command);

for (int row = 0; row < rows; row++)
{
    string matrixElement = Console.ReadLine();

    for (int column = 0; column < columns; column++)
    {
        matrix[row, column] = matrixElement[column];

        if (matrix[row, column] == 's')
        {
            currentRow = row;
            currentColumn = column;

            matrix[row, column] = '*';
        }
    }
}

while (directions.Any())
{
    string direction = directions.Dequeue();

    if (direction == "up" && currentRow - 1 < 0
        || direction == "down" && currentRow + 1 >= rows
        || direction == "left" && currentColumn - 1 < 0
        || direction == "right" && currentColumn + 1 >= columns)
    {
        Console.WriteLine("The squirrel is out of the field.");

        Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");

        matrix[currentRow, currentColumn] = '*';

        return;
    }

    if (direction == "up")
    {
        currentRow--;
    }
    else if (direction == "down")
    {
        currentRow++;
    }
    else if (direction == "left")
    {
        currentColumn--;
    }
    else if (direction == "right")
    {
        currentColumn++;
    }

    if (matrix[currentRow, currentColumn] == 'h')
    {
        countHazelnuts++;

        matrix[currentRow, currentColumn] = '*';
    }
    else if (matrix[currentRow, currentColumn] == 't')
    {
        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");

        Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");

        matrix[currentRow, currentColumn] = '*';

        return;
    }
    else if (matrix[currentRow, currentColumn] == '*')
    {
        continue;
    }

    if (countHazelnuts == 3)
    {
        Console.WriteLine("Good job! You have collected all hazelnuts!");

        Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");

        matrix[currentRow, currentColumn] = 's';

        return;
    }
}
if (countHazelnuts != 3)
{
    Console.WriteLine("There are more hazelnuts to collect.");

    Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");
}