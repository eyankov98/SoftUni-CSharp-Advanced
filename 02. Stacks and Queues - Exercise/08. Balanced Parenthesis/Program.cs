string input = Console.ReadLine();

Stack<char> parentheses = new Stack<char>();

foreach (var charr in input)
{
    if (charr == '{')
    {
        parentheses.Push(charr);
    }
    else if (charr == '[')
    {
        parentheses.Push(charr);
    }
    else if (charr == '(')
    {
        parentheses.Push(charr);
    }

    else if (charr == '}')
    {
        if (!parentheses.Any() || parentheses.Pop() != '{')
        {
            Console.WriteLine("NO");

            return;
        }

        continue;
    }
    else if (charr == ']')
    {
        if (!parentheses.Any() || parentheses.Pop() != '[')
        {
            Console.WriteLine("NO");

            return;
        }

        continue;
    }
    else if (charr == ')')
    {
        if (!parentheses.Any() || parentheses.Pop() != '(')
        {
            Console.WriteLine("NO");

            return;
        }

        continue;
    }
}
if (parentheses.Any())
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}