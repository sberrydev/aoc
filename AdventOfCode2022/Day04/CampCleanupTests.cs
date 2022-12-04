using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day04
{
    internal class CampCleanupTests
    {
        private static string Day => typeof(CampCleanupTests).Namespace!.Split(".")[1];

        [Test]
        public void Day04_Part1_Example()
        {
            var input = DataLoader.LoadExample(Day);
            var campCleanup = new CampCleanup(input);
            var result = campCleanup.PuzzleOne();

            result.Should().Be(2);
        }

        [Test]
        public void Day04_Part1_Actual()
        {
            var input = DataLoader.LoadChallenge(Day);
            var campCleanup = new CampCleanup(input);
            var result = campCleanup.PuzzleOne();

            result.Should().Be(503);
        }

        [Test]
        public void Day04_Part2_Example()
        {
            var input = DataLoader.LoadExample(Day);
            var campCleanup = new CampCleanup(input);
            var result = campCleanup.PuzzleTwo();

            result.Should().Be(4);
        }

        [Test]
        public void Day04_Part2_Actual()
        {
            var input = DataLoader.LoadChallenge(Day);
            var campCleanup = new CampCleanup(input);
            var result = campCleanup.PuzzleTwo();

            result.Should().Be(827);
        }
    }
}