#include <bits/stdc++.h>
#include "useful.h"

using namespace std;

bool isEqualScore(int first, int second)
{
    return first == second;
}


bool isEndOfGame(int first, int second)
{
    return first >= 4 || second >= 4;
}


bool isAdvantage(int first, int second)
{
    return abs(first - second) == 1;
}


bool isDeuce(int score)
{
    return score >= 3;
}


string getScore(int score)
{
    switch (score)
    {
        case 0: return "Love";
        case 1: return "Fifteen";
        case 2: return "Thirty";
        case 3: return "Forty";
    }    
    
    error("translate", "illegal score", score);
    return "error";
}


string getEqualScore(int score)
{
    if (isDeuce(score)) return "Deuce";
    return getScore(score) + "-All";
}


string getBestPlayer(int first, int second)
{
    if (first > second) return "player1";
    return "player2";
}


string getWinnerScore(int first, int second)
{
    string bestPlayer = getBestPlayer(first, second);
    if (isAdvantage(first, second)) return "Advantage " + bestPlayer;
    return "Win for " + bestPlayer;
}


const string tennisScore(int first, int second) 
{
    if (isEqualScore(first, second)) return getEqualScore(first);
    if (isEndOfGame(first, second)) return getWinnerScore(first, second);
    return getScore(first) + "-" + getScore(second);
}
