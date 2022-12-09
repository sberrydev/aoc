namespace AdventOfCode2022.Day09;

internal class RopeBridge
{
    private readonly IEnumerable<string> _lines;

    public RopeBridge(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public int PuzzleOne() => CalculateDistinctTailPositions(2);

    public int PuzzleTwo() => CalculateDistinctTailPositions(10);

    private int CalculateDistinctTailPositions(int countOfKnots)
    {
        var head = new Head();
        var allTails = new List<Tail> { new(head) };
        allTails.AddRange(Enumerable.Range(0, countOfKnots - 2).Select(i => new Tail(allTails[i])));

        var tail = allTails.Last();

        HashSet<Tuple<int, int>> usedSpace = new() { new Tuple<int, int>(tail.X, tail.Y) };

        foreach (var line in _lines)
        {
            var instruction = line.Split(" ");
            for (var i = 0; i < int.Parse(instruction[1]); i++)
            {
                head.Move(instruction[0]);

                foreach (var knot in allTails)
                {
                    knot.Move();
                }

                usedSpace.Add(new Tuple<int, int>(tail.X, tail.Y));
            }
        }

        return usedSpace.Count;
    }
}