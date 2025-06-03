using System;
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
            AI ai = new AI();

            ui.PlayerChoice();
            bool vsAI = ui.GetVersusChoice() == "AI";

            char[,] grid = new char[3, 3];
            game.InitializeGrid(grid);

            bool gameOver = false;

            while (!gameOver)
            {
                ui.DisplayGrid(grid);

                if (!vsAI || game.IsPlayerXTurn()) // Human move
                {
                    ui.MakeMove(game, grid);
                }
                else // AI move
                {
                    Console.WriteLine("AI is making a move...");
                    (int aiRow, int aiCol) = ai.GetMove(grid);
                    game.MakeMove(aiRow, aiCol, grid);
                }

                if (game.CheckForWinner(grid) || game.CheckForTie(grid))
                {
                    ui.DisplayGrid(grid);
                    gameOver = true;
                }
            }

            Console.WriteLine("Game Over! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
