var ScorePartOne = new Dictionary<Char, Dictionary<Char, int>>() {
    {'A', new Dictionary<Char,int>() { { 'X', 3 + 1 }, { 'Y', 6 + 2 }, { 'Z', 0 + 3 } } },
    {'B', new Dictionary<Char,int>() { { 'X', 0 + 1 }, { 'Y', 3 + 2 }, { 'Z', 6 + 3 } } },
    {'C', new Dictionary<Char,int>() { { 'X', 6 + 1 }, { 'Y', 0 + 2 }, { 'Z', 3 + 3 } } },
};
var ScorePartTwo = new Dictionary<Char, Dictionary<Char, int>>() {
    {'A', new Dictionary<Char,int>() { { 'X', 0 + 3 }, { 'Y', 3 + 1 }, { 'Z', 6 + 2 } } },
    {'B', new Dictionary<Char,int>() { { 'X', 0 + 1 }, { 'Y', 3 + 2 }, { 'Z', 6 + 3 } } },
    {'C', new Dictionary<Char,int>() { { 'X', 0 + 2 }, { 'Y', 3 + 3 }, { 'Z', 6 + 1 } } },
};
string[] data = System.IO.File.ReadAllLines("data.txt");
Console.WriteLine("Part one: " + data.Aggregate(0, (acc, x) => acc + ScorePartOne[x[0]][x[2]]));
Console.WriteLine("Part two: " + data.Aggregate(0, (acc, x) => acc + ScorePartTwo[x[0]][x[2]]));