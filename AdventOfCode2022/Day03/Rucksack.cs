using System.Text;

namespace AdventOfCode2022.Day03;

internal class Rucksack
{
    private readonly IEnumerable<string> _lines;

    public Rucksack(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public int PuzzleOne() => _lines.Sum(CalculateRoundOneResult);

    public int PuzzleTwo() => CalculateRoundTwoResult();

    private int CalculateRoundOneResult(string line)
    {
        var capacity = line.Length / 2;
        var left = line[..capacity];
        var right = line[capacity..];
        var duplicate = left.Intersect(right).ToArray();

        return GetFirstValue(duplicate);
    }

    private int CalculateRoundTwoResult()
    {
        var result = 0;
        for (var i = 0; i < _lines.Count(); i += 3)
        {
            var duplicate =
                _lines.ElementAt(i)
                    .Intersect(_lines.ElementAt(i + 1))
                    .Intersect(_lines.ElementAt(i + 2))
                    .ToArray();

            result += GetFirstValue(duplicate);
        }

        return result;
    }

    private int GetFirstValue(char[] value)
    {
        var asciiValue = Encoding.ASCII.GetBytes(value).First();
        return asciiValue > 96 ? asciiValue - 96 : asciiValue - 38;
    }
}