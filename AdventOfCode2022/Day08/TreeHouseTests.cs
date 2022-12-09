using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day08;

internal class TreeHouseTests
{
    private static string Day => typeof(TreeHouseTests).Namespace!.Split(".")[1];

    [Test]
    public void Day08_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var treeHouse = new TreeHouse(input);
        var result = treeHouse.PuzzleOne();

        result.Should().Be(21);
    }

    [Test]
    public void Day08_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var treeHouse = new TreeHouse(input);
        var result = treeHouse.PuzzleOne();

        result.Should().Be(1792);
    }

    [Test]
    public void Day08_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var treeHouse = new TreeHouse(input);
        var result = treeHouse.PuzzleTwo();

        result.Should().Be(8);
    }

    [Test]
    public void Day08_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var treeHouse = new TreeHouse(input);
        var result = treeHouse.PuzzleTwo();

        result.Should().Be(334880);
    }
}