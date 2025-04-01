using System;
using TicTacDoomConsole;

namespace TicTacDoomConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            bool gameOver = false;

            while (!gameOver)
            {
                DisplayGrid(game.GetGrid());
                gameOver = MakeMove(game);
                if (!gameOver)
                {
                    gameOver = game.CheckForWinner();
                }
                if (!gameOver)
                {
                    gameOver = game.CheckForTie();
                }
            }

            DisplayGrid(game.GetGrid());
            Console.WriteLine("Game Over!");
        }

        private static void DisplayGrid(char[,] grid)
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe");
            Console.WriteLine("-----------");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" " + grid[i, 0] + " | " + grid[i, 1] + " | " + grid[i, 2]);
                if (i < 2)
                {
                    Console.WriteLine("---+---+---");
                }
            }
            Console.WriteLine("-----------");
        }

        private static bool MakeMove(GameLogic game)
        {
            int row, col;
            do
            {
                Console.Write($"Player {(game.GetGrid()[0, 0] == ' ' ? 'X' : 'O')}, enter your move (row and column): ");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(' ');
                if (coordinates.Length == 2 && int.TryParse(coordinates[0], out row) && int.TryParse(coordinates[1], out col))
                {
                    if (game.MakeMove(row, col))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            } while (true);
            return false;
        }
    }
}
