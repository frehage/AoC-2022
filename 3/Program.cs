var offset = new int[] {96, 38};
string[] data = System.IO.File.ReadAllLines("data.txt");
var partOne = data.Aggregate(0, (sum, line) => {
    var x = line.Take(line.Count()/2);
    var y = line.Skip(line.Count()/2);
    var z = x.Intersect(y);
    var w = z.Select(c => c - offset[Convert.ToInt32(c<'a')]);
    return sum + w.Sum();
});
var partTwo = 0;
var i = 0;
while (i < data.Count())
{
    var x = data[i].Intersect(data[i+1]).Intersect(data[i+2]);
    var y = x.Select(c => c - offset[Convert.ToInt32(c<'a')]);
    partTwo += y.Sum();
    i += 3;
}
Console.WriteLine("Part one: " + partOne);
Console.WriteLine("Part two: " + partTwo);