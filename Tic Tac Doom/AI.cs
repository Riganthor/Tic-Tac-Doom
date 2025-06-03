using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Doom
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
            }
            while (grid[row, col] != ' '); // Keep trying until an empty cell is found

            return (row, col);
        }
    }
}
