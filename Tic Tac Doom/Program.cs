using System;
using System.ComponentModel.DataAnnotations;
using TicTacDoomConsole;

namespace TicTacDoomConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            bool gameOver = false;
            int show;

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

            show = game.DisplayGrid;
            Console.WriteLine("Game Over!");
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
