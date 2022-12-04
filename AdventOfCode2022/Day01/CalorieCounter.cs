namespace AdventOfCode2022.Day01
{
    internal class CalorieCounter
    {
        private readonly IEnumerable<string> _lines;

        public CalorieCounter(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public int PuzzleOne() => GetAllCalories().First();

        public int PuzzleTwo() => GetAllCalories().Take(3).Sum();

        private IEnumerable<int> GetAllCalories()
        {
            var totalCaloriesPerElf = new List<int>();
            var currentCalories = 0;

            foreach (var line in _lines)
            {
                if (line.Trim() != string.Empty)
                {
                    currentCalories += int.Parse(line);
                }
                else
                {
                    totalCaloriesPerElf.Add(currentCalories);
                    currentCalories = 0;
                }
            }

            totalCaloriesPerElf.Add(currentCalories);
            return totalCaloriesPerElf.OrderByDescending(totalCalories => totalCalories);
        }
    }
}