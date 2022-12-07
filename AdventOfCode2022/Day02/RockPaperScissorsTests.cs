using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day02;

internal class RockPaperScissorsTests
{
    private static string Day => typeof(RockPaperScissorsTests).Namespace!.Split(".")[1];

    [Test]
    public void Day2_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var rockPaperScissors = new RockPaperScissors(input);
        var maxCalories = rockPaperScissors.PuzzleOne();

        maxCalories.Should().Be(15);
    }

    [Test]
    public void Day2_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var rockPaperScissors = new RockPaperScissors(input);
        var maxCalories = rockPaperScissors.PuzzleOne();

        maxCalories.Should().Be(9177);
    }

    [Test]
    public void Day2_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var rockPaperScissors = new RockPaperScissors(input);
        var maxCalories = rockPaperScissors.PuzzleTwo();

        maxCalories.Should().Be(12);
    }

    [Test]
    public void Day2_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var rockPaperScissors = new RockPaperScissors(input);
        var maxCalories = rockPaperScissors.PuzzleTwo();

        maxCalories.Should().Be(12111);
    }
}