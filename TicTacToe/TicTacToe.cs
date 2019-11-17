using System;
using System.Linq;
using TicTacToe.Interface;
using TicTacToe.Model;

namespace TicTacToe
{
    public class TicTacToe
    {
        private readonly IUserInterface m_UI;
        private readonly Player[] m_Players;
        private Player m_CurrentPlayer;
        private readonly char[] m_Cells;

        public  TicTacToe Default()
        {
            var ui = new ConsoleInterface();

            return new TicTacToe(
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
        }

        public TicTacToe(IUserInterface ui, char[] cells, Player[] player)
        {
            m_UI = ui;
            m_Cells = cells;
            m_Players = player;
        }

        public void Start()
        {
            m_CurrentPlayer = m_Players[0];

            while (true)
            {
                m_UI.ShowTurn(m_Players, m_CurrentPlayer.Name, m_Cells);

                if (!Turn())
                {
                    m_UI.ShowInvalidChoice();
                    continue;
                }

                if (PlayerWins(m_CurrentPlayer.Token))
                {
                    m_UI.ShowWin(m_CurrentPlayer.Name, m_Cells);
                    break;
                }

                if (IsDraw()) break;

                NextPlayer();
            }

            m_UI.ShowEnd();
        }

        private bool Turn()
        {
            int index;
            bool isIntValue = int.TryParse(m_UI.GetUserInput(), out index);
            if (isIntValue) index = index - 1;

            if (!isIntValue || index < 0 || index > 8 || m_Cells[index] != m_UI.EmptyCellSymbol)
            {
                return false;
            }

            m_Cells[index] = m_CurrentPlayer.Token;
            return true;
        }

        private void NextPlayer()
        {
            if (m_CurrentPlayer == m_Players[0]) m_CurrentPlayer = m_Players[1];
            else m_CurrentPlayer = m_Players[0];
        }

        internal bool PlayerWins(char value)
        {
            for (int i = 0; i < 7; i = i + 3)
            {
                if (CheckCellValues(value, i, i + 1, i + 2)) return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (CheckCellValues(value, i, i + 3, i + 6)) return true;
            }

            if (CheckCellValues(value, 0, 4, 8)) return true;
            if (CheckCellValues(value, 2, 4, 6)) return true;

            return false;
        }

        internal bool IsDraw()
        {
            return !m_Cells.Any(a => a == m_UI.EmptyCellSymbol);
        }

        private bool CheckCellValues(char value, int index1, int index2, int index3)
        {
            return m_Cells[index1] == value && m_Cells[index2] == value && m_Cells[index3] == value;
        }
    }
}

