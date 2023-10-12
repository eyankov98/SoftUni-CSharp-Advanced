string input = Console.ReadLine();

Stack<char> text = new Stack<char>(input);

while (text.Any())
{
    Console.Write(text.Pop());
}