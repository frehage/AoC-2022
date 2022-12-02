var data_file = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "data.txt");
string[] lines = System.IO.File.ReadAllLines(data_file);
var loads = lines.Aggregate(new List<int> { 0 }, (acc, x) => {
    if (x == "") {
        acc.Add(0);
    }  
    else {
        acc[^1] += int.Parse(x);
    }
    return acc;
}).OrderBy(x => x).Reverse().ToArray();
Console.WriteLine("Part one: " + loads[0..1].Sum());
Console.WriteLine("Part one: " + loads[0..3].Sum());