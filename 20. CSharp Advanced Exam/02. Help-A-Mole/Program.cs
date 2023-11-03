using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int rows = matrixSize;
            int columns = matrixSize;

            char[,] matrix = new char[rows, columns];

            int currentRow = 0;
            int currentColumn = 0;

            int points = 0;

            for (int row = 0; row < rows; row++)
            {
                string matrixElements = Console.ReadLine();

                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = matrixElements[column];

                    if (matrix[row, column] == 'M')
                    {
                        currentRow = row;
                        currentColumn = column;

                        matrix[row, column] = '-';
                    }
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "up" && currentRow - 1 < 0
                    || command == "down" && currentRow + 1 >= rows
                    || command == "left" && currentColumn - 1 < 0
                    || command == "right" && currentColumn + 1 >= columns)
                {
                    Console.WriteLine("Don't try to escape the playing field!");

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
                    continue;
                }
                else if (char.IsDigit(matrix[currentRow, currentColumn]))
                {
                    points = points + int.Parse(matrix[currentRow, currentColumn].ToString());

                    matrix[currentRow, currentColumn] = '-';
                }
                else if (matrix[currentRow, currentColumn] == 'S')
                {
                    matrix[currentRow, currentColumn] = '-';

                    for (int row = 0; row < rows; row++)
                    {
                        for (int column = 0; column < columns; column++)
                        {
                            if (matrix[row, column] == 'S')
                            {
                                currentRow = row;
                                currentColumn = column;

                                matrix[row, column] = '-';
                            }
                        }
                    }

                    points = points - 3;
                }

                if (points >= 25)
                {
                    break;
                }
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            matrix[currentRow, currentColumn] = 'M';

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Console.Write(matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
