using System.Diagnostics;

namespace Tennis;

public class TennisGame6(string player1Name, string player2Name) : ITennisGame
{
    private Player player1 = new(player1Name);
    private Player player2 = new(player2Name);

    public void WonPoint(string playerName)
    {
        if (playerName == player1.Name)
            player1.Score++;
        else
            player2.Score++;
    }

    public string GetScore()
    {
        if (player1.Score == player2.Score) return GetTieScoreTerm();

        bool winPossible = player1.Score >= 4 || player2.Score >= 4;
        if (winPossible) return GetEndgameScoreTerm();
        
        string score1 = GetRegularScoreTerm(player1.Score);
        string score2 = GetRegularScoreTerm(player2.Score);
        
        return $"{score1}-{score2}";
    }

    private static string GetRegularScoreTerm(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
    }

    private string GetEndgameScoreTerm()
    {
        return (player1.Score - player2.Score) switch
        {
            1 => $"Advantage {player1.Name}",
            -1 => $"Advantage {player2.Name}",
            >= 2 => $"Win for {player1.Name}",
            <=-2 => $"Win for {player2.Name}",
            _ => throw new UnreachableException("Bad tie logic")
        };
    }

    private string GetTieScoreTerm()
    {
        return player1.Score switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce",
        };
    }
}