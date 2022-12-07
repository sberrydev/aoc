using static System.Int32;

namespace AdventOfCode2022.Day04;

internal class CampCleanup
{
    private readonly IEnumerable<string> _lines;

    public CampCleanup(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public int PuzzleOne() => _lines.Where(IsFullyContained).Count();

    public int PuzzleTwo() => _lines.Where(IsPartiallyContained).Count();

    private bool IsFullyContained(string input)
    {
        var (range1, range2) = GetRanges(input);
        return !range1.Except(range2).Any() || !range2.Except(range1).Any();
    }

    private bool IsPartiallyContained(string input)
    {
        var (range1, range2) = GetRanges(input);
        return range1.Intersect(range2).Any() || range2.Intersect(range1).Any();
    }

    private (List<int>, List<int>) GetRanges(string input)
    {
        var inputs = input.Split(",");
        return (GetRange(inputs[0]), GetRange(inputs[1]));

        List<int> GetRange(string singleInput)
        {
            var range = singleInput.Split("-");
            return Enumerable.Range(Parse(range[0]), Parse(range[1]) - Parse(range[0]) + 1).ToList();
        }
    }
}