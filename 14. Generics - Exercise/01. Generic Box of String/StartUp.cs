namespace BoxOfString;

public class StartUp
{
    static void Main(string[] args)
    {
        Box<string> box = new Box<string>();

        int countOfNumbers = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfNumbers; i++)
        {
            string item = Console.ReadLine();

            box.Add(item);
        }

        Console.WriteLine(box.ToString());
    }
}