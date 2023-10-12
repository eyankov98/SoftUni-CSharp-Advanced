int[] inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> stackOfNumbers = new Stack<int>(inputNumbers);

string command = Console.ReadLine().ToLower();

while (command != "end")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string currentCommand = commandInfo[0];

    if (currentCommand == "add")
    {
        int firstNumber = int.Parse(commandInfo[1]);
        int secondNumber = int.Parse(commandInfo[2]);
        stackOfNumbers.Push(firstNumber);
        stackOfNumbers.Push(secondNumber);
    }
    else if (currentCommand == "remove")
    {
        int countOfNumbersToRemove = int.Parse(commandInfo[1]);

        while (countOfNumbersToRemove <= stackOfNumbers.Count && countOfNumbersToRemove > 0)
        {
            stackOfNumbers.Pop();

            countOfNumbersToRemove--;
        }
    }

    command = Console.ReadLine().ToLower();
}

Console.WriteLine("Sum: " + stackOfNumbers.Sum());