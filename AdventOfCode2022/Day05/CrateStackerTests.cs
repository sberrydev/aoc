using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day05;

internal class CrateStackerTests
{
    private static string Day => typeof(CrateStackerTests).Namespace!.Split(".")[1];

    [Test]
    public void Day05_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var crateStacker = new CrateStacker(input);
        var result = crateStacker.PuzzleOne();

        result.Should().Be("CMZ");
    }

    [Test]
    public void Day05_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var crateStacker = new CrateStacker(input);
        var result = crateStacker.PuzzleOne();

        result.Should().Be("TQRFCBSJJ");
    }

    [Test]
    public void Day05_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var crateStacker = new CrateStacker(input);
        var result = crateStacker.PuzzleTwo();

        result.Should().Be("MCD");
    }

    [Test]
    public void Day05_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var crateStacker = new CrateStacker(input);
        var result = crateStacker.PuzzleTwo();

        result.Should().Be("RMHFJNVFP");
    }
}