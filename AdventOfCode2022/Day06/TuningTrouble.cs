namespace AdventOfCode2022.Day06
{
    internal class TuningTrouble
    {
        private readonly IEnumerable<string> _lines;

        public TuningTrouble(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public int PuzzleOne() => GetSignal(4);

        public int PuzzleTwo() => GetSignal(14);

        private int GetSignal(int distinctChars)
        {
            var line = _lines.First();

            for (var startIndex = 0; startIndex < line.Length - distinctChars; startIndex++)
            {
                if (line.Substring(startIndex, distinctChars).Distinct().Count() == distinctChars)
                {
                    return startIndex + distinctChars;
                }
            }

            return 0;
        }
    }
}