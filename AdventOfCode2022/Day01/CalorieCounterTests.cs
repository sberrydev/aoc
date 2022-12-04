using FluentAssertions;
using NUnit.Framework;
using Utility;

namespace AdventOfCode2022.Day01
{
    internal class RockPaperScissorsTests
    {
        private static string Day => typeof(RockPaperScissorsTests).Namespace!.Split(".")[1];

        [Test]
        public void Day1_Part1_Example()
        {
            var input = DataLoader.LoadExample(Day);
            var calorieCounter = new CalorieCounter(input);
            var maxCalories = calorieCounter.PuzzleOne();

            maxCalories.Should().Be(24000);
        }

        [Test]
        public void Day1_Part1_Actual()
        {
            var input = DataLoader.LoadChallenge(Day);
            var calorieCounter = new CalorieCounter(input);
            var maxCalories = calorieCounter.PuzzleOne();

            maxCalories.Should().Be(71023);
        }

        [Test]
        public void Day1_Part2_Example()
        {
            var input = DataLoader.LoadExample(Day);
            var calorieCounter = new CalorieCounter(input);
            var maxCalories = calorieCounter.PuzzleTwo();

            maxCalories.Should().Be(45000);
        }

        [Test]
        public void Day1_Part2_Actual()
        {
            var input = DataLoader.LoadChallenge(Day);
            var calorieCounter = new CalorieCounter(input);
            var maxCalories = calorieCounter.PuzzleTwo();

            maxCalories.Should().Be(206289);
        }
    }
}