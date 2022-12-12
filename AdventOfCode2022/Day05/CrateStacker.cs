using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day05;

internal class CrateStacker
{
    private readonly IEnumerable<string> _lines;

    public CrateStacker(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public string PuzzleOne()
    {
        var crates = GetCrates();
        var movedCrates = MoveCrates(crates, MoveCratesSingularly);
        return CratesToString(movedCrates);
    }

    public string PuzzleTwo()
    {
        var crates = GetCrates();
        var movedCrates = MoveCrates(crates, MoveCratesTogether);
        return CratesToString(movedCrates);
    }

    private List<List<char>> GetCrates()
    {
        var crateRows = _lines.TakeWhile(line => line.Contains('[')).ToList();
        var numberOfColumns = int.Parse(_lines.ElementAt(crateRows.Count).Trim().Last().ToString());

        List<List<char>> allCrates = new();

        for (var i = 0; i < numberOfColumns; i++)
        {
            allCrates.Add(new List<char>());
        }

        const int sizeOfColumn = 4;
        for (var row = 0; row < crateRows.Count; row++)
        {
            for (var column = 0; column < numberOfColumns * sizeOfColumn; column += sizeOfColumn)
            {
                if (crateRows.ElementAt(row)[column] == '[')
                {
                    allCrates[column / sizeOfColumn].Add(crateRows.ElementAt(row)[column + 1]);
                }
            }
        }

        return allCrates;
    }

    private List<List<char>> MoveCrates(List<List<char>> crates, Action<int, int, int, List<List<char>>> action)
    {
        const string regex = "(?<numberToMove>[0-9]+).*(?<fromStack>[0-9]+).*(?<toStack>[0-9]+)";

        var instructions = _lines.SkipWhile(line => !line.StartsWith('m'));

        foreach (var instruction in instructions)
        {
            var inst = Regex.Match(instruction, regex);
            var numberToMove = int.Parse(inst.Groups["numberToMove"].Value);
            var fromStack = int.Parse(inst.Groups["fromStack"].Value);
            var toStack = int.Parse(inst.Groups["toStack"].Value);

            action(numberToMove, fromStack, toStack, crates);
        }

        return crates;
    }

    public static void MoveCratesSingularly(int numberToMove, int fromStack, int toStack, List<List<char>> crates)
    {
        for (var repeatTimes = 0; repeatTimes < numberToMove; repeatTimes++)
        {
            var line = fromStack - 1;
            var moving = crates[line][0];
            crates[line].RemoveAt(0);
            crates[toStack - 1].Insert(0, moving);
        }
    }

    public static void MoveCratesTogether(int numberToMove, int fromStack, int toStack, List<List<char>> crates)
    {
        for (var repeatTimes = numberToMove - 1; repeatTimes >= 0; repeatTimes--)
        {
            var line = fromStack - 1;
            var moving = crates[line][repeatTimes];
            crates[line].RemoveAt(repeatTimes);
            crates[toStack - 1].Insert(0, moving);
        }
    }

    private string CratesToString(List<List<char>> movedCrates)
    {
        return movedCrates.Where(movedCrate => movedCrate.Any())
            .Aggregate("", (current, movedCrate) => current + movedCrate.First());
    }
}