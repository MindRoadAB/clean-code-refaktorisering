namespace Tennis
{
    using System;
    using static System.Math;
    
    public class TennisGame3(string player1Name, string player2Name) : ITennisGame
    {
        private Player player1 = new(player1Name);
        private Player player2 = new(player2Name);

        public string GetScore()
        {
            bool winPossible = player1.Score >= 4 || player2.Score >= 4 || 
                               player1.Score + player2.Score >= 6;
            if (winPossible)
            {
                if (player1.Score == player2.Score)
                    return "Deuce";
                string highScoreName = player1.Score > player2.Score 
                                        ? player1.Name : player2.Name;
                bool isWin = Abs(player1.Score - player2.Score) >= 2;
                return isWin ? "Win for " + highScoreName
                             : "Advantage " + highScoreName;
            }
            else
            {
                string[] scoreTerms = { "Love", "Fifteen", "Thirty", "Forty" };
                string player1ScoreTerm = scoreTerms[player1.Score];
                return (player1.Score == player2.Score) 
                        ? player1ScoreTerm + "-All" : player1ScoreTerm + "-" + scoreTerms[player2.Score];
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