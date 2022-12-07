using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day06;

internal class TuningTroubleTests
{
    private static string Day => typeof(TuningTroubleTests).Namespace!.Split(".")[1];

    [Test]
    public void Day06_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var tuningTrouble = new TuningTrouble(input);
        var result = tuningTrouble.PuzzleOne();

        result.Should().Be(11);
    }

    [Test]
    public void Day06_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var tuningTrouble = new TuningTrouble(input);
        var result = tuningTrouble.PuzzleOne();

        result.Should().Be(1235);
    }

    [Test]
    public void Day06_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var tuningTrouble = new TuningTrouble(input);
        var result = tuningTrouble.PuzzleTwo();

        result.Should().Be(26);
    }

    [Test]
    public void Day06_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var tuningTrouble = new TuningTrouble(input);
        var result = tuningTrouble.PuzzleTwo();

        result.Should().Be(3051);
    }

    //todo: add tests for all example cases
}