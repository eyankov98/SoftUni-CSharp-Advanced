namespace BoxOfInteger;

public class StartUp
{
    static void Main(string[] args)
    {
        Box<int> box = new Box<int>();

        int countOfNumbers = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfNumbers; i++)
        {
            int item = int.Parse(Console.ReadLine());

            box.Add(item);
        }

        Console.WriteLine(box.ToString());
    }
}