using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day10;

internal class CathodeRayTubeTests
{
    private static string Day => typeof(CathodeRayTubeTests).Namespace!.Split(".")[1];

    [Test]
    public void Day10_Part1_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var cathodeRayTube = new CathodeRayTube(input);
        var result = cathodeRayTube.PuzzleOne();

        result.Should().Be(13140);
    }

    [Test]
    public void Day10_Part1_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var cathodeRayTube = new CathodeRayTube(input);
        var result = cathodeRayTube.PuzzleOne();

        result.Should().Be(12640);
    }

    [Test]
    public void Day10_Part2_Example()
    {
        var input = DataLoader.LoadExample(Day);
        var cathodeRayTube = new CathodeRayTube(input);
        var result = cathodeRayTube.PuzzleTwo();

        result.Should().Be("##..##..##..##..##..##..##..##..##..##..\r\n" +
                           "###...###...###...###...###...###...###.\r\n" +
                           "####....####....####....####....####....\r\n" +
                           "#####.....#####.....#####.....#####.....\r\n" +
                           "######......######......######......####\r\n" +
                           "#######.......#######.......#######.....\r\n");
    }

    [Test]
    public void Day10_Part2_Actual()
    {
        var input = DataLoader.LoadChallenge(Day);
        var cathodeRayTube = new CathodeRayTube(input);
        var result = cathodeRayTube.PuzzleTwo();

        result.Should().Be("####.#..#.###..####.#....###....##.###..\r\n" +
                           "#....#..#.#..#....#.#....#..#....#.#..#.\r\n" +
                           "###..####.###....#..#....#..#....#.#..#.\r\n" +
                           "#....#..#.#..#..#...#....###.....#.###..\r\n" +
                           "#....#..#.#..#.#....#....#.#..#..#.#.#..\r\n" +
                           "####.#..#.###..####.####.#..#..##..#..#.\r\n");
    }
}