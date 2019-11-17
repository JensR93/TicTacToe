using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interface;

namespace TicTacToe.Model
{
    public class ConsoleInterface : IUserInterface
    {
        // The default Symbol for the board cells that where not picked
        public char EmptyCellSymbol => '0';

        /// <summary>
        /// Read the User Input in the Console
        /// </summary>
        /// <returns></returns>
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Shows a message to the User after the game finished
        /// </summary>
        public void ShowEnd()
        {
            Console.WriteLine("Game finished!");
        }

        /// <summary>
        /// If the user make an invalid turn he receives a message
        /// </summary>
        public void ShowInvalidChoice()
        {
            Console.WriteLine("The cell is already marked or invalid.");
            Console.WriteLine("Please choose an other cell.\n");

            Task.Delay(2000).Wait();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="players"></param>
        /// <param name="currentPlayerName"></param>
        /// <param name="cells"></param>
        public void ShowTurn(Player[] players, string currentPlayerName, char[] cells)
        {
            Console.Clear();
            Console.WriteLine($"{players[0].Name}:{players[0].Token} and {players[1].Name}:{players[1].Token}\n");
            Console.WriteLine($"{currentPlayerName} chance\n");
            ShowBoard(cells);

        }

        public void ShowWin(string playerName, char[] cells)
        {
            ShowBoard(cells);
            Console.WriteLine(playerName+" wins");
        }
        private void ShowBoard(char[] cells)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {GetCellValue(0, cells)}  |  {GetCellValue(1, cells)}  |  {GetCellValue(2, cells)}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {GetCellValue(3, cells)}  |  {GetCellValue(4, cells)}  |  {GetCellValue(5, cells)}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {GetCellValue(6, cells)}  |  {GetCellValue(7, cells)}  |  {GetCellValue(8, cells)}");
            Console.WriteLine("     |     |      ");
        }

        private string GetCellValue(int index, char[] cells)
        {
            if (cells[index] == EmptyCellSymbol) return (index + 1).ToString();
            return cells[index].ToString();
        }
    }
}
