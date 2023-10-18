SortedDictionary<string, SortedSet<string>> sidesUsers = new SortedDictionary<string, SortedSet<string>>();

string command = Console.ReadLine();

while (command != "Lumpawaroo")
{
    if (command.Contains("|"))
    {
        string[] inputInfo = command
            .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string side = inputInfo[0];
        string user = inputInfo[1];

        if (!sidesUsers.Values.Any(u => u.Contains(user)))
        {
            if (!sidesUsers.ContainsKey(side))
            {
                sidesUsers.Add(side, new SortedSet<string>());
            }

            sidesUsers[side].Add(user);
        }
    }
    else if (command.Contains("->"))
    {
        string[] inputInfo = command
            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        string user = inputInfo[0];
        string side = inputInfo[1];

        foreach (var sideUser in sidesUsers)
        {
            if (sideUser.Value.Contains(user))
            {
                sideUser.Value.Remove(user);

                break;
            }
        }

        if (!sidesUsers.ContainsKey(side))
        {
            sidesUsers.Add(side, new SortedSet<string>());
        }

        sidesUsers[side].Add(user);

        Console.WriteLine($"{user} joins the {side} side!");
    }

    command = Console.ReadLine();
}

foreach (var sideUser in sidesUsers.OrderByDescending(su => su.Value.Count))
{
    if (sideUser.Value.Any())
    {
        Console.WriteLine($"Side: {sideUser.Key}, Members: {sideUser.Value.Count}");

        foreach (var user in sideUser.Value)
        {
            Console.WriteLine($"! {user}");
        }
    }
}