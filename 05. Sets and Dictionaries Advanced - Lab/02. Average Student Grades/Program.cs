Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

int countOfGrade = int.Parse(Console.ReadLine());

for (int i = 0; i < countOfGrade; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = input[0];
    decimal grade = decimal.Parse(input[1]);

    if (!studentGrades.ContainsKey(name))
    {
        studentGrades.Add(name, new List<decimal>());
    }

    studentGrades[name].Add(grade);
}

foreach (var student in studentGrades)
{
    Console.Write($"{student.Key:f2} -> ");

    foreach (var grade in student.Value)
    {
        Console.Write($"{grade:f2} ");
    }

    Console.WriteLine($"(avg: {student.Value.Average():f2})");
}