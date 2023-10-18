Dictionary<string, SortedSet<string>> following = new Dictionary<string, SortedSet<string>>();
Dictionary<string, SortedSet<string>> followedBy = new Dictionary<string, SortedSet<string>>();

string input = string.Empty;

while ((input = Console.ReadLine()) != "Statistics")
{
    string[] tokens = input.Split();
    string firstName = tokens[0];
    string action = tokens[1];
    string secondName = tokens[2];

    if (action == "joined" &&
        !following.ContainsKey(firstName))
    {
        following.Add(firstName, new SortedSet<string>());
        followedBy.Add(firstName, new SortedSet<string>());
    }
    else if (action == "followed" &&
             following.ContainsKey(firstName) &&
             followedBy.ContainsKey(secondName) &&
             firstName != secondName)
    {
        following[firstName].Add(secondName);
        followedBy[secondName].Add(firstName);
    }
}

Console.WriteLine($"The V-Logger has a total of {following.Count} vloggers in its logs.");

int ranking = 1;

foreach (var vlogger in followedBy
    .OrderByDescending(x => x.Value.Count)
    .ThenBy(x => following[x.Key].Count))
{
    Console.WriteLine($"{ranking}. {vlogger.Key} : {vlogger.Value.Count} followers, {following[vlogger.Key].Count} following");

    if (ranking == 1)
    {
        Console.WriteLine(String.Join("\n", vlogger.Value.Select(x => $"*  {x}")));
    }

    ranking++;
}