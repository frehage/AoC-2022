string data = System.IO.File.ReadAllText("data.txt");
Console.WriteLine("Part one: " + Enumerable.Range(4, data.Length).First(i => data[(i - 4)..i].Distinct().Count() == 4));
Console.WriteLine("Part two: " + Enumerable.Range(14, data.Length).First(i => data[(i - 14)..i].Distinct().Count() == 14));