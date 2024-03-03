using System;

namespace Tennis;

struct Player(string name)
{
    public int Score { get; set; } = 0;
    public string Name { get; set; } = name;
};
