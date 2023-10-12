string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Stack<string> expression = new Stack<string>(input.Reverse());

int result = int.Parse(expression.Pop());

while (expression.Count > 0)
{
    string sign = expression.Pop();
    int number = int.Parse(expression.Pop());

    if (sign == "+")
    {
        result = result + number;
    }
    else if (sign == "-")
    {
        result = result - number;
    }
}

Console.WriteLine(result);