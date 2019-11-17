using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe
{
    class Start
    {
        static public void Main(String[] args)
        {


            var ui = new ConsoleInterface();

            var ConsoleBoard = new ConsoleBoard(3, 5);
            var TicTacToe =
            new TicTacToe(
                            ui,      
                            ConsoleBoard,
                            new[]
                            {
                    new Player("Player 1", 'X'),
                    new Player("Player 2", 'O')
                            });
            TicTacToe.Start();

        }
    }
}
