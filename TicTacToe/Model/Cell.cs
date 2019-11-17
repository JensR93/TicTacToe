using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    public class Cell
    {
        public int RowNumber;
        public int ColoumnNumber;
        public int ValueNumber;
        public Char Token;

        public Cell(int rownumber, int coloumnnumer, Char token)
        {
            RowNumber = rownumber;
            ColoumnNumber = coloumnnumer;
            Token = token;
        }
    }
}
