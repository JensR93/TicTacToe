using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Interface;

namespace TicTacToe.Model
{
    public class ConsoleBoard : Board
    {
        /// <summary>
        /// Draw the default empty board were no cells were choosen by any user
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="coloumns"></param>
        public ConsoleBoard(int rows, int coloumns) : base(rows, coloumns)
        {
            Cells = new char[rows*coloumns];
            int index = 0;
            for(int currentRow = 0; currentRow < rows; currentRow++)
            {
                for(int currentColoumn = 0; currentColoumn < coloumns; currentColoumn++)
                {
                    Cells[index] = EmptyCellSymbol;
                    index++;
                }
            }
            //Cells = new[]
            //                {
            //        EmptyCellSymbol, EmptyCellSymbol, EmptyCellSymbol,
            //        EmptyCellSymbol, EmptyCellSymbol, EmptyCellSymbol,
            //        EmptyCellSymbol, EmptyCellSymbol, EmptyCellSymbol
            //                };
        }

        /// <summary>
        /// Draw the board to the console.
        /// Each Cell could have the values: Token from Player 1, Token from Player 2, EmptyCellSymbol (0)
        /// </summary>
        public override void ShowBoard()
        {
            int index = 0;
            for (int currentRow = 0; currentRow < base.Rows; currentRow++)
            {
            //    Console.WriteLine("     |     |      ");
                String[] rowValues = new string[Coloumns];
                for (int currentColoumn = 0; currentColoumn < base.Coloumns; currentColoumn++)
                {
                    string cellvalue = GetCellValue(currentRow * Coloumns + currentColoumn, Cells); 
                    if(cellvalue.Length==1)
                    {
                        cellvalue += " ";
                    }
                    rowValues[currentColoumn] = cellvalue;
                    index++;
                }
                Console.WriteLine(string.Join("  |  ", rowValues));
            }

            //Console.WriteLine($"  {GetCellValue(0, Cells)}  |  {GetCellValue(1, Cells)}  |  {GetCellValue(2, Cells)}");
            //Console.WriteLine("_____|_____|_____ ");
            //Console.WriteLine("     |     |      ");
            //Console.WriteLine($"  {GetCellValue(3, Cells)}  |  {GetCellValue(4, Cells)}  |  {GetCellValue(5, Cells)}");
            //Console.WriteLine("_____|_____|_____ ");
            //Console.WriteLine("     |     |      ");
            //Console.WriteLine($"  {GetCellValue(6, Cells)}  |  {GetCellValue(7, Cells)}  |  {GetCellValue(8, Cells)}");
            //Console.WriteLine("     |     |      ");
        }

        /// <summary>
        /// Get the Char Value from the Cell
        /// If the cell value was not choosen the method will return the index +1
        /// If If the cell value was  choosen the method will return the user token
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cells"></param>
        /// <returns></returns>
        private string GetCellValue(int index, char[] cells)
        {
            // Cell was not choosen by any user. Return index + 1 of the cell
            if (cells[index] == EmptyCellSymbol) return (index + 1).ToString();
            // Cell was choosen. Return User Token
            return cells[index].ToString();
        }

    }
}
