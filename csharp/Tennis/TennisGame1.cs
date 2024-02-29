using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private Dictionary<string, int> playerScores;
        private readonly string player1Name;
        private readonly string player2Name;

        private static readonly string[] scoreNames =
        {
            "Love",
            "Fifteen",
            "Thirty",
            "Forty"
        };

        private const int FirstTiebreakScore = 4;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;

            playerScores = new Dictionary<string, int>()
            {
                { player1Name, 0 },
                { player2Name, 0 },
            };
        }

        public void WonPoint(string playerName)
        {
            // Hate identifying players by name, should identify by index/enum
            if (!playerScores.ContainsKey(playerName))
            {
                throw new TennisException($"Invalid tennis player name: {playerName}");
            }

            playerScores[playerName]++;
        }

        private int GetPlayerScore(string playerName)
        {
            return playerScores[playerName];
        }

        public string GetScore()
        {
            int p1Score = GetPlayerScore(player1Name);
            int p2Score = GetPlayerScore(player2Name);

            if (p1Score == p2Score)
            {
                if (p1Score >= FirstTiebreakScore - 1)
                {
                    return "Deuce";
                }

                return $"{scoreNames[p1Score]}-All";
            }
            
            if (p1Score >= FirstTiebreakScore || p2Score >= FirstTiebreakScore)
            {
                // 2-set tiebreakers, first player who wins two in a row wins
                int deltaScore = p1Score - p2Score;
                string leadingPlayer = deltaScore > 0 ? player1Name : player2Name;
                bool isWin = Math.Abs(deltaScore) > 1;
                string initialText = isWin ? "Win for" : "Advantage";

                return $"{initialText} {leadingPlayer}";
            }

            return $"{scoreNames[p1Score]}-{scoreNames[p2Score]}";
        }
    }
}

