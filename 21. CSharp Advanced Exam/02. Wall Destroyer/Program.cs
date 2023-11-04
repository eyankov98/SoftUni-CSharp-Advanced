using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int rows = sizeMatrix;
            int columns = sizeMatrix;

            char[,] matrixWall = new char[rows, columns];

            int currentRow = 0;
            int currentColumn = 0;

            int countOfHoles = 0;
            int countOfRods = 0;

            for (int row = 0; row < rows; row++)
            {
                string matrixWallElements = Console.ReadLine();

                for (int column = 0; column < columns; column++)
                {
                    matrixWall[row, column] = matrixWallElements[column];

                    if (matrixWall[row, column] == 'V')
                    {
                        currentRow = row;
                        currentColumn = column;
                        matrixWall[row, column] = '*';

                        countOfHoles++;
                    }
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "up" && currentRow - 1 < 0
                    || command == "down" && currentRow + 1 == rows
                    || command == "left" && currentColumn - 1 < 0
                    || command == "right" && currentColumn + 1 == columns)
                {
                    continue;
                }

                if (command == "up")
                {
                    if (matrixWall[currentRow - 1, currentColumn] == 'R')
                    {
                        countOfRods++;

                        Console.WriteLine("Vanko hit a rod!");

                        continue;
                    }
                }
                else if (command == "down")
                {
                    if (matrixWall[currentRow + 1, currentColumn] == 'R')
                    {
                        countOfRods++;

                        Console.WriteLine("Vanko hit a rod!");

                        continue;
                    }
                }
                else if (command == "left")
                {
                    if (matrixWall[currentRow, currentColumn - 1] == 'R')
                    {
                        countOfRods++;

                        Console.WriteLine("Vanko hit a rod!");

                        continue;
                    }
                }
                else if (command == "right")
                {
                    if (matrixWall[currentRow, currentColumn + 1] == 'R')
                    {
                        countOfRods++;

                        Console.WriteLine("Vanko hit a rod!");

                        continue;
                    }
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

                if (matrixWall[currentRow, currentColumn] == 'C')
                {
                    matrixWall[currentRow, currentColumn] = 'E';

                    countOfHoles++;

                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");

                    for (int row = 0; row < rows; row++)
                    {
                        for (int column = 0; column < columns; column++)
                        {
                            Console.Write(matrixWall[row, column]);
                        }

                        Console.WriteLine();
                    }

                    return;
                }
                else if (matrixWall[currentRow, currentColumn] == '-')
                {
                    matrixWall[currentRow, currentColumn] = '*';

                    countOfHoles++;
                }
                else if (matrixWall[currentRow, currentColumn] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentColumn}]!");

                    continue;
                }
            }

            matrixWall[currentRow, currentColumn] = 'V';

            Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Console.Write(matrixWall[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
