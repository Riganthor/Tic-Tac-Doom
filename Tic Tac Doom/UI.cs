using System;
using TicTacDoomConsole;

namespace Tic_Tac_Doom
{
    public class UI
    {
        private string versusChoice = "2P"; // default

        public string GetVersusChoice()
        {
            return versusChoice;
        }

        public void PlayerChoice()
        {
            Console.WriteLine("Welcome to Tic Tac Doom!");
            Console.WriteLine("Do you want to play:");
            Console.WriteLine("1. Two Players (2P)");
            Console.WriteLine("2. Versus AI (AI)");
            Console.Write("Type your choice (2P or AI): ");
            string input = Console.ReadLine().ToUpper();

            if (input == "AI" || input == "2P")
            {
                versusChoice = input;
            }
            else
            {
                Console.WriteLine("Invalid input, defaulting to 2 Players.");
                versusChoice = "2P";
            }
        }

        public void DisplayGrid(char[,] grid)
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Doom");
            Console.WriteLine("-----------");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" {grid[i, 0]} | {grid[i, 1]} | {grid[i, 2]}");
                if (i < 2)
                    Console.WriteLine("---+---+---");
            }
            Console.WriteLine("-----------");
        }

        public void MakeMove(GameLogic game, char[,] grid)
        {
            int row, col;
            do
            {
                Console.Write($"Player {(game.IsPlayerXTurn() ? 'X' : 'O')}, enter your move (row and column, space-separated): ");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(' ');

                if (coordinates.Length == 2 &&
                    int.TryParse(coordinates[0], out row) &&
                    int.TryParse(coordinates[1], out col))
                {
                    if (game.MakeMove(row, col, grid))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Cell already taken or out of bounds.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Format: row col (e.g., 0 1)");
                }
            } while (true);
        }
    }
}
