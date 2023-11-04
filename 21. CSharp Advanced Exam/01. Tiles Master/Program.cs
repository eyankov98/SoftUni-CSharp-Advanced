using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTilesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] greyTilesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> whiteTiles = new Stack<int>(whiteTilesInput);
            Queue<int> greyTiles = new Queue<int>(greyTilesInput);

            Dictionary<string, int> locationsTiles = new Dictionary<string, int>();

            while (whiteTiles.Any() && greyTiles.Any())
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int newTile = whiteTiles.Peek() + greyTiles.Peek();

                    if (newTile == 40)
                    {
                        if (!locationsTiles.ContainsKey("Sink"))
                        {
                            locationsTiles.Add("Sink", 0);
                        }

                        locationsTiles["Sink"]++;

                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else if (newTile == 50)
                    {
                        if (!locationsTiles.ContainsKey("Oven"))
                        {
                            locationsTiles.Add("Oven", 0);
                        }

                        locationsTiles["Oven"]++;

                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else if (newTile == 60)
                    {
                        if (!locationsTiles.ContainsKey("Countertop"))
                        {
                            locationsTiles.Add("Countertop", 0);
                        }

                        locationsTiles["Countertop"]++;

                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else if (newTile == 70)
                    {
                        if (!locationsTiles.ContainsKey("Wall"))
                        {
                            locationsTiles.Add("Wall", 0);
                        }

                        locationsTiles["Wall"]++;

                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else if (newTile > 40 || newTile < 70)
                    {
                        if (!locationsTiles.ContainsKey("Floor"))
                        {
                            locationsTiles.Add("Floor", 0);
                        }

                        locationsTiles["Floor"]++;

                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }

                }
                else if (whiteTiles.Peek() != greyTiles.Peek())
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);

                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }

            if (!whiteTiles.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (!greyTiles.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var location in locationsTiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
