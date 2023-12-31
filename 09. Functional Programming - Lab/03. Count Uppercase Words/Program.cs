﻿Func<string, bool> isUpperFunc = w => Char.IsUpper(w[0]);

string[] words = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(isUpperFunc)
    .ToArray();

Console.WriteLine(String.Join("\n", words));