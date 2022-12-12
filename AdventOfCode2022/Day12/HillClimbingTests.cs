using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day12;

internal class HillClimbingTests
{
    private static string Day => typeof(HillClimbingTests).Namespace!.Split(".")[1];

    [Test]
    public void Day12_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var hillClimbing = new HillClimbing(input);
        var result = hillClimbing.PuzzleOne();

        result.Should().Be(31);
    }

    [Test]
    public void Day12_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var hillClimbing = new HillClimbing(input);
        var result = hillClimbing.PuzzleOne();

        result.Should().Be(380);
    }

    [Test]
    public void Day12_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var hillClimbing = new HillClimbing(input);
        var result = hillClimbing.PuzzleTwo();

        result.Should().Be(29);
    }

    [Test]
    public void Day12_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var hillClimbing = new HillClimbing(input);
        var result = hillClimbing.PuzzleTwo();

        result.Should().Be(375);
    }
}