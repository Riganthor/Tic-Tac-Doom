using System;

namespace TicTacDoomConsole
{ 
    public class GameLogic
    {
        private char[,] grid = new char[3, 3];
        private bool isPlayerX = true;

        public GameLogic()
        {
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public char[,] GetGrid()
        {
            return grid;
        }

        public bool MakeMove(int row, int col)
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3 && grid[row, col] == ' ')
            {
                grid[row, col] = isPlayerX ? 'X' : 'O';
                isPlayerX = !isPlayerX;
                return true;
            }
            return false;
        }

        public bool CheckForWinner()
        {
            // Check rows, columns, and diagonals for a winner
            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2] && grid[i, 0] != ' ')
                {
                    Console.WriteLine($"Player {grid[i, 0]} wins!");
                    return true;
                }
                if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i] && grid[0, i] != ' ')
                {
                    Console.WriteLine($"Player {grid[0, i]} wins!");
                    return true;
                }
            }
            if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2] && grid[0, 0] != ' ')
            {
                Console.WriteLine($"Player {grid[0, 0]} wins!");
                return true;
            }
            if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0] && grid[0, 2] != ' ')
            {
                Console.WriteLine($"Player {grid[0, 2]} wins!");
                return true;
            }
            return false;
        }

        public bool CheckForTie()
        {
            foreach (char cell in grid)
            {
                if (cell == ' ')
                {
                    return false;
                }
            }
            Console.WriteLine("It's a tie!");
            return true;
        }
    }
}
