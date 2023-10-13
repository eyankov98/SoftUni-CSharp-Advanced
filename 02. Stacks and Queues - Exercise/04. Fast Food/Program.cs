int quantityOfFood = int.Parse(Console.ReadLine());

int[] quantityOfOrders = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> orders = new Queue<int>(quantityOfOrders);

Console.WriteLine(orders.Max());

while (orders.Any())
{
    quantityOfFood = quantityOfFood - orders.Peek();

    if (quantityOfFood < 0)
    {
        break;
    }

    orders.Dequeue();
}

if (orders.Any())
{
    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
}
else
{
    Console.WriteLine("Orders complete");
}