Dictionary<int, int> numbersCounts = new Dictionary<int, int>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int inputNumber = int.Parse(Console.ReadLine());

    if (!numbersCounts.ContainsKey(inputNumber))
    {
        numbersCounts.Add(inputNumber, 0);
    }

    numbersCounts[inputNumber]++;
}

int number = numbersCounts.Single(nc => nc.Value % 2 == 0).Key;

Console.WriteLine(number);