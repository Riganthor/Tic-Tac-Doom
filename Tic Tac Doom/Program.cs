using System;
using System.ComponentModel.DataAnnotations;
using Tic_Tac_Doom;
using TicTacDoomConsole;

namespace TicTacDoomConsole
{
    class Program
    {
        

        static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            UI ui = new UI();
            bool gameOver = false;

            char[,] grid = new char[3, 3];
            grid = game.InitializeGrid(grid);

            while (!gameOver)
            {
                ui.DisplayGrid(grid);
                gameOver = ui.MakeMove(game);
                if (!gameOver)
                {
                    gameOver = game.CheckForWinner(grid);
                }
                if (!gameOver)
                {
                    gameOver = game.CheckForTie(grid);
                }
            }

            Console.WriteLine("Game Over!");
        }


        
    }
}
