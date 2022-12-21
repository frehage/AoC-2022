using System.Linq;
using System.Text.RegularExpressions;
var data = System.IO.File.ReadAllLines("data.txt");
bool endOfStackData = false;
var emptyLineIndex = Array.IndexOf(data, "");

var stacksOne = Enumerable.Range(0, data[0].Count()/4+1).Select(i => 
    string.Join("", data.Take(emptyLineIndex-1).Select(x => x[i*4+1]).Where(x => x != ' ').Reverse())
).ToList();
var stacksTwo = Enumerable.Range(0, data[0].Count()/4+1).Select(i => 
    string.Join("", data.Take(emptyLineIndex-1).Select(x => x[i*4+1]).Where(x => x != ' ').Reverse())
).ToList();

var moves = data.Skip(emptyLineIndex+1)
    .Select(line => new Regex(@"\D").Split(line).Where(s => s != String.Empty).Select(x=> int.Parse(x)).ToArray());

foreach (var move in moves)
{
    stacksOne[move[2]-1] += string.Join("", stacksOne[move[1]-1][^move[0]..].Reverse());
    stacksOne[move[1]-1] = stacksOne[move[1]-1][..^move[0]];
}
Console.WriteLine("Part one: " + string.Join("", stacksOne.Select(x => x[^1])));

foreach (var move in moves)
{
    Console.WriteLine("######");
    stacksTwo[move[2]-1] += stacksTwo[move[1]-1][^move[0]..];
    stacksTwo[move[1]-1] = stacksTwo[move[1]-1][..^move[0]];
    foreach (var stack in stacksTwo) Console.WriteLine(stack);
    Console.WriteLine("###");
}
Console.WriteLine("Part two: " + string.Join("", stacksTwo.Select(x => x[^1])));