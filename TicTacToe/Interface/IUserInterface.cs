using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe.Interface
{
    public interface IUserInterface
    {

        char EmptyCellSymbol { get; }
        string GetUserInput();
        void ShowEnd();
        void ShowInvalidChoice();
        void ShowTurn(Player[] players, string currentPlayerName, char[] cells);
        void ShowWin(string playerName, char[] cells);
    }
}
