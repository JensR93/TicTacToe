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
            var t =
            new TicTacToe(
                            ui,
                            new[]
                            {
                    ui.EmptyCellSymbol, ui.EmptyCellSymbol, ui.EmptyCellSymbol,
                    ui.EmptyCellSymbol, ui.EmptyCellSymbol, ui.EmptyCellSymbol,
                    ui.EmptyCellSymbol, ui.EmptyCellSymbol, ui.EmptyCellSymbol
                            },
                            new[]
                            {
                    new Player("Player 1", 'X'),
                    new Player("Player 2", 'O')
                            });
            t.Start();

        }
    }
}
