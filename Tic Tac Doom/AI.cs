namespace TicTacDoomConsole
{
    internal class AI
    {
        private Random rand = new Random();

        public (int, int) GetMove(char[,] grid)
        {
            int row, col;

            do
            {
                row = rand.Next(0, 3);
                col = rand.Next(0, 3);
            } while (grid[row, col] != ' ');

            return (row, col);
        }
    }
}