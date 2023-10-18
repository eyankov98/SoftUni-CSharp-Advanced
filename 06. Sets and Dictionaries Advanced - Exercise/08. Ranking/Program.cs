class Program
{
    static void Main()
    {
        var contestsDict = ReadContestAndPasswordData();
        var studentsDict = GetStudentsScores(contestsDict);
        PrintResults(studentsDict);
    }

    static Dictionary<string, string> ReadContestAndPasswordData()
    {
        var contestsDict = new Dictionary<string, string>();

        string input;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            string contest = input.Split(":").First();
            string password = input.Split(":").Last();
            contestsDict[contest] = password;
        }
        return contestsDict;
    }

    static SortedDictionary<string, Dictionary<string, int>> GetStudentsScores(Dictionary<string, string> contestsDict)
    {
        var studentsDict = new SortedDictionary<string, Dictionary<string, int>>();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] tokens = input.Split("=>");
            string contest = tokens[0];
            string password = tokens[1];
            string student = tokens[2];
            int points = int.Parse(tokens[3]);

            if (!contestsDict.ContainsKey(contest) || contestsDict[contest] != password)
            {
                continue;
            }

            if (!studentsDict.ContainsKey(student))
            {
                studentsDict.Add(student, new Dictionary<string, int>());
            }

            if (!studentsDict[student].ContainsKey(contest))
            {
                studentsDict[student].Add(contest, 0);
            }

            if (studentsDict[student][contest] < points)
            {
                studentsDict[student][contest] = points;
            }
        }

        return studentsDict;
    }

    static void PrintResults(SortedDictionary<string, Dictionary<string, int>> studentsDict)
    {
        string bestCandidate = studentsDict
            .OrderByDescending(x => x.Value.Values.Sum())
            .Select(x => x.Key)
            .First();

        int maxPoints = studentsDict[bestCandidate].Values.Sum();

        Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
        Console.WriteLine("Ranking:");

        foreach (var student in studentsDict)
        {
            Console.WriteLine(student.Key);

            foreach (var contest in student.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            }
        }
    }
}