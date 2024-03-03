namespace Tennis
{
    using static System.Math;
    
    struct Player{
        public Player(string name)
        {
            this.Score = 0;
            this.Name = name;
        }
        public uint Score { get; set; }
        public string Name { get; set; }
    };

    public class TennisGame3 : ITennisGame
    {
        Player player1;
        Player player2;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            bool inFirstThreePoints = player1.Score >= 4 || player2.Score >= 4 || 
                                      player1.Score + player2.Score >= 6;
            if (!inFirstThreePoints)
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
            if (playerName == "player1")
                this.player1.Score += 1;
            else
                this.player2.Score += 1;
        }

    }
}