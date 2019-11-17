using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    public class ConsoleBoard
    {
        public char EmptyCell => '0';
        public char[] cells;
        public ConsoleBoard(ConsoleInterface ui)
        {
            cells = new[]
                            {
                    ui.EmptyCellSymbol, ui.EmptyCellSymbol, ui.EmptyCellSymbol,
                    ui.EmptyCellSymbol, ui.EmptyCellSymbol, ui.EmptyCellSymbol,
                    ui.EmptyCellSymbol, ui.EmptyCellSymbol, ui.EmptyCellSymbol
                            };
        }
        public void ShowBoard()
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
            if (cells[index] == EmptyCell) return (index + 1).ToString();
            return cells[index].ToString();
        }
    }
}
