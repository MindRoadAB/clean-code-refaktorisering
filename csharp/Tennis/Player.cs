using System;

namespace Tennis;

struct Player{
        public Player(string name)
        {
            this.Score = 0;
            this.Name = name;
        }
        public uint Score { get; set; }
        public string Name { get; set; }
    };
