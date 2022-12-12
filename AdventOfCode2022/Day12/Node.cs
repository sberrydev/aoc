namespace AdventOfCode2022.Day12;

internal class Node : Coordinate
{
    public Node(int x, int y, char value) : base(x, y)
    {
        Value = value;
    }

    protected internal char Value { get; set; }

    protected internal Node Head { get; set; }

    protected internal bool Visited { get; set; } = false;
}