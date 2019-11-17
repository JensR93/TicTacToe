using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Interface
{
    public abstract class Board
    {
        public int Rows;
        public int Coloumns;
        public char EmptyCellSymbol => '0';
        public char[] Cells;
        public abstract void ShowBoard();
        public Board(int rows, int columns)
        {
            Rows = rows;
            Coloumns = columns;

        }
    }
}
