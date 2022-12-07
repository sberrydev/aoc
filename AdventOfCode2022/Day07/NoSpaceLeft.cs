using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day07;

internal class NoSpaceLeft
{
    private readonly IEnumerable<string> _lines;

    public NoSpaceLeft(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public long PuzzleOne() => GetSizes(GetTree());

    public long PuzzleTwo() => GetSizesOfDirectoryToDelete(GetTree());

    private Tree<FileInfo> GetTree()
    {
        var root = new Tree<FileInfo>(new FileInfo("/", 0, "dir"));
        var currentNode = root;

        foreach (var line in _lines.Skip(1))
        {
            if (line.StartsWith("dir")) //directory
            {
                currentNode.AddChild(CreateDirectory(line));
            }
            else if (line.StartsWith("$ cd .."))
            {
                currentNode = currentNode.Parent;
            }
            else if (line.StartsWith("$ cd"))
            {
                currentNode = ChangeDirectories(line, currentNode);
            }
            else if (char.IsDigit(line[0])) //file
            {
                var child = currentNode.AddChild(CreateFile(line));
                AddSizeToParentDirectories(child);
            }
        }

        return root;
    }

    private long GetSizes(Tree<FileInfo> tree)
    {
        return (from node in tree
            where node.FileInformation.Type == "dir"
            where node.FileInformation.Size <= 100000
            select node.FileInformation.Size).Sum();
    }

    private long GetSizesOfDirectoryToDelete(Tree<FileInfo> tree)
    {
        const long totalSpace = 70000000L;
        const long required = 30000000L;

        var usedSpace = totalSpace - tree.FileInformation.Size;
        var toDelete = required - usedSpace;

        var directoryNode = tree.Where(node => node.FileInformation.Type == "dir").ToList();

        var orderedEnumerable = directoryNode.OrderBy(node => node.FileInformation.Size);
        return orderedEnumerable.First(node => node.FileInformation.Size > toDelete).FileInformation.Size;
    }

    private Tree<FileInfo> ChangeDirectories(string line, Tree<FileInfo> current)
    {
        var directoryName = Regex.Match(line, "cd (\\w+)");
        return current.Children.First(child =>
            child.FileInformation.Name == directoryName.Groups[1].Value);
    }

    private void AddSizeToParentDirectories(Tree<FileInfo> child)
    {
        var parent = child.Parent;

        do
        {
            parent.FileInformation.Size += child.FileInformation.Size;
            parent = parent.Parent;
        } while (parent != null);
    }

    private FileInfo CreateFile(string line)
    {
        var file = Regex.Match(line, "([0-9]+) (\\S+)");
        var size = long.Parse(file.Groups[1].Value);
        return new FileInfo(file.Groups[2].Value, size, "file");
    }

    private FileInfo CreateDirectory(string line)
    {
        var directoryName = Regex.Match(line, "dir (\\w+)");
        return new FileInfo(directoryName.Groups[1].Value, 0, "dir");
    }
}