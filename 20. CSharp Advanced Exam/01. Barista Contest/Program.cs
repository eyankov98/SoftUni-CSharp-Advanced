using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] quantitiesOfCoffee = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

            int[] quantitiesOfMilk = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Queue<int> coffees = new Queue<int>(quantitiesOfCoffee);
            Stack<int> milks = new Stack<int>(quantitiesOfMilk);

            Dictionary<string, int> coffeeDrinks = new Dictionary<string, int>();

            while (coffees.Any() && milks.Any())
            {
                int sum = coffees.Peek() + milks.Peek();

                if (sum == 50)
                {
                    if (!coffeeDrinks.ContainsKey("Cortado"))
                    {
                        coffeeDrinks.Add("Cortado", 0);
                    }

                    coffeeDrinks["Cortado"]++;

                    coffees.Dequeue();
                    milks.Pop();
                }
                else if (sum == 75)
                {
                    if (!coffeeDrinks.ContainsKey("Espresso"))
                    {
                        coffeeDrinks.Add("Espresso", 0);
                    }

                    coffeeDrinks["Espresso"]++;

                    coffees.Dequeue();
                    milks.Pop();
                }
                else if (sum == 100)
                {
                    if (!coffeeDrinks.ContainsKey("Capuccino"))
                    {
                        coffeeDrinks.Add("Capuccino", 0);
                    }

                    coffeeDrinks["Capuccino"]++;

                    coffees.Dequeue();
                    milks.Pop();
                }
                else if (sum == 150)
                {
                    if (!coffeeDrinks.ContainsKey("Americano"))
                    {
                        coffeeDrinks.Add("Americano", 0);
                    }

                    coffeeDrinks["Americano"]++;

                    coffees.Dequeue();
                    milks.Pop();
                }
                else if (sum == 200)
                {
                    if (!coffeeDrinks.ContainsKey("Latte"))
                    {
                        coffeeDrinks.Add("Latte", 0);
                    }

                    coffeeDrinks["Latte"]++;

                    coffees.Dequeue();
                    milks.Pop();
                }
                else if (sum != 50 || sum != 75 || sum != 100 || sum != 150 || sum != 200)
                {
                    coffees.Dequeue();

                    int newQuantityMilk = milks.Peek() - 5;

                    milks.Pop();

                    milks.Push(newQuantityMilk);
                }
            }

            if (!coffees.Any() && !milks.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffees.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffees)}");
            }
            else if (!coffees.Any())
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milks.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milks)}");
            }
            else if (!milks.Any())
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var coffeeDrink in coffeeDrinks.OrderBy(c => c.Value).ThenByDescending(c => c.Key))
            {
                Console.WriteLine($"{coffeeDrink.Key}: {coffeeDrink.Value}");
            }
        }
    }
}
