using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacDoomConsole;

namespace Tic_Tac_Doom
{
    public class UI
    {

        public void DisplayGrid(char[,] grid)
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Doom");
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

        public void MakeMove(GameLogic game, char[,] grid)
        {
            int row, col;
            do
            {
                Console.Write($"Player {(game.GetGrid(grid)[0, 0] == ' ' ? 'X' : 'O')}, enter your move (row and column): ");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(' ');
                if (coordinates.Length == 2 && int.TryParse(coordinates[0], out row) && int.TryParse(coordinates[1], out col))
                {
                    if (game.MakeMove(row, col, grid))
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
