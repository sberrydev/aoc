using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day11;

internal class MonkeyInTheMiddle
{
    private readonly string _lines;

    public MonkeyInTheMiddle(string lines)
    {
        _lines = lines;
    }

    public long PuzzleOne()
    {
        var monkeys = GetMonkeys(true);
        var itemsInspected = new List<long>();

        for (var i = 0; i < 20; i++)
        {
            PlayRound(monkeys);
        }

        itemsInspected.AddRange(monkeys.Select(monkey => monkey.ItemsInspected));

        var ordered = itemsInspected.OrderByDescending(x => x).ToArray();
        return ordered[0] * ordered[1];
    }

    public long PuzzleTwo()
    {
        var monkeys = GetMonkeys(false);
        var itemsInspected = new List<long>();

        for (var i = 0; i < 10000; i++)
        {
            PlayRound(monkeys);
        }

        itemsInspected.AddRange(monkeys.Select(monkey => monkey.ItemsInspected));

        var ordered = itemsInspected.OrderByDescending(x => x).ToArray();
        return ordered[0] * ordered[1];
    }

    public void PlayRound(IEnumerable<Monkey> monkeys)
    {
        foreach (var monkey in monkeys)
        {
            monkey.ThrowItems();
        }
    }

    private Monkey[] GetMonkeys(bool useOriginalWorryReducer)
    {
        var monkeys = _lines.Replace("\r", "")
            .Split("\n\n")
            .Select(monk =>
                CreateMonkeys(monk.Split("\n"), useOriginalWorryReducer))
            .ToArray();

        AssignThrownToMonkeys(monkeys);
        AssignTDenominator(monkeys);

        return monkeys;
    }

    private void AssignThrownToMonkeys(Monkey[] monkeys)
    {
        var l = _lines.Split("\n").Where(l => l.Contains("throw to monkey"));

        for (var i = 0; i < monkeys.Length * 2; i += 2)
        {
            var successfulThrow = int.Parse(Regex.Match(l.ElementAt(i), "\\d+").Value);
            var unsuccessfulThrow = int.Parse(Regex.Match(l.ElementAt(i + 1), "\\d+").Value);

            monkeys[i / 2].SuccessfulThrowTo = monkeys[successfulThrow];
            monkeys[i / 2].UnsuccessfulThrowTo = monkeys[unsuccessfulThrow];
        }
    }

    private void AssignTDenominator(Monkey[] monkeys)
    {
        var denom = monkeys.Aggregate(1L, (current, monkey) => current * monkey.DivisibleBy);

        foreach (var monkey in monkeys)
        {
            monkey.DivideBy = denom;
        }
    }

    private Monkey CreateMonkeys(string[] strings, bool useOriginalWorryReducer)
    {
        //todo replace regex to return all at once?
        var items = Regex.Matches(strings[1], "\\d+")
            .Select(worryLevel => new Item(int.Parse(worryLevel.Value)));

        var operationType = Regex.Match(strings[2], "\\*|-|/|\\+").Value;
        var opVal = Regex.Match(strings[2], "\\d+");
        var operationValue = opVal.Success ? int.Parse(opVal.Value) : 0;

        var divisibleBy = int.Parse(Regex.Match(strings[3], "\\d+").Value);

        return new Monkey(items, operationType, operationValue, divisibleBy, strings[0], useOriginalWorryReducer);
    }
}