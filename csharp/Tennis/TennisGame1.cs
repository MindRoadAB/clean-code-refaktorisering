using System.Diagnostics;

namespace Tennis
{
    public class TennisGame1 (string player1Name, string player2Name) : ITennisGame
{
    private Player player1 = new(player1Name);
    private Player player2 = new(player2Name);

        public void WonPoint(string playerName)
        {
            if (playerName == player1.Name)
                player1.Score += 1;
            else if (playerName == player1.Name)
                player2.Score += 1;
            else throw new UnreachableException("Bad player name");
        }

        public string GetScore()
        {
            if (player1.Score == player2.Score)
            {
                return player1.Score switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce",
                };
            }
            else if (player1.Score >= 4 || player2.Score >= 4)
            {
                var scoreDifference = player1.Score - player2.Score;
                return scoreDifference switch
                {
                    1 => "Advantage player1",
                    -1 => "Advantage player2",
                    >= 2 => "Win for player1",
                    _ => "Win for player2",
                };
            }
            else
            {
                return $"{GetRegularScoreTerm(player1.Score)}-{GetRegularScoreTerm(player2.Score)}";
            }
        }

        private static string GetRegularScoreTerm(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty",
            };
        }
    }
}

