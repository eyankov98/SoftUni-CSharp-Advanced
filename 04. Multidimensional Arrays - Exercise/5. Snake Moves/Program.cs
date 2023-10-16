int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string word = Console.ReadLine();

int rows = matrixSize[0];
int columns = matrixSize[1];

char[,] matrix = new char[rows, columns];

int currentWordIndex = 0;

for (int row = 0; row < rows; row++)
{
    if (row % 2 == 0)
    {
        for (int column = 0; column < columns; column++)
        {
            if (currentWordIndex == word.Length)
            {
                currentWordIndex = 0;
            }

            matrix[row, column] = word[currentWordIndex];

            currentWordIndex++;
        }
    }
    else
    {
        for (int column = columns - 1; column >= 0; column--)
        {
            if (currentWordIndex == word.Length)
            {
                currentWordIndex = 0;
            }

            matrix[row, column] = word[currentWordIndex];

            currentWordIndex++;
        }
    }
}

for (int row = 0; row < rows; row++)
{
    for (int column = 0; column < columns; column++)
    {
        Console.Write($"{matrix[row, column]}");
    }

    Console.WriteLine();
}