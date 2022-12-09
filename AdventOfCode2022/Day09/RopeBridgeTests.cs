using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day09;

internal class RopeBridgeTests
{
    private static string Day => typeof(RopeBridgeTests).Namespace!.Split(".")[1];

    [Test]
    public void Day09_Part1_Example1()
    {
        var input = DataLoader.LoadExample(1, Day);
        var ropeBridge = new RopeBridge(input);
        var result = ropeBridge.PuzzleOne();

        result.Should().Be(13);
    }

    [Test]
    public void Day09_Part1_Example2()
    {
        var input = DataLoader.LoadExample(2, Day);
        var ropeBridge = new RopeBridge(input);
        var result = ropeBridge.PuzzleOne();

        result.Should().Be(88);
    }

    [Test]
    public void Day09_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var ropeBridge = new RopeBridge(input);
        var result = ropeBridge.PuzzleOne();

        result.Should().Be(6212);
    }

    [Test]
    public void Day09_Part2_Example1()
    {
        var input = DataLoader.LoadExample(1, Day);
        var ropeBridge = new RopeBridge(input);
        var result = ropeBridge.PuzzleTwo();

        result.Should().Be(1);
    }

    [Test]
    public void Day09_Part2_Example2()
    {
        var input = DataLoader.LoadExample(2, Day);
        var ropeBridge = new RopeBridge(input);
        var result = ropeBridge.PuzzleTwo();

        result.Should().Be(36);
    }

    [Test]
    public void Day09_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var ropeBridge = new RopeBridge(input);
        var result = ropeBridge.PuzzleTwo();

        result.Should().Be(2522);
    }
}