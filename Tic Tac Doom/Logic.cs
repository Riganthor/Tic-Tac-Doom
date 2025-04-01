using System;

public class TicTacDoom
{
    private const int GRIDSIZE = 3;
    private int[,] grid;

    public TicTacDoom()
    {
        grid = new int[GRIDSIZE, GRIDSIZE];
    }

    public void DisplayGrid()
    {
        Console.WriteLine("+---+---+---+");
        for (int i = 0; i < GRIDSIZE; i++)
        {
            for (int j = 0; j < GRIDSIZE; j++)
            {
                Console.Write("|   ");
            }
            Console.WriteLine("|");
            Console.WriteLine("+---+---+---+");
        }
    }
}