using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    public class Player
    {

        public string Name { get; }
        public char Token { get; }

        public Player(string name, char token)
        {
            Name = name;
            Token = token;
        }
    }
}
