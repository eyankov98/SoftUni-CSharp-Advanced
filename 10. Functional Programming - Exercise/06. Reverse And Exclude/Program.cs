﻿List<int> inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .Reverse()
    .ToList();

int divider = int.Parse(Console.ReadLine());

Predicate<int> isDivisible = number => number % divider == 0;

for (int i = 0; i < inputNumbers.Count; i++)
{
    if (isDivisible(inputNumbers[i]))
    {
        inputNumbers.RemoveAt(i);
        i--;
    }
}

Console.WriteLine(String.Join(" ", inputNumbers));