namespace Tennis
{
    using System;
    using static System.Math;
    
    public class TennisGame3 : ITennisGame
    {
        Player player1;
        Player player2;

        public TennisGame3(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            bool winPossible = player1.Score >= 4 || player2.Score >= 4 || 
                               player1.Score + player2.Score >= 6;
            if (!winPossible)
            {
                string[] scoreTerms = { "Love", "Fifteen", "Thirty", "Forty" };
                string player1ScoreTerm = scoreTerms[player1.Score];
                return (player1.Score == player2.Score) 
                        ? player1ScoreTerm + "-All" : player1ScoreTerm + "-" + scoreTerms[player2.Score];
            }
            else
            {
                if (player1.Score == player2.Score)
                    return "Deuce";
                string highScoreName = player1.Score > player2.Score 
                                        ? player1.Name : player2.Name;
                bool isWin = Abs(player1.Score - player2.Score) >= 2;
                return isWin ? "Win for " + highScoreName
                             : "Advantage " + highScoreName;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.Name)
                player1.Score += 1;
            else if (playerName == player2.Name)
                player2.Score += 1;
            else throw new ArgumentException("Bad player name");
        }

    }
}