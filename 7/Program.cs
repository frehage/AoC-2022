string[] data = System.IO.File.ReadAllLines("data.txt");

var root = new Dir("/");
var dirs = new List<Dir>() { root };
var current = root;

foreach (string line in data[2..])
{
    switch (line.Substring(0, 4))
    {
        case "dir ":
            dirs.Add(new Dir(line.Substring(4), current));
            current.SubDirs.Add(dirs.Last());
            break;
        case "$ cd":
            current = (line == "$ cd ..") ? current.Parent : current.SubDirs.Find(subDir => subDir.Name == line.Substring(5));
            break;
        case "$ ls":
            break;
        default:
            current.FileSize += int.Parse(line.Substring(0, line.IndexOf(" ")));
            break;
    }
}

var totalSizeChanged = false;
do
{
    totalSizeChanged = false;
    foreach (Dir dir in dirs)
    {
        var newSize = dir.FileSize + dir.SubDirs.Select(d => d.TotalSize).Sum();
        if (dir.TotalSize != newSize)
        {
            dir.TotalSize = newSize;
            totalSizeChanged = true;
        }
    }
}
while (totalSizeChanged);
var sizes = dirs.Select(dir => dir.TotalSize);

Console.WriteLine("Part one: " + sizes.Where(x => x <= 100000).Sum());
Console.WriteLine("Part two: " + sizes.OrderBy(x => x).First(x => x >= 30000000 - 70000000 + root.TotalSize));


public class Dir
{
    public Dir(string name, Dir? parent=null)
    {
        Name = name;
        Parent = parent;
    }
    public string Name { get; }
    public Dir? Parent{ get; }
    public List<Dir> SubDirs { get; set; } = new List<Dir>();
    public int FileSize { get; set; } = 0;
    public int TotalSize { get; set; } = 0;

    public override string ToString() => $"Dir(Name=\"{Name}\",SubDirs=[{string.Join(", ",SubDirs.Select(d => d.Name))}], FileSize={FileSize}, TotalSize={TotalSize})";
}
