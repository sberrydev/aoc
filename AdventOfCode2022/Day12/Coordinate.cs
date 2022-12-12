namespace AdventOfCode2022.Day12;

internal class Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    protected internal int X { get; set; }

    protected internal int Y { get; set; }
}