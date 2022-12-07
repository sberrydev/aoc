using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day03;

internal class RucksackTests
{
    private static string Day => typeof(RucksackTests).Namespace!.Split(".")[1];

    [Test]
    public void Day03_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var rucksack = new Rucksack(input);
        var result = rucksack.PuzzleOne();

        result.Should().Be(157);
    }

    [Test]
    public void Day03_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var rucksack = new Rucksack(input);
        var result = rucksack.PuzzleOne();

        result.Should().Be(7917);
    }

    [Test]
    public void Day03_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var rucksack = new Rucksack(input);
        var result = rucksack.PuzzleTwo();

        result.Should().Be(70);
    }

    [Test]
    public void Day03_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var rucksack = new Rucksack(input);
        var result = rucksack.PuzzleTwo();

        result.Should().Be(2585);
    }
}