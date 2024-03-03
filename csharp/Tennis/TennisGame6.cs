namespace Tennis;

public class TennisGame6 : ITennisGame
{
    Player player1;
    Player player2;

    public TennisGame6(string player1Name, string player2Name)
    {
        player1 = new Player(player1Name);
        player2 = new Player(player2Name);
    }

    public void WonPoint(string playerName)
    {
        if (playerName == player1.Name)
            player1.Score++;
        else
            player2.Score++;
    }

    public string GetScore()
    {
        string result;

        if (player1.Score == player2.Score)
        {
            // tie score
            string tieScore = player1.Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
            result = tieScore;
        }
        else if (player1.Score >= 4 || player2.Score >= 4)
        {
            // end-game score
            string endGameScore = (player1.Score - player2.Score) switch
            {
                1 => $"Advantage {player1.Name}",
                -1 => $"Advantage {player2.Name}",
                >= 2 => $"Win for {player1.Name}",
                _ => $"Win for {player2.Name}",
            };
            result = endGameScore;
        }
        else
        {
            // regular score
            string regularScore;

            var score1 = player1.Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            var score2 = player2.Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            regularScore = $"{score1}-{score2}";

            result = regularScore;
        }

        return result;
    }
}