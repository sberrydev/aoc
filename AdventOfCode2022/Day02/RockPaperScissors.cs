namespace AdventOfCode2022.Day02;

internal class RockPaperScissors
{
    private readonly IEnumerable<string> _lines;

    public RockPaperScissors(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public int PuzzleOne() => _lines.Sum(CalculateRoundOneResult);

    public int PuzzleTwo() => _lines.Sum(CalculateRoundTwoResult);

    private int CalculateRoundOneResult(string matchGame)
    {
        var player = matchGame.Split(" ");
        var player1Score = GameScore.Scores[player[1]];

        if (GameScore.Scores[player[0]] == player1Score)
        {
            return player1Score + GameScore.DrawScore;
        }

        return GameScore.WinConditions.Contains(KeyValuePair.Create(player[0], player[1]))
            ? player1Score + GameScore.WinningScore
            : player1Score;
    }

    private int CalculateRoundTwoResult(string matchGame)
    {
        var player = matchGame.Split(" ");

        if (player[1] == GameScore.Draw)
        {
            return GameScore.Scores[player[0]] + GameScore.DrawScore;
        }

        return player[1] == GameScore.Win
            ? GameScore.Scores[GameScore.WinConditions[player[0]]] + GameScore.WinningScore
            : GameScore.Scores[GameScore.LoseConditions[player[0]]];
    }

    internal class GameType
    {
        internal class Player1
        {
            public const string Rock = "A";
            public const string Paper = "B";
            public const string Scissors = "C";
        }

        internal class Player2
        {
            public const string Rock = "X";
            public const string Paper = "Y";
            public const string Scissors = "Z";
        }
    }

    internal static class GameScore
    {
        public static Dictionary<string, string> WinConditions = new()
        {
            { GameType.Player1.Rock, GameType.Player2.Paper },
            { GameType.Player1.Paper, GameType.Player2.Scissors },
            { GameType.Player1.Scissors, GameType.Player2.Rock }
        };

        public static Dictionary<string, string> LoseConditions = new()
        {
            { GameType.Player1.Rock, GameType.Player2.Scissors },
            { GameType.Player1.Paper, GameType.Player2.Rock },
            { GameType.Player1.Scissors, GameType.Player2.Paper }
        };

        public static Dictionary<string, int> Scores = new()
        {
            { GameType.Player1.Rock, 1 },
            { GameType.Player1.Paper, 2 },
            { GameType.Player1.Scissors, 3 },
            { GameType.Player2.Rock, 1 },
            { GameType.Player2.Paper, 2 },
            { GameType.Player2.Scissors, 3 }
        };

        public const int WinningScore = 6;
        public const int DrawScore = 3;

        public const string Lose = "X";
        public const string Draw = "Y";
        public const string Win = "Z";
    }
}