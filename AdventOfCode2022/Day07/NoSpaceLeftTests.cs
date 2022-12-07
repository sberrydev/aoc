using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day07;

internal class NoSpaceLeftTests
{
    private static string Day => typeof(NoSpaceLeftTests).Namespace!.Split(".")[1];

    [Test]
    public void Day07_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var noSpaceLeft = new NoSpaceLeft(input);
        var result = noSpaceLeft.PuzzleOne();

        result.Should().Be(95437L);
    }

    [Test]
    public void Day07_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var noSpaceLeft = new NoSpaceLeft(input);
        var result = noSpaceLeft.PuzzleOne();

        result.Should().Be(1477771L);
    }

    [Test]
    public void Day07_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var noSpaceLeft = new NoSpaceLeft(input);
        var result = noSpaceLeft.PuzzleTwo();

        result.Should().Be(24933642L);
    }

    [Test]
    public void Day07_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var noSpaceLeft = new NoSpaceLeft(input);
        var result = noSpaceLeft.PuzzleTwo();

        result.Should().Be(3579501L);
    }
}