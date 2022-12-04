
using System.Text.RegularExpressions;
Regex regex = new Regex("[-|,]");         // Split on hyphens.
var data = System.IO.File.ReadAllLines("data.txt")
    .Select(line => regex.Split(line).Select(x=> int.Parse(x)).ToArray());
foreach (var x in data)
{
    foreach (var match in x)
    {
        Console.Write("{0} ", match);
    }   
    Console.WriteLine("" + (x[0] <= x[3] && x[1] >= x[2]));

}
Console.WriteLine("Part one: " + data.Where(x => (x[0] <= x[2] && x[1] >= x[3]) || (x[0] >= x[2] && x[1] <= x[3])).Count());
Console.WriteLine("Part two: " + data.Where(x => (x[0] <= x[3] && x[1] >= x[2])).Count());