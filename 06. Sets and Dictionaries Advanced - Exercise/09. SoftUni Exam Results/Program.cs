Dictionary<string, int> participantsResults = new Dictionary<string, int>();
Dictionary<string, int> languagesSubmissions = new Dictionary<string, int>();

string input = string.Empty;

while ((input = Console.ReadLine()) != "exam finished")
{
    string[] tokens = input.Split("-");

    if (tokens[1] == "banned")
    {
        participantsResults.Remove(tokens[0]);

        continue;
    }

    string student = tokens[0];
    string language = tokens[1];
    int points = int.Parse(tokens[2]);

    if (!participantsResults.ContainsKey(student))
    {
        participantsResults.Add(student, 0);
    }

    if (participantsResults[student] < points)
    {
        participantsResults[student] = points;
    }

    if (!languagesSubmissions.ContainsKey(language))
    {
        languagesSubmissions.Add(language, 0);
    }

    languagesSubmissions[language]++;
}

Console.WriteLine("Results:");
foreach (var student in participantsResults.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{student.Key} | {student.Value}");
}
Console.WriteLine("Submissions:");
foreach (var language in languagesSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{language.Key} - {language.Value}");
}