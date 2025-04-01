using System;

public class TicTacDoom
{
    private const int GRIDSIZE = 3;
    private int[,] grid;
    private Random rng;

    public TicTacDoom()
    {
        rng = new Random();
        grid = new int[GRIDSIZE, GRIDSIZE];
        FillGrid();
    }

    private void FillGrid()
    {
        for (int i = 0; i < GRIDSIZE; i++)
        {
            for (int j = 0; j < GRIDSIZE; j++)
            {
                grid[i, j] = rng.Next(0, 3); // Random numbers 0, 1, or 2
            }
        }
    }

    public void DisplayGrid()
    {
        Console.WriteLine("+---+---+---+");
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write($"| {grid[i, j]} ");
            }
            Console.WriteLine("|");
            Console.WriteLine("+---+---+---+");
        }
    }
    public static void Main(string[] args)
    {
        TicTacDoom game = new TicTacDoom();
        game.DisplayGrid();
    }
}
