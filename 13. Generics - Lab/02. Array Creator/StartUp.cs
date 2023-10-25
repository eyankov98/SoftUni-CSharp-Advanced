namespace GenericArrayCreator;

public class StartUp
{
    static void Main(string[] args)
    {
        float[] numbers = ArrayCreator.Create(50, 3f);
        string[] strings = ArrayCreator.Create(3, "Edgar");
        int[] integers = ArrayCreator.Create(10, 33);

        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine(string.Join(", ", strings));
        Console.WriteLine(string.Join(", ", integers));
    }
}