﻿int rangeEnd = int.Parse(Console.ReadLine());

int[] dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Func<int, int, bool> isDivisibleFunc = (num1, num2) =>
{
    if (num1 % num2 == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
};

List<int> validNums = new List<int>();

for (int i = 1; i <= rangeEnd; i++)
{
    bool isDivisible = true;

    for (int j = 0; j < dividers.Length; j++)
    {
        if (!isDivisibleFunc(i, dividers[j]))
        {
            isDivisible = false;
            break;
        }
    }

    if (isDivisible)
    {
        validNums.Add(i);
    }
}

Console.WriteLine(String.Join(" ", validNums));