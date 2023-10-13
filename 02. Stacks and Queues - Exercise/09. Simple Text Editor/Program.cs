string text = string.Empty;

int countOfOperations = int.Parse(Console.ReadLine());

Stack<string> stack = new Stack<string>();

for (int i = 0; i < countOfOperations; i++)
{
    string[] command = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int currentCommand = int.Parse(command[0]);

    if (currentCommand == 1)
    {
        stack.Push(text);

        string tokens = command[1];

        text = text + tokens;
    }
    else if (currentCommand == 2)
    {
        stack.Push(text);

        int count = int.Parse(command[1]);

        text = text.Remove(text.Length - count);
    }
    else if (currentCommand == 3)
    {
        int index = int.Parse(command[1]);

        index = index - 1;

        Console.WriteLine(text[index]);
    }
    else if (currentCommand == 4)
    {
        text = stack.Pop();
    }
}