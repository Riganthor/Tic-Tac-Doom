using System;
using static TicTacDoomConsole.GameLogic;

namespace TicTacDoomConsole
{ 
    public class GameLogic
    {
        private bool isPlayerX = true;


        public enum GameMode
        {
            TwoPlayers,
            PlayerVsAI
        }

        public bool IsPlayerXTurn()
        {
            return isPlayerX;
        }

        public GameLogic(GameMode mode)
        {
            GameMode = mode;

            if (GameMode == GameMode.PlayerVsAI)
            {
                aiPlayer = new AIPlayer(); // Replace with your actual AI instantiation
            }
        }

        public char[,] InitializeGrid(char[,] grid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = ' ';
                }
            }
            return grid;
        }



        public char[,] GetGrid(char[,] grid)
        {
            return grid;
        }

        public bool MakeMove(int row, int col, char[,] grid)
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3 && grid[row, col] == ' ')
            {
                grid[row, col] = isPlayerX ? 'X' : 'O';

                if (GameMode == GameMode.PlayerVsAI && !isPlayerX)
                {
                    isPlayerX = !isPlayerX;
                    return true; // Skip AI move here; handle it externally
                }

                isPlayerX = !isPlayerX;
                return true;
            }
            return false;
        }




        public bool CheckForWinner(char[,] grid)
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

        public bool CheckForTie(char[,] grid)
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
