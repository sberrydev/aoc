using System.Text;

namespace AdventOfCode2022.Day10;

internal class CathodeRayTube
{
    private readonly IEnumerable<string> _lines;

    public CathodeRayTube(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public int PuzzleOne()
    {
        List<int> signalStrength = GetSignalStrengths();

        return CalculateFromCycles(signalStrength);
    }

    private int CalculateFromCycles(List<int> signalStrength)
    {
        var result = signalStrength[19] * 20;

        for (var i = 60; i < signalStrength.Count; i += 40)
        {
            result += signalStrength[i - 1] * i;
        }

        return result;
    }

    //refactor - shows 2x value for add, 3x value when no-op
    private List<int> GetSignalStrengths()
    {
        var register = 1;
        var toAdd = new List<Instructions>();
        var signalStrengths = new List<int>();
        var currentCycle = 1;

        var queue = new Queue<int>();
        foreach (var line in _lines)
        {
            if (line != "noop")
            {
                var instructions = line.Split(" ");

                toAdd.Add(new Instructions(2, int.Parse(instructions[1])));
            }

            signalStrengths.Add(register);
            currentCycle++;

            for (var i = 0; i < toAdd.Count; i++)
            {
                toAdd[i].Cycle--;

                if (toAdd[i].Cycle == 0)
                {
                    register += toAdd[i].Value;
                    signalStrengths.Add(register);
                }
            }

            toAdd.RemoveAll(ins => ins.Cycle == 0);
        }

        while (toAdd.Any())
        {
            for (var i = 0; i < toAdd.Count; i++)
            {
                toAdd[i].Cycle--;

                if (toAdd[i].Cycle == 0)
                {
                    register += toAdd[i].Value;
                    signalStrengths.Add(register);
                }
            }

            toAdd.RemoveAll(ins => ins.Cycle == 0);
        }

        return signalStrengths;
    }

    public string PuzzleTwo()
    {
        List<int> signalStrength = GetSignalStrengths();
        return DrawSprite(signalStrength);
    }

    private string DrawSprite(List<int> signalStrengths)
    {
        var lineIndex = 1;
        var index = 1;
        var sb = new StringBuilder();
        foreach (var signalStrength in signalStrengths)
        {
            if (Enumerable.Range(signalStrength, 3).Contains(lineIndex))
            {
                Console.Write("#");
                sb.Append("#");
            }
            else
            {
                Console.Write(".");
                sb.Append(".");
            }

            if (index % 40 == 0)
            {
                sb.AppendLine("");
                Console.WriteLine("");
                lineIndex = 0;
            }

            index++;
            lineIndex++;
        }

        return sb.ToString();
    }

    private List<int> GetSprite(List<int> signalStrength, int index)
    {
        return new List<int> { signalStrength[index], signalStrength[index] + 1, signalStrength[index] + 2 };
    }
}

public class Instructions
{
    public Instructions(int cycle, int value)
    {
        Cycle = cycle;
        Value = value;
    }

    public int Cycle { get; set; }

    public int Value { get; set; }
}