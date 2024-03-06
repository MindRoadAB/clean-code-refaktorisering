#include <string>
#include <map>

const std::string getIndividualScore(int score)
{
    constexpr const char* scoreList[4] = {"Love", "Fifteen", "Thirty", "Forty"};
    return scoreList[score];
}

const std::string getWinOrAdvantage(int scoreDifference)
{
    std::map<int, std::string> outcomes = {
        {1, "Advantage player1"}, {-1, "Advantage player2"}, {2, "Win for player1"}, {-2, "Win for player2"}};

    auto it = outcomes.find(scoreDifference);
    if (it != outcomes.end())
    {
        return it->second;
    } 
    else
    {
        return scoreDifference > 0 ? outcomes[2] : outcomes[-2];
    }
}

inline const std::string getEqualScore(int p1CurrentScore, int deuceCriteria = 3)
{
    return (p1CurrentScore >= deuceCriteria) ? "Deuce" : getIndividualScore(p1CurrentScore) + "-All";
}

inline const std::string getCurrentScoreBetweenPlayers(int p1CurrentScore, int p2CurrentScore)
{
    return getIndividualScore(p1CurrentScore) + "-" + getIndividualScore(p2CurrentScore);
}

inline const int isMatchPoint(int p1CurrentScore, int p2CurrentScore, int matchPointCriteria = 4)
{
    return p1CurrentScore >= matchPointCriteria || p2CurrentScore >= matchPointCriteria;
}

inline const int calculateScoreDifference(int p1CurrentScore, int p2CurrentScore)
{
    return p1CurrentScore - p2CurrentScore;
}

const std::string tennisScore(int p1CurrentScore, int p2CurrentScore)
{
    bool isGameTied = p1CurrentScore == p2CurrentScore ? true : false;
    if (isGameTied)
    {
        return getEqualScore(p1CurrentScore);
    }
    else if (isMatchPoint(p1CurrentScore, p2CurrentScore))
    {
        return getWinOrAdvantage(calculateScoreDifference(p1CurrentScore, p2CurrentScore));
    }
    else
    {
        return getCurrentScoreBetweenPlayers(p1CurrentScore, p2CurrentScore);
    }
}
