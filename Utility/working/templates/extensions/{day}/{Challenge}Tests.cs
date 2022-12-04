using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.{day}
{
    internal class {Challenge}Tests
    {
        private static string Day => typeof({Challenge}Tests).Namespace!.Split(".")[1];

        [Test]
        public void {day}_Part1_Example()
        {
            var input = DataLoader.LoadExample(Day);
            var {challenge} = new {Challenge}(input);
            var result = {challenge}.PuzzleOne();

            result.Should().Be(1);
        }

        [Test]
        public void {day}_Part1_Actual()
        {
            var input = DataLoader.LoadChallenge(Day);
            var {challenge} = new {Challenge}(input);
            var result = {challenge}.PuzzleOne();

            result.Should().Be(2);
        }

        [Test]
        public void {day}_Part2_Example()
        {
            var input = DataLoader.LoadExample(Day);
            var {challenge} = new {Challenge}(input);
            var result = {challenge}.PuzzleTwo();

            result.Should().Be(1);
        }

        [Test]
        public void {day}_Part2_Actual()
        {
            var input = DataLoader.LoadChallenge(Day);
            var {challenge} = new {Challenge}(input);
            var result = {challenge}.PuzzleTwo();

            result.Should().Be(2);
        }
    }
}