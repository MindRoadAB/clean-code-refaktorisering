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
            string score = "";
            var tempScore = 0;
            if (player1.Score == player2.Score)
            {
                switch (player1.Score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (player1.Score >= 4 || player2.Score >= 4)
            {
                var minusResult = player1.Score - player2.Score;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = player1.Score;
                    else { score += "-"; tempScore = player2.Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

