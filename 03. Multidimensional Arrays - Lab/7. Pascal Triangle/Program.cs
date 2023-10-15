int rows = int.Parse(Console.ReadLine());

long[][] pascalTriangle = new long[rows][];

pascalTriangle[0] = new long[1] { 1 };

for (int row = 1; row < pascalTriangle.Length; row++)
{
    pascalTriangle[row] = new long[row + 1];

    for (int colum = 0; colum < pascalTriangle[row].Length; colum++)
    {
        if (pascalTriangle[row - 1].Length > colum)
        {
            pascalTriangle[row][colum] = pascalTriangle[row][colum] + pascalTriangle[row - 1][colum];
        }

        if (colum > 0)
        {
            pascalTriangle[row][colum] = pascalTriangle[row][colum] + pascalTriangle[row - 1][colum - 1];
        }
    }
}

for (int row = 0; row < pascalTriangle.Length; row++)
{
    for (int colum = 0; colum < pascalTriangle[row].Length; colum++)
    {
        Console.Write($"{pascalTriangle[row][colum]} ");
    }

    Console.WriteLine();
}