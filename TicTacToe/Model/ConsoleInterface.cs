using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interface;

namespace TicTacToe.Model
{
    public class ConsoleInterface : IUserInterface
    { 

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
            

        }

        /// <summary>
        /// Message the win to the user
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="cells"></param>
        public void ShowWin(string playerName, char[] cells)
        {
            Console.WriteLine(playerName+" wins");
        }
    }
}
