int size = int.Parse(Console.ReadLine());
string[] moves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[,] field = new string[size, size];

//Creating The Field And Searching The Start And The Coals
int currentRow = 0;
int currentCol = 0;
int coals = 0;

for (int row = 0; row < size; row++)
{
    string[] currentRowArray = Console.ReadLine().Split();

    for (int col = 0; col < size; col++)
    {
        field[row, col] = currentRowArray[col];

        if (currentRowArray[col] == "s")
        {
            currentRow = row;
            currentCol = col;
        }
        else if (currentRowArray[col] == "c")
        {
            coals++;
        }
    }
}

//Miner Moving
for (int i = 0; i < moves.Length; i++)
{
    if (moves[i] == "up") //Up
    {
        if (isValid(currentRow - 1, currentCol, size))
        {
            currentRow--;
        }
    }
    else if (moves[i] == "down") //Down
    {
        if (isValid(currentRow + 1, currentCol, size))
        {
            currentRow++;
        }
    }
    else if (moves[i] == "left") //Left
    {
        if (isValid(currentRow, currentCol - 1, size))
        {
            currentCol--;
        }
    }
    else if (moves[i] == "right") //Right
    {
        if (isValid(currentRow, currentCol + 1, size))
        {
            currentCol++;
        }
    }

    if (field[currentRow, currentCol] == "c") //If Coal Is Found
    {
        coals--;
        field[currentRow, currentCol] = "*";

        if (coals == 0)
        {
            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
            return;
        }
    }
    else if (field[currentRow, currentCol] == "e") //If Current Index Is Game Stop (e)
    {
        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
        return;
    }
}

Console.WriteLine($"{coals} coals left. ({currentRow}, {currentCol})");

//Valid Index Checker
static bool isValid(int row, int col, int size)
{
    if (row >= 0 && row < size && col >= 0 && col < size)
    {
        return true;
    }
    else
    {
        return false;
    }
}