using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day11;

internal class MonkeyInTheMiddleTests
{
    private static string Day => typeof(MonkeyInTheMiddleTests).Namespace!.Split(".")[1];

    [Test]
    public void Day11_Part1_Example()
    {
        var input = DataLoader.LoadExampleString(Day);
        var monkeyInTheMiddle = new MonkeyInTheMiddle(input);
        var result = monkeyInTheMiddle.PuzzleOne();

        result.Should().Be(10605L);
    }

    [Test]
    public void Day11_Part1_Actual()
    {
        var input = DataLoader.LoadChallengeString(Day);
        var monkeyInTheMiddle = new MonkeyInTheMiddle(input);
        var result = monkeyInTheMiddle.PuzzleOne();

        result.Should().Be(56595L);
    }

    [Test]
    public void Day11_Part2_Example()
    {
        var input = DataLoader.LoadExampleString(Day);
        var monkeyInTheMiddle = new MonkeyInTheMiddle(input);
        var result = monkeyInTheMiddle.PuzzleTwo();

        result.Should().Be(2713310158L);
    }

    [Test]
    public void Day11_Part2_Actual()
    {
        var input = DataLoader.LoadChallengeString(Day);
        var monkeyInTheMiddle = new MonkeyInTheMiddle(input);
        var result = monkeyInTheMiddle.PuzzleTwo();

        result.Should().Be(15693274740);
    }
}