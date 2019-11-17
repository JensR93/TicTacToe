using System;
using System.Linq;
using TicTacToe.Interface;
using TicTacToe.Model;

namespace TicTacToe
{
    public class TicTacToe
    {
        private readonly IUserInterface UI;
        private readonly Player[] Players;
        private Player CurrentPlayer;
        private Board Board;
        int maxUserInputNumber;

        /// <summary>
        /// Create a new game
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="board"></param>
        /// <param name="player"></param>
        public TicTacToe(IUserInterface ui,  Board board, Player[] player)
        {
            UI = ui;
            Players = player;
            Board = board;
            maxUserInputNumber= Board.Rows* Board.Coloumns;
        }
        /// <summary>
        /// Start the game
        /// </summary>
        public void Start()
        {
            CurrentPlayer = Players[0];

            // Endless loop for running the game
            while (true)
            {
                UI.ShowTurn(Players, CurrentPlayer.Name, Board.Cells);
                Board.ShowBoard();
                // Turn was invalid. For example user choosed a cell which was already picked
                // Game continues
                if (!Turn())
                {
                    UI.ShowInvalidChoice();
                    continue;
                }
                // Game ends
                if (PlayerWins(CurrentPlayer.Token))
                {
                    Board.ShowBoard();
                    UI.ShowWin(CurrentPlayer.Name, Board.Cells);
                    break;
                }
                // Game ends
                if (IsDraw()) break;

                NextPlayer();
            }

            UI.ShowEnd();
        }
        /// <summary>
        /// Check if the turn is valid
        /// </summary>
        /// <returns></returns>
        private bool Turn()
        {
            int index;
            // User entered a number
            bool isIntValue = int.TryParse(UI.GetUserInput(), out index);

            // Get the number the user entered -1 
            if (isIntValue) index = index - 1;

            // Turn is valid when the user entered  a number between 1-9 and if cell is free
            if (!isIntValue || index < 0 || index > maxUserInputNumber || Board.Cells[index] !=Board.EmptyCellSymbol)
            {
                return false;
            }

            // Set the value of the cell to the user token
            Board.Cells[index] = CurrentPlayer.Token;

            //return valid turn
            return true;
        }

        /// <summary>
        /// Swap CurrentPlayer
        /// </summary>
        private void NextPlayer()
        {
            if (CurrentPlayer == Players[0]) CurrentPlayer = Players[1];
            else CurrentPlayer = Players[0];
        }
        /// <summary>
        /// Checks if the game ends because a player wins
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal bool PlayerWins(char value)
        {
            int[] RowStrike = new int[Board.Coloumns];
            int[] ColoumnStrike = new int[Board.Rows];

            int[] DiagonalStrike = new int[Board.Rows];
            int index = 0;

            // Check Every Row
            for (int currentRow = 0; currentRow < Board.Rows; currentRow++)
            {
                for(int currentColoumn = 0; currentColoumn < Board.Coloumns; currentColoumn++)
                {
                    RowStrike[currentColoumn] = currentRow * Board.Coloumns + currentColoumn+1;
                }
                if (CheckCellValues(value, RowStrike)) return true;

            }

            //Check E
            for (int currentColoumn = 0; currentColoumn < Board.Coloumns; currentColoumn++)
            {
                for (int currentRow = 0; currentRow < Board.Rows; currentRow++)
                {
                    ColoumnStrike[currentRow] = currentRow * Board.Coloumns + currentColoumn + 1;
                }

                if (CheckCellValues(value, ColoumnStrike)) return true;
            }

            lreturn false;
        }

        /// <summary>
        /// Checks if the game is over because no free cell is available.
        /// </summary>
        /// <returns></returns>
        internal bool IsDraw()
        {
            // No cell value euqals the empty cell value. No free cell available
            return !Board.Cells.Any(a => a == Board.EmptyCellSymbol);
        }

        // Check if all values equals the token
        private bool CheckCellValues(char value, int[] indexes)
        {
            foreach (int index in indexes)
            {
                if (Board.Cells[index-1] != value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

