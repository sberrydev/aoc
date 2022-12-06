using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day05
{
    internal class CrateStacker
    {
        private readonly IEnumerable<string> _lines;

        public CrateStacker(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public string PuzzleOne()
        {
            var crates = GetCrates();
            var movedCrates = MoveCrates(crates);
            return CratesToString(movedCrates);
        }

        public string PuzzleTwo()
        {
            var crates = GetCrates();
            var movedCrates = MoveCratesTwo(crates);
            return CratesToString(movedCrates);
        }

        private List<List<char>> GetCrates()
        {
            var crates = _lines.TakeWhile(line => line.Contains('[')).ToList();
            var numberOfItems = int.Parse(_lines.ElementAt(crates.Count).Trim().Last().ToString());

            List<List<char>> allCrates = new();

            for (var i = 0; i < numberOfItems; i++)
            {
                allCrates.Add(new List<char>());
            }

            for (var lineNumber = 0; lineNumber < crates.Count; lineNumber++)
            {
                for (var index = 0; index < numberOfItems * 4; index += 4)
                {
                    if (crates.ElementAt(lineNumber)[index] == '[')
                    {
                        allCrates[index / 4].Add(crates.ElementAt(lineNumber)[index + 1]);
                    }
                }
            }

            return allCrates;
        }

        //todo: stack?
        private List<List<char>> MoveCrates(List<List<char>> crates)
        {
            var instructions = _lines.SkipWhile(line => !line.StartsWith('m'));

            foreach (var instruction in instructions)
            {
                var inst = Regex.Split(instruction.TrimStart(), @"\D+").Where(data => data != string.Empty).ToArray();

                for (var repeatTimes = 0; repeatTimes < int.Parse(inst[0]); repeatTimes++)
                {
                    var line = int.Parse(inst[1]) - 1;
                    var moving = crates[line][0];
                    crates[line].RemoveAt(0);
                    crates[int.Parse(inst[2]) - 1].Insert(0, moving);
                }
            }

            return crates;
        }

        //todo: refactor into one
        private List<List<char>> MoveCratesTwo(List<List<char>> crates)
        {
            var regex = "([0-9]+).*([0-9]+).*([0-9]+)";

            var instructions = _lines.SkipWhile(line => !line.StartsWith('m'));

            foreach (var instruction in instructions)
            {
                var inst = Regex.Split(instruction, regex);
                for (var repeatTimes = int.Parse(inst[1]) - 1; repeatTimes >= 0; repeatTimes--)
                {
                    var line = int.Parse(inst[2]) - 1;
                    var moving = crates[line][repeatTimes];
                    crates[line].RemoveAt(repeatTimes);
                    crates[int.Parse(inst[3]) - 1].Insert(0, moving);
                }
            }

            return crates;
        }

        private string CratesToString(List<List<char>> movedCrates)
        {
            return movedCrates.Where(movedCrate => movedCrate.Any())
                .Aggregate("", (current, movedCrate) => current + movedCrate.First());
        }
    }
}