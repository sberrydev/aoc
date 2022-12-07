namespace AdventOfCode2022.Day07;

public class FileInfo
{
    public FileInfo(string name, long size, string type)
    {
        Name = name;
        Size = size;
        Type = type;
    }

    public string Name { get; set; }

    public long Size { get; set; }

    public string Type { get; set; }
}